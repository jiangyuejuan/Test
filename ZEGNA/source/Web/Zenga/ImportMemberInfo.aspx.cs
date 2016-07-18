using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;

using System.Data;
using System.IO;

using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Zenga.Web
{
    public partial class ImportMemberInfo : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            string strFileName = "C:\\GroupChange\\VipListLatest.xls";
            ImportSQL(strFileName);
           // ImportSQL(strFileName);
        }
        string fileName = "";
        protected void Button1_Click(object sender, EventArgs e)
        {
          
              if (FileUpload1.HasFile)
        {
            string fileExrensio = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();//ToLower转化为小写
            string FileType = FileUpload1.PostedFile.ContentType;
            string UploadURL = Server.MapPath("~/upload/");//上传的目录
            if (FileType == "image/bmp" || FileType == "image/gif" || FileType == "image/jpeg" || FileType == "image/jpg" || FileType == "image/png")//判断文件类型
            {

                try
                {
                    if (!System.IO.Directory.Exists(UploadURL))//判断文件夹是否已经存在
                    {
                        System.IO.Directory.CreateDirectory(UploadURL);//创建文件夹
                    }

                    FileUpload1.PostedFile.SaveAs(UploadURL + FileUpload1.FileName);
                }
                catch 
                {
                    Response .Write ("失败");
                }
            }
            else
            {
                Response.Write("格式错误");
            }
        }
        else 
             Response.Write("请选择文件");
        }
    


        


        protected void lbtnLogout_Click(object sender, EventArgs e)
        {
            Response.Cookies.Set(new HttpCookie("User", null));
            Response.Cookies.Set(new HttpCookie("StoreName", null));
            Response.Redirect("/login.aspx");
        }


        /// <summary>
        /// 更新，添加，删除的储存过程调用
        /// </summary>
        /// <param name="storedProcName">储存过程名</param>
        /// <param name="parameteres">更新，添加，删除所需参数</param>
        /// <param name="strConn">connection</param>
        /// <returns></returns>
        public int RunProcedureForNonQuery(string storedProcName, IDataParameter[] parameteres, string strConn)
        {
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                int rowsAffected = 0;
                try
                {
                    conn.Open();
                    SqlCommand cm = new SqlCommand();
                    cm.Connection = conn;
                    cm.CommandText = storedProcName;
                    cm.CommandType = CommandType.Text;
                    cm.CommandTimeout = 3000;
                    if (parameteres != null) cm.Parameters.AddRange(parameteres);
                    rowsAffected = cm.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    // logger.Debug("有异常抛出，具体原因如下：" + ex.Message);
                }
                return rowsAffected;
            }
        }

        /// <summary>
        /// 将CSV文件的数据读取到DataTable中
        /// </summary>
        /// <param name="fileName">CSV文件路径</param>
        /// <returns>返回读取了CSV数据的DataTable</returns>
        public DataTable OpenCSV(string fileName)
        {
            DataTable dt = new DataTable();
            FileStream fs = new FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default);
            //记录每次读取的一行记录
            string strLine = "";
            //记录每行记录中的各字段内容
            string[] aryLine;
            //标示列数
            int columnCount = 0;
            //标示是否是读取的第一行
            bool IsFirst = true;

            //逐行读取CSV中的数据
            while ((strLine = sr.ReadLine()) != null)
            {
                aryLine = strLine.Split(',');
                if (IsFirst == true)
                {
                    IsFirst = false;
                    columnCount = aryLine.Length;
                    //创建列
                    for (int i = 0; i < columnCount; i++)
                    {
                        DataColumn dc = new DataColumn(aryLine[i]);
                        dt.Columns.Add(dc);
                    }
                }
                else
                {
                    DataRow dr = dt.NewRow();
                    for (int j = 0; j < columnCount; j++)
                    {
                        //if (aryLine[j].Contains("\\\""))
                        //{
                        //    aryLine[j] = aryLine[j].Replace("\\\"", "");
                        //}


                        dr[j] = aryLine[j];
                    }
                    dt.Rows.Add(dr);
                }
            }

            sr.Close();
            fs.Close();
            return dt;
        }

        private void ImportSQL(string strFileName)
        {
           // string conn = "Server=10.10.6.237;Port=3306;Database=CRM_WeChat_9;Uid=root;Pwd=1;convert zero datetime=True;Allow User Variables=True;Connection Timeout=1000 ";
            // MySqlHelper dbhelp = new MySqlHelper(conn);

            string strcon = ConfigurationManager.AppSettings["sqlConn"];
            DataTable dt = null;
            SqlParameter p = new SqlParameter();
            //这个dt反正就是自己从数据库查出来，或者是自行组装的，就不多说  
            // dt = dbhelp.ExecuteDataTable("select  org_code,org_name from DIM_MANAGE_ORG_V", p); ;
            dt = OpenCSV(strFileName);//"C:\\GroupChange\\0.csv");
            if (dt.Columns.Count < 9)
            {
                return;
            }
            //Adding dummy entries  
            StringBuilder sb = new StringBuilder();
            //string sql = "Insert Into GAP0506 VALUES('";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sb.Append("Insert Into MemberInfo ([UserID],[Name],[Mobile] ,[Amount],[ManageStore] ,[CreateTime] ,[Status]) VALUES('");
                sb.Append(dt.Rows[i][0].ToString());
                sb.Append("','");
                sb.Append(dt.Rows[i][1].ToString());
                sb.Append("','");
                sb.Append(dt.Rows[i][2].ToString());
                sb.Append("',");
                //sb.Append(string.IsNullOrEmpty(dt.Rows[i][3].ToString()) == true ? "null" : dt.Rows[i][3].ToString());
                //sb.Append(",");
                //sb.Append(string.IsNullOrEmpty(dt.Rows[i][4].ToString()) == true ? "null" : dt.Rows[i][4].ToString());  
                //sb.Append(",'");
                sb.Append(dt.Rows[i][3].ToString());
                sb.Append(",'");
                sb.Append(dt.Rows[i][4].ToString());
                sb.Append("','");
                //sb.Append(dt.Rows[i][5].ToString());
                //sb.Append("','");
                sb.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                sb.Append("',");
                sb.Append("0");
                sb.Append(")");
                RunProcedureForNonQuery(sb.ToString(), null, strcon);
                sb.Clear();
                
            }         
        }


        private void ImportSQL1(string strFileName)
        {
            // string conn = "Server=10.10.6.237;Port=3306;Database=CRM_WeChat_9;Uid=root;Pwd=1;convert zero datetime=True;Allow User Variables=True;Connection Timeout=1000 ";
            // MySqlHelper dbhelp = new MySqlHelper(conn);

            string strcon = ConfigurationManager.AppSettings["sqlConn"];
            DataTable dt = null;
            SqlParameter p = new SqlParameter();
            //这个dt反正就是自己从数据库查出来，或者是自行组装的，就不多说  
            // dt = dbhelp.ExecuteDataTable("select  org_code,org_name from DIM_MANAGE_ORG_V", p); ;
            dt = OpenCSV(strFileName);//"C:\\GroupChange\\0.csv");
            if (dt.Columns.Count < 9)
            {
                return;
            }
            //Adding dummy entries  
            StringBuilder sb = new StringBuilder();
            //string sql = "Insert Into GAP0506 VALUES('";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sb.Append("Insert Into MemberInfo VALUES('");
                sb.Append(dt.Rows[i][0].ToString());
                sb.Append("','");
                sb.Append(dt.Rows[i][1].ToString());
                sb.Append("','");
                sb.Append(dt.Rows[i][2].ToString());
                sb.Append("',");
                sb.Append(string.IsNullOrEmpty(dt.Rows[i][3].ToString()) == true ? "null" : dt.Rows[i][3].ToString());
                sb.Append(",");
                sb.Append(string.IsNullOrEmpty(dt.Rows[i][4].ToString()) == true ? "null" : dt.Rows[i][4].ToString());
                sb.Append(",'");
                sb.Append(dt.Rows[i][5].ToString());
                sb.Append("','");
                sb.Append(dt.Rows[i][6].ToString());
                sb.Append("','");
                sb.Append(dt.Rows[i][7].ToString());
                sb.Append("','");
                sb.Append(dt.Rows[i][8].ToString());
                sb.Append("','");
                sb.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                sb.Append("')");
                RunProcedureForNonQuery(sb.ToString(), null, strcon);
                sb.Clear();

            }
        }


        private void ImportSQLStore(string strFileName)
        {
            // string conn = "Server=10.10.6.237;Port=3306;Database=CRM_WeChat_9;Uid=root;Pwd=1;convert zero datetime=True;Allow User Variables=True;Connection Timeout=1000 ";
            // MySqlHelper dbhelp = new MySqlHelper(conn);

            string strcon = ConfigurationManager.AppSettings["sqlConn"];
            DataTable dt = null;
            SqlParameter p = new SqlParameter();
            //这个dt反正就是自己从数据库查出来，或者是自行组装的，就不多说  
            // dt = dbhelp.ExecuteDataTable("select  org_code,org_name from DIM_MANAGE_ORG_V", p); ;
            dt = OpenCSV(strFileName);//"C:\\GroupChange\\0.csv");
            if (dt.Columns.Count < 9)
            {
                return;
            }
            //Adding dummy entries  
            StringBuilder sb = new StringBuilder();
            //string sql = "Insert Into GAP0506 VALUES('";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sb.Append("Insert Into StoreInfo(SotreNameEN,CounterCode,StoreName) VALUES('");
                sb.Append(dt.Rows[i][0].ToString().Replace("'","''"));
                sb.Append("','");
                sb.Append(dt.Rows[i][1].ToString());
                sb.Append("','");
                sb.Append(dt.Rows[i][2].ToString());
                //sb.Append("',");
                //sb.Append(string.IsNullOrEmpty(dt.Rows[i][3].ToString()) == true ? "null" : dt.Rows[i][3].ToString());
                //sb.Append(",");
                //sb.Append(string.IsNullOrEmpty(dt.Rows[i][4].ToString()) == true ? "null" : dt.Rows[i][4].ToString());
                //sb.Append(",'");
                //sb.Append(dt.Rows[i][5].ToString());
                //sb.Append("','");
                //sb.Append(dt.Rows[i][6].ToString());
                //sb.Append("','");
                //sb.Append(dt.Rows[i][7].ToString());
                //sb.Append("','");
                //sb.Append(dt.Rows[i][8].ToString());
                //sb.Append("','");
                //sb.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                sb.Append("')");
                RunProcedureForNonQuery(sb.ToString(), null, strcon);
                sb.Clear();

            }
        }


        protected void FileUpload1_DataBinding(object sender, EventArgs e)
        {
            try
            {
                if (FileUpload1.PostedFile.FileName == "")
                {
                    Label1.Text = "要上传的文件不允许为空！";
                    return;
                }
                else
                {
                    string filepath = FileUpload1.PostedFile.FileName;//取文件路径
                    string filename = filepath.Substring(filepath.LastIndexOf("\\") + 1);//取文件名
                    string serverpath = Server.MapPath("File/") + filename;//合成上传路径
                    FileUpload1.PostedFile.SaveAs(serverpath);//上传文件
                    Label1.Text = "上传文件成功！";

                    string strFileName = "C:\\GroupChange\\0.xlsx";
                    DataTable dt = OpenCSV(strFileName);
                    gvList.DataSource = dt;
                    gvList.DataBind();
                }
            }
            catch (Exception error)
            {
                Label1.Text = "处理发生错误！原因：" + error.ToString();
            }
        }  

    }
}