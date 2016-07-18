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
    public partial class MemberInfoNew :  BasePage
    {

        public bool IsCookieNullOrEmpy(string Name)
        {
            if (Request.Cookies[Name] == null || string.IsNullOrEmpty(Request.Cookies[Name].Value.ToString()))
                return true;
            else
                return false;
        }

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

            if (!IsPostBack)
            {
                Init();
            }

        }

        private void Init()
        {
            long UserID = string.IsNullOrEmpty(Request["Code"]) == true ? 0 : Convert.ToInt64(Request["Code"]);
            if (UserID == 0) return;
            try
            {
                DataTable dt = null;
                dt = dbHelper.QueryForDataSet("MemberInfo.GetStoreInfo", null).Tables[0];
                DropDownList1.DataSource = dt.DefaultView;
                DropDownList1.DataValueField = dt.Columns[0].ColumnName;
                DropDownList1.DataTextField = dt.Columns[1].ColumnName;
                DropDownList1.DataBind();

                Model.MemberInfo db = dbHelper.mapper.QueryForObject<Model.MemberInfo>("MemberInfo.QueryUserByMemberCode", UserID);
                lblMemberCode.Text = db.UserID.ToString();
                lblMobile.Text = db.Mobile.ToString();
                lblName.Text = db.Name;
                lblConfirmName.Text = db.ConfirmName;
                lblRemark.Text = db.Remark;
                lblManageStore.Text = db.ManageStore;
                lblAmount.Text = Convert.ToInt32(db.Amount).ToString("D"); 
                lblInuseStore.Text = db.InUserStore;
                txtAmount.Text = Convert.ToInt32(db.Amount.GetValueOrDefault()).ToString("D");
                DropDownList1.SelectedValue = db.InUserStore; 
                lblConfirmMobile.Text = db.ConfirmMobile ?? "";
                txtMemberCode.Text = db.UserID.ToString();

                txtName.Text = db.Name;
                txtConfirmName.Text = db.ConfirmName;
                txtMobile.Text = db.Mobile.ToString();
                txtConfirmMobile.Text = db.ConfirmMobile ?? "";
                txtManageStore.Text = db.ManageStore;
                txtRemark.Text = db.Remark;
            }
            catch (Exception ex)
            {

            }
        }

        protected void lbtnLogout_Click(object sender, EventArgs e)
        {
            Response.Cookies.Set(new HttpCookie("User", null));
            Response.Cookies.Set(new HttpCookie("StoreName", null));
            Response.Redirect("/login.aspx");
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            //btnSave.Text = "修改信息";
            //HiddenField1.Value = "edit";
            if (!IsValid) return;
            try
            {
                long UserID = string.IsNullOrEmpty(Request["Code"]) == true ? 0 : Convert.ToInt64(Request["Code"]);
                if (UserID == 0) return;

                Model.MemberInfo db = new Model.MemberInfo();
                db.UserID = UserID;
                db.ConfirmName = txtConfirmName.Text;
                if (string.IsNullOrEmpty(txtConfirmMobile.Text))
                {
                    db.ConfirmMobile = null;
                }
                else
                {
                    try
                    {
                        db.ConfirmMobile = txtConfirmMobile.Text;
                        Hashtable ht = new Hashtable();
                        ht.Add("UserID", db.UserID);
                        ht.Add("mobile", db.ConfirmMobile);
                        Model.MemberInfo member = dbHelper.mapper.QueryForObject<Model.MemberInfo>("MemberInfo.QueryUserMobile", ht);
                        if (member != null)
                        {
                            Alert("该手机已存在，请重新输入");
                            return;
                        }
                    }
                    catch (Exception)
                    {
                        Alert("请输入正确的格式的手机号");
                        return;
                    }

                }

                db.InUserStore = DropDownList1.SelectedValue;
                db.Remark = txtRemark.Text;
                lblRemark.Text = db.Remark;
                lblAmount.Text = Convert.ToInt32(db.Amount.GetValueOrDefault()).ToString("D");
                lblInuseStore.Text = db.InUserStore;
                lblConfirmMobile.Text = txtConfirmMobile.Text;
                lblConfirmName.Text = txtConfirmName.Text;
                try
                {
                    dbHelper.mapper.Update("MemberInfo.Update", db);
                    AlertAndParentRedirect("修改成功", "MemberList.aspx");
                }
                catch (Exception ee)
                {
                    logger.Debug("" + this.GetType() + " >>>" + ee.Message);
                    Alert("修改失败");
                }
            }
            catch (Exception ex)
            {
                logger.Debug("" + this.GetType() + " >>>" + ex.Message);
                Alert("修改失败");
            }

        }
    }
}