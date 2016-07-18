using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace WinFrm.WyethSMS
{
    public partial class FrmServer : Form
    {
        static string QueryVoucherKey = "dx";
        static SmsService.SMSServiceSoapClient smsClient = new SmsService.SMSServiceSoapClient("SMSServiceSoap");
        static SqlConnection sqlConn = new SqlConnection(ConfigurationManager.AppSettings["sqlconn"]);

        static MySQLHelper helper = new MySQLHelper();

        string strConn = ConfigurationManager.AppSettings["mysqlconn"];
        static string token = ConfigurationManager.AppSettings["token"];
        static Random rnd = new Random();


        public FrmServer()
        {
            InitializeComponent();
            helper.ConnectionString = strConn;
        }

        JavaScriptSerializer js = new JavaScriptSerializer();
        static bool flag = false;
        private void btnRun_Click(object sender, EventArgs e)
        {
            if (!flag)
            {
                timer1.Start();
                label2.Text = "运行中...";
                flag = true;
                btnRun.Text = "停止";
            }
            else
            {
                timer1.Stop();
                label2.Text = "已停止";
                flag = false;
                btnRun.Text = "启动";
            }
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "MaxID.txt";
            string maxID = File.ReadAllText(path);
            List<UP_SMS> list = new List<UP_SMS>();
            int iNextMinID = Convert.ToInt32(maxID);

            try
            {

                DataTable dt = helper.ExecuteDataTable(string.Format("select * from ec_up_sms where token ='{0}' and id >{1} and result_MsgContent LIKE '%+%' ORDER BY id desc", token, maxID));

                
                if (dt.Rows.Count > 0)
                {
                    List<string[]> lstMobile = new List<string[]>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string strQueryPreText = QueryVoucherKey;
                        string[] arr = new string[2];
                        if (dt.Rows[i]["result_MsgContent"] != DBNull.Value)
                        {
                            string strReceiveMsg = dt.Rows[i]["result_MsgContent"].ToString().Trim().ToLower();

                            //格式合格
                            if (strReceiveMsg.StartsWith(strQueryPreText))
                            {
                                strReceiveMsg = strReceiveMsg.Replace("＋", "+");
                                string strConsumerNumber = strReceiveMsg.Split('+')[1].Trim();
                                arr[0] = dt.Rows[i]["result_mobile"].ToString();
                                arr[1] = strConsumerNumber;
                                lstMobile.Add(arr);
                            }
                        }

                        if (iNextMinID < Convert.ToInt32(dt.Rows[i]["id"].ToString()))
                        {
                            iNextMinID = Convert.ToInt32(dt.Rows[i]["id"].ToString());
                        }
                    }

                    try
                    {
                        ThreadPool.QueueUserWorkItem(ReplyVoucherInfo, lstMobile);
                        File.WriteAllText(path, "" + iNextMinID);
                    }
                    catch (Exception ex2)
                    {
                        File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "Log2.txt", ex2.Message + "  " + DateTime.Now.ToString() + "\r\n");
                    }
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "Log.txt", ex.Message + "  " + DateTime.Now.ToString() + "\r\n");
            }
            //File.AppendAllText("E:\\oko222.txt", DateTime.Now.ToString()+"\r\n");

            //test
            //timer1.Enabled = false;
            //timer1.Stop();
        }

        private void FrmServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("是否确认退出程序？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                //Application.Exit();
                //this.Dispose();
                //this.Close();
            }
            else
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// 如何格式的数据,对手机号码进行查询并回复
        /// </summary>
        /// <param name="lstManagerQuery">[destnumber , consumermobile]</param>
        public static void ReplyVoucherInfo(object lstManagerQuery) //List<string[]>
        {
            string strContent = "";
            List<string[]> lstQuery = lstManagerQuery as List<string[]>;
            foreach (var v in lstQuery)
            {
                try
                {
                    string strDestNumber = v[0];
                    string strMemberCode = v[1];

                    //判断是否为店铺专员手机号码
                    string sql1 = "select * from  StoreInfo  where  1=1 AND  StoreMasterPhone='" + strDestNumber + "'";
                    sqlConn.Open();
                    SqlCommand cmd1 = new SqlCommand(sql1, sqlConn);
                    SqlDataAdapter da1 = new SqlDataAdapter(cmd1);
                    DataTable dt1 = new DataTable();
                    da1.Fill(dt1);
                    sqlConn.Close();
                    if (dt1.Rows.Count == 0)
                    {
                        continue;
                    }
                    else
                    {
                        //query voucher info from sqlserver 
                        string sql = "select * from  VIPCardInfo  where  1=1 AND  MemberCode='" + strMemberCode + "'";
                        sqlConn.Open();
                        SqlCommand cmd = new SqlCommand(sql, sqlConn);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        sqlConn.Close();

                        //正确匹配关键字和顾客编号下行短信：
                        //[[name]]顾客尊享号[[code]],请确认为使用者本人。--old
                        //[[name]]顾客尊享号[[code]],请用核销系统验证后使用。

                        //不在活动名单中：
                        //对不起，该顾客会员号不在此次活动名单内。
                        if (dt.Rows.Count > 0)
                        {
                            strContent = string.Format("{0}顾客尊享号{1},请用核销系统验证后使用。", dt.Rows[0]["MemberName"].ToString(), dt.Rows[0]["CardCode"]);
                            strContent += " [" + rnd.Next(1, 100) + "]";
                            try
                            {
                                smsClient.SendSMS(strDestNumber, 40, strContent, DateTime.Now.AddYears(-1), token);
                                sqlConn.Open();
                                string strSql = string.Format(@"INSERT INTO [Zenga].[dbo].[SendSmsHis]
           ([ActionType]
           ,[DestMobile]
           ,[SendContent]
           ,[CreateTime])
     VALUES
           (3
           ,'{0}'
           ,'{1}'
           ,getdate())", strDestNumber, strContent);
                                SqlCommand cmd2 = new SqlCommand(strSql, sqlConn);
                                cmd2.ExecuteNonQuery();
                                sqlConn.Close();
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        else
                        {
                            strContent = "对不起，该顾客会员号不在此次活动名单内。";
                            strContent += " [" + rnd.Next(1, 100) + "]";
                            smsClient.SendSMS(strDestNumber, 40, strContent, DateTime.Now.AddYears(-1), token); //正式token

                            sqlConn.Open();
                            string strSql = string.Format(@"INSERT INTO [Zenga].[dbo].[SendSmsHis]
           ([ActionType]
           ,[DestMobile]
           ,[SendContent]
           ,[CreateTime])
     VALUES
           (3
           ,'{0}'
           ,'{1}'
           ,getdate())", strDestNumber, strContent);
                            SqlCommand cmd3 = new SqlCommand(strSql, sqlConn);
                            cmd3.ExecuteNonQuery();
                            sqlConn.Close();
                        }
                        //记录发送记录
                    }
                }
                catch (Exception ex2)
                {

                }
            }
        }
    }
}
