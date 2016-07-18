using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Zenga.Web
{
    public partial class VerifyList : BasePage
    {
        DataTable dt = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
            Model.StoreInfo store = dbHelper.mapper.QueryForObject<Model.StoreInfo>("StoreInfo.QueryStoreByCode", user);
            Hashtable ht = new Hashtable();

            string strSql = "";
            if (store != null)
            {
                strSql = "VIPCardResult.QueryAllByCardResultLinkCardInfo";
                ht.Add("CounterCode", user);
                dt = dbHelper.QueryForDataSet("VIPCardResult.QueryAllByCardResultLinkCardInfo", ht).Tables[0];
            }
            else
            {
                strSql = "VIPCardResult.QueryAllByCardResultLinkCardInfo";
                dt = dbHelper.QueryForDataSet("VIPCardResult.QueryAllByCardResultLinkCardInfo", null).Tables[0];

            }

            //ViewState["Data"] = dt;
            ViewState["HT"] = ht;
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

        protected void btnContentSearch_Click(object sender, EventArgs e)
        {
            string type = ddlType.SelectedItem.Value;
            string content = txtContent.Text.Trim().Replace("'", "");
            string user = Request.Cookies["User"].Value;
            Hashtable ht = new Hashtable();
            string strSQL = "";
            Model.StoreInfo store = dbHelper.mapper.QueryForObject<Model.StoreInfo>("StoreInfo.QueryStoreByCode", user);
            if (store != null)
            {
                ht.Add("StoreName", store.StoreName);
                ht.Add("CounterCode", Request.Cookies["User"].Value);
            }
            switch (type)
            {
                case "0"://姓名
                    ht.Add("Name", content);
                    strSQL = "VIPCardResult.QueryResultByName";
                    dt = dbHelper.QueryForDataSet("VIPCardResult.QueryResultByName", ht).Tables[0];
                    break;
                case "1"://手机
                    ht.Add("Mobile", content);
                    strSQL = "VIPCardResult.QueryResultByMobile";
                    dt = dbHelper.QueryForDataSet("VIPCardResult.QueryResultByMobile", ht).Tables[0];
                    break;
                case "2"://code
                    ht.Add("CardCode", content);
                    strSQL = "VIPCardResult.QueryResultByCardCode";
                    dt = dbHelper.QueryForDataSet("VIPCardResult.QueryResultByCardCode", ht).Tables[0];
                    break;
            };
            //ViewState["Data"] = dt;
            ViewState["HT"] = ht;
            ViewState["SQL"] = strSQL;
            Bind(dt);
        }

        protected void btnTimeSearch_Click(object sender, EventArgs e)
        {
            string[] times = reservation.Text.Trim().Split('~');
            string user = Request.Cookies["User"].Value;
            Hashtable ht = new Hashtable();
            Model.StoreInfo store = dbHelper.mapper.QueryForObject<Model.StoreInfo>("StoreInfo.QueryStoreByCode", user);
            if (store != null)
            {
                ht.Add("StoreName", store.StoreName);
            }
            if (times.Length > 1)
            {
                string beginTime = times[0] + " 00:00:00";
                string endTime = times[1] + " 23:59:59";
                ht.Add("BeginTime", beginTime);
                ht.Add("EndTime", endTime);
                dt = dbHelper.QueryForDataSet("VIPCardResult.QueryResultByTime", ht).Tables[0];
                ViewState["HT"] = ht;
                ViewState["SQL"] = "VIPCardResult.QueryResultByTime";
                //ViewState["Data"] = dt;
                Bind(dt);
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataTable dt = dbHelper.QueryForDataSet(ViewState["SQL"].ToString(), (Hashtable)ViewState["HT"]).Tables[0];

            //DataTable exportDT = (DataTable)ViewState["Data"];
            MemoryStream ms = ExportDT.ExportDTI(dt);
            if (ms != null)
            {

                Response.AddHeader("Content-Disposition", string.Format("attachment;filename=" + HttpUtility.UrlEncode("data") + DateTime.Now.ToString("yyyyMMdd") + ".xlsx"));
                Response.AddHeader("Content-Length", ms.ToArray().Length.ToString());
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

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            DataTable dt = dbHelper.QueryForDataSet(ViewState["SQL"].ToString(), (Hashtable)ViewState["HT"]).Tables[0];
            //DataTable bindDT = (DataTable)ViewState["Data"];
            Bind(dt);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //Alert(hidMemberCode.Value+hidStoreCode.Value);
            try
            {
                string voncherCode = hidMemberCode.Value;
                string code = hidStoreCode.Value;
                Model.VIPCardInfo tempCard = dbHelper.mapper.QueryForObject<Model.VIPCardInfo>("VIPCardInfo.GetCardByCardCode", voncherCode);
                Model.VIPCardResult resultdb = dbHelper.mapper.QueryForObject<Model.VIPCardResult>("VIPCardResult.GetByMemberCode", tempCard.MemberCode);
                Model.StoreInfo storeDB = dbHelper.mapper.QueryForObject<Model.StoreInfo>("StoreInfo.QueryStoreByCode", code);
                Model.VIPCardInfo vipCard = dbHelper.mapper.QueryForObject<Model.VIPCardInfo>("VIPCardInfo.GetCardByMemberCode", tempCard.MemberCode);
                Model.CancelInfo db = new Model.CancelInfo();
                db.CardAmount = vipCard.CardAmount.ToString();
                db.CardCode = vipCard.CardCode;
                db.CounterCode = code;
                db.CreateTime = DateTime.Now;
                db.CustomerAmount = resultdb.ConsumeAmount.ToString();
                db.CustomerTime = resultdb.CreateTime;
                db.MemberCode = vipCard.MemberCode;
                db.MemberName = vipCard.MemberName;
                db.Mobile = vipCard.Mobile;
                db.Remark = resultdb.Remark;
                db.ActionRemark = null;
                db.ActionType = 1;

                try
                {
                    dbHelper.mapper.BeginTransaction();
                    dbHelper.mapper.Insert("CancelInfo.Insert", db);
                    dbHelper.mapper.Delete("VIPCardResult.RemoveByCode", tempCard.MemberCode);
                    AlertAndRedirect("退单成功", "VerifyList.aspx");
                    dbHelper.mapper.CommitTransaction();
                }
                catch (Exception ex2)
                {
                    logger.Debug("" + this.GetType() + "  >>" + ex2.Message);
                    dbHelper.mapper.RollBackTransaction();
                    Alert("退单失败");
                }


            }
            catch (Exception ex)
            {
                logger.Debug("" + this.GetType() + "  >>" + ex.Message);
                Alert("退单失败");
            }
        }

        protected void lbtnLogout_Click(object sender, EventArgs e)
        {
            Response.Cookies.Set(new HttpCookie("User", null));
            Response.Cookies.Set(new HttpCookie("StoreName", null));
            Response.Redirect("/login.aspx");
        }

        protected void gvData_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

    }
}