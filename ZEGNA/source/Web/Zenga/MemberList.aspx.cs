using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zenga.Web.Code;
using System.IO;

namespace Zenga.Web
{
    public partial class MemberList : BasePage
    {
        internal DBHelper dbHelper = new DBHelper();
        internal log4net.ILog logger = new Loger().Instance;
        DataTable dt = null;
        public bool IsCookieNullOrEmpy(string Name)
        {
            if (Request.Cookies[Name] == null || string.IsNullOrEmpty(Request.Cookies[Name].Value.ToString()))
                return true;
            else
                return false;
        }
        //protected void btnConfirm_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        long UserID = string.IsNullOrEmpty(Request["Code"]) == true ? 0 : Convert.ToInt64(Request["Code"]);
        //        if (UserID == 0) return;



        //        Model.MemberInfo db = new Model.MemberInfo();
        //        db.UserID = UserID;
        //        //db.ConfirmName = txtConfirmName.Text;
        //        //db.ConfirmMobile = Convert.ToInt64(txtConfirmMobile.Text);
        //        //db.InUserStore = txtInuseStore.Text;

        //        try
        //        {
        //            dbHelper.mapper.Update("MemberInfo.UpdateStatus", db);
        //            AlertAndParentRedirect("确认成功", "MemberList.aspx");
        //        }
        //        catch (Exception ee)
        //        {
        //            logger.Debug("" + this.GetType() + " >>>" + ee.Message);
        //            Alert("确认失败");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Debug("" + this.GetType() + " >>>" + ex.Message);
        //        Alert("确认失败");
        //    }

        //}


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlType.SelectedValue = "2";
                if (!IsCookieNullOrEmpy("User"))
                {
                    Init();
                }
                else
                {
                    Response.Redirect("/login.aspx");
                }

            }
            //if (Request.Cookies["User"] != null && Request.Cookies["User"].Value.Trim() != "admin")
            //{
            //    HyperLink1.Visible = false;
            //}
            //if (Request.Cookies["User"] != null && Request.Cookies["User"].Value.Trim() == "admin")
            //{
            //    hlinkHexiao.Visible = false;
            //}
        }


        private void Init()
        {
            string user = Request.Cookies["User"].Value;
            string strSql = "";
            Hashtable ht = new Hashtable();

            //if (user == "admin")
            //{
            //   // strSql = "MemberInfo.GetAll";              
            //}
  
            //else
            //{
            //    ht.Add("ManageStore", user);
            //   // strSql = "MemberInfo.QueryStoreByCode";             
            //}
            if (user != "admin")
            {
                ht.Add("ManageStore", user);
            }
            if (ddlType.SelectedValue != "2")
            {
                ht.Add("Status", ddlType.SelectedValue== "0"? false: true);
            }
            if (!string.IsNullOrEmpty(txtContent0.Text))
            {
                ht.Add("Mobile", Convert.ToInt64(txtContent0.Text));
            }
            strSql = "MemberInfo.QueryUserByFilter";

            dt = dbHelper.QueryForDataSet(strSql, ht).Tables[0];
            //Model.MemberInfo store = new 
            //Hashtable ht = new Hashtable();
            //ht.Add("CounterCode", user);
            //if (user == "admin")
            //{
            //    strSql = "MemberInfo.GetAll";
            //    dt = dbHelper.QueryForDataSet("MemberInfo.GetAll", null).Tables[0];
            //}
            //// = dbHelper.mapper.QueryForObject<Model.MemberInfo>("MemberInfo.QueryStoreByCode", user);
            //else
            //{
            //    strSql = "MemberInfo.QueryStoreByCode";
            //    dt = dbHelper.QueryForDataSet("MemberInfo.QueryStoreByCode", user).Tables[0];
            //}

            //Model.MemberInfo store = dbHelper.mapper.QueryForObject<Model.MemberInfo>("MemberInfo.QueryStoreByCode", user);
      //      Hashtable ht = new Hashtable();

            //string strSql = "";
            //if (store != null)
            //{
            //    strSql = "VIPCardResult.QueryAllByCardResultLinkCardInfo";
            //    ht.Add("CounterCode", user);
            //    dt = dbHelper.QueryForDataSet("VIPCardResult.QueryAllByCardResultLinkCardInfo", ht).Tables[0];
            //}
            //else
            //{
            //    strSql = "VIPCardResult.QueryAllByCardResultLinkCardInfo";
            //    dt = dbHelper.QueryForDataSet("VIPCardResult.QueryAllByCardResultLinkCardInfo", null).Tables[0];

            //}

            ////ViewState["Data"] = dt;
            //ViewState["HT"] = ht;
            ViewState["SQL"] = strSql;
            Bind(dt);
        }

        private void Bind(DataTable _dt)
        {
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = _dt.DefaultView;
            pds.AllowPaging = true;
            pds.PageSize = AspNetPager1.PageSize;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;

            AspNetPager1.RecordCount = pds.DataSourceCount;
            gvData.DataSource = pds;
            gvData.DataBind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            string user = Request.Cookies["User"].Value;
            string strSql = "";
            Hashtable ht = new Hashtable();
            if (user != "admin")
            {
                ht.Add("ManageStore", user);
            }
            if (ddlType.SelectedValue != "2")
            {
                ht.Add("Status", ddlType.SelectedValue == "0" ? false : true);
            }
            if (!string.IsNullOrEmpty(txtContent0.Text))
            {
                ht.Add("Mobile", Convert.ToInt64(txtContent0.Text));
            }
            strSql = "MemberInfo.QueryUserByFilter";

            dt = dbHelper.QueryForDataSet(strSql, ht).Tables[0];

          //  DataTable dt = dbHelper.QueryForDataSet(ViewState["SQL"].ToString(), Request.Cookies["User"].Value == "admin"? null: Request.Cookies["User"].Value).Tables[0];
  
            Bind(dt);
        }


        protected void lbtnLogout_Click(object sender, EventArgs e)
        {
            Response.Cookies.Set(new HttpCookie("User", null));
            Response.Cookies.Set(new HttpCookie("StoreName", null));
            Response.Redirect("/login.aspx");
        }

        protected void btnContentSearch_Click(object sender, EventArgs e)
        {
            string user = Request.Cookies["User"].Value;
            string strSql = "";
            Hashtable ht = new Hashtable();
            if (user != "admin")
            {
                ht.Add("ManageStore", user);
            }
            if (ddlType.SelectedValue != "2")
            {
                ht.Add("Status", ddlType.SelectedValue == "0" ? false : true);
            }
            if (!string.IsNullOrEmpty(txtContent0.Text))
            {
                ht.Add("Mobile", Convert.ToInt64(txtContent0.Text));
            }
            strSql = "MemberInfo.QueryUserByFilter";

            dt = dbHelper.QueryForDataSet(strSql, ht).Tables[0];
            Bind(dt);
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
          //  DataTable dt = dbHelper.QueryForDataSet(ViewState["SQL"].ToString(), (Hashtable)ViewState["HT"]).Tables[0];

            string user = Request.Cookies["User"].Value;
            string strSql = "";
            Hashtable ht = new Hashtable();
            if (user != "admin")
            {
                ht.Add("ManageStore", user);
            }
            if (ddlType.SelectedValue != "2")
            {
                ht.Add("Status", ddlType.SelectedValue == "0" ? false : true);
            }
            if (!string.IsNullOrEmpty(txtContent0.Text))
            {
                ht.Add("Mobile", Convert.ToInt64(txtContent0.Text));
            }
            strSql = "MemberInfo.QueryUserByFilterExport";

            dt = dbHelper.QueryForDataSet(strSql, ht).Tables[0];
            //DataTable exportDT = (DataTable)ViewState["Data"];
            MemoryStream ms = ExportDT.ExportDTI(dt);
            if (ms != null)
            {

                Response.AddHeader("Content-Disposition", string.Format("attachment;filename=" + HttpUtility.UrlEncode("data") + DateTime.Now.ToString("yyyyMMdd") + ".xlsx"));
                Response.AddHeader("Content-Length", ms.ToArray().Length.ToString());
                Response.ContentType = "application/ms-excel";
                Response.BinaryWrite(ms.ToArray());
                Response.Flush();
                ms.Close();
                ms.Dispose();
            }
            else
            {

                Alert("数据错误，请稍后再试");
            }
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //var status = ddlType.SelectedValue;
            //if (status != "2")
            //{             
            //}
            string user = Request.Cookies["User"].Value;
            string strSql = "";
            Hashtable ht = new Hashtable();
            if (user != "admin")
            {
                ht.Add("ManageStore", user);
            }
            if (ddlType.SelectedValue != "2")
            {
                ht.Add("Status", ddlType.SelectedValue == "0" ? false : true);
            }
            if (!string.IsNullOrEmpty(txtContent0.Text))
            {
                ht.Add("Mobile", Convert.ToInt64(txtContent0.Text));
            }
            strSql = "MemberInfo.QueryUserByFilter";

            dt = dbHelper.QueryForDataSet(strSql, ht).Tables[0];
            Bind(dt);
        }

        protected void txtContent0_TextChanged(object sender, EventArgs e)
        {
           // if(Char.IsNumber(txtContent0.Text)&& )
        }

        protected void gvData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "确认提交")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                // string scrapid = commandArgs[0]; //传递参数1
                long UserID = Convert.ToInt64(commandArgs[0]);//传递参数2
                try
                {
                    //long UserID = string.IsNullOrEmpty(Request["Code"]) == true ? 0 : Convert.ToInt64(Request["Code"]);
                    //if (UserID == 0) return;

                    Model.MemberInfo db = new Model.MemberInfo();
                    db.UserID = UserID;
                    //db.ConfirmName = txtConfirmName.Text;
                    //db.ConfirmMobile = Convert.ToInt64(txtConfirmMobile.Text);
                    //db.InUserStore = txtInuseStore.Text;

                    try
                    {
                        dbHelper.mapper.Update("MemberInfo.UpdateStatus", db);
                        AlertAndParentRedirect("确认成功", "MemberList.aspx");
                    }
                    catch (Exception ee)
                    {
                        logger.Debug("" + this.GetType() + " >>>" + ee.Message);
                        Alert("确认失败");
                    }
                }
                catch (Exception ex)
                {
                    logger.Debug("" + this.GetType() + " >>>" + ex.Message);
                    Alert("确认失败");
                }
            }
            else if (e.CommandName == "修改")
            {
                string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
                // string scrapid = commandArgs[0]; //传递参数1
                long UserID = Convert.ToInt64(commandArgs[0]);//传递参数2
                Response.Redirect("MemberInfoNew.aspx?Code=" + UserID.ToString());
            }
        }
    }

}