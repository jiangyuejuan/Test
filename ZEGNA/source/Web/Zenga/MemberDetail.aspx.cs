using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace Zenga.Web
{
    public partial class MemberDetail : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && IsQueryStringNullOrEmpty("code")==false)
            {
                Model.VIPCardResult db = dbHelper.mapper.QueryForObject<Model.VIPCardResult>("VIPCardResult.GetByCode", Request["code"]);
                Model.VIPCardInfo dbCardInfo = dbHelper.mapper.QueryForObject<Model.VIPCardInfo>("VIPCardInfo.FindOne", Request["code"]) ;
                Model.StoreInfo dbStore = dbHelper.mapper.QueryForObject<Model.StoreInfo>("StoreInfo.QueryStoreByVerifyCardCode", Request["code"]);

                lblVoucherCode.Text = dbCardInfo.CardCode;
                lblConsumeAmount.Text = db.ConsumeAmount.ToString();
                lblCounterCode.Text = db.CounterCode;
                lblCustomerCode.Text = dbCardInfo.MemberCode;
                lblRemark.Text = db.Remark;
                lblShopName.Text = dbStore.StoreName;
                lblVerifyTime.Text = db.CreateTime.Value.ToString("yyyy-MM-dd hh:mm:ss");
                lblVipMobile.Text = db.Mobile;
                lblVipName.Text = dbCardInfo.MemberName;
                lblVoucherFaceAmount.Text = dbCardInfo.CardAmount;

            }
            //if (Request.Cookies["User"] != null && Request.Cookies["User"].Value.Trim() != "admin")
            //{
            //    HyperLink1.Visible = false;
            //}
        }

        protected void lbtnLogout_Click(object sender, EventArgs e)
        {
            Response.Cookies.Set(new HttpCookie("User", null));
            Response.Cookies.Set(new HttpCookie("StoreName", null));
            Response.Redirect("/login.aspx");
        }
    }
}