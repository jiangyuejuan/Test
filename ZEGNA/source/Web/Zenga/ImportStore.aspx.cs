using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zenga.Web.Code;

namespace Zenga.Web.Admin
{
    public partial class ImportStore : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Request.Cookies["User"] != null && Request.Cookies["User"].Value.Trim() != "admin")
            //{
            //    HyperLink1.Visible = false;
            //}
            //if (Request.Cookies["User"] != null && Request.Cookies["User"].Value.Trim() == "admin")
            //{
            //    hlinkHexiao.Visible = false;
            //}
        }

        protected void lbtnLogout_Click(object sender, EventArgs e)
        {
            Response.Cookies.Set(new HttpCookie("User", null));
            Response.Cookies.Set(new HttpCookie("StoreName", null));
            Response.Redirect("/login.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string strFullFilePath;
            if (FileUpload1.HasFile)
            {
                if (FileUpload1.FileName.ToLower().EndsWith(".xlsx"))
                {
                    string strName = StringUtil.GetFileNameNoType(FileUpload1.FileName);
                    strName = StringUtil.GenerateSaveFileName(strName);

                    strFullFilePath = Path.Combine(Server.MapPath("/upload"), strName);
                    FileUpload1.SaveAs(strFullFilePath);
                    ViewState["uploadXlsx"] = strFullFilePath;

                    //string strXlsConn = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;IMEX=1';", strFullFilePath);

                    string strXlsxConn = string.Format("provider=Microsoft.ACE.OLEDB.12.0;extended properties=excel 12.0;data source={0}", strFullFilePath);

                    OleDbConnection conn = new OleDbConnection(strXlsxConn);
                    string sql = "select * from [Sheet1$] ";
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    DataSet ds = new DataSet();
                    OleDbDataAdapter sda = new OleDbDataAdapter(cmd);
                    sda.Fill(ds);

                    gvList.DataSource = ds;
                    gvList.DataBind();
                    conn.Close();
                }
            }
        }

        public bool BulkEnterData(DataTable dt, string tblName)
        {
            dbHelper.mapper.Delete("StoreInfoTemp.Delete", null);

            string strcon = ConfigurationManager.AppSettings["sqlConn"];

            try
            {
                dbHelper.mapper.BeginTransaction();
                //delete storeinfo
                dbHelper.mapper.Delete("StoreInfo.Delete", null);
                SqlConnection con = new SqlConnection(strcon);

                SqlBulkCopy bulk = new SqlBulkCopy(con);
                bulk.DestinationTableName = tblName;

                con.Open();
                bulk.WriteToServer(dt);
                con.Close();

                //Import data into StoreInfo 
                dbHelper.mapper.Insert("StoreInfo.InsertBatch", null);

                //import login data
                dbHelper.mapper.Insert("StoreLoginInfo.InsertBatch", null);
                dbHelper.mapper.CommitTransaction();
                Alert("店铺导入成功");

            }
            catch (Exception ex)
            {
                dbHelper.mapper.RollBackTransaction();
                Alert("数据导入失败 : " + ex.Message.Replace("'","\'"));
            }

            return true;
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            if (ViewState["uploadXlsx"] == null)
            {
                Alert("请选择导入文件");
                return;
            }

            string strXlsxPath = ViewState["uploadXlsx"].ToString();

            string strXlsxConn = "provider=Microsoft.ACE.OLEDB.12.0;extended properties=excel 12.0;data source=" + strXlsxPath;

            OleDbConnection conn = new OleDbConnection(strXlsxConn);
            string sql = "select * from [Sheet1$] ";
            conn.Open();
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            DataSet ds = new DataSet();
            OleDbDataAdapter sda = new OleDbDataAdapter(cmd);
            sda.Fill(ds);

            conn.Close();

            BulkEnterData(ds.Tables[0], "StoreInfo");
        }
    }
}