using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Zenga.Web
{
    public partial class ModifyPwd : BasePage
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
            Response.Cookies.Set(new HttpCookie("User",null));
            Response.Cookies.Set(new HttpCookie("StoreName", null));
            Response.Redirect("/login.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string oldPwd = txtOldPwd.Text.Trim();
                string newPwd = txtNewPwd.Text.Trim();
                string comfirmPwd = txtComfirmPwd.Text.Trim();
                string user = Request.Cookies["User"].Value;
                if (newPwd != comfirmPwd)
                {
                    Alert("新密码与确认密码必须一致");
                }
                else
                {
                    if (user != "admin" && user != "")
                    {
                        Model.StoreLoginInfo login = dbHelper.mapper.QueryForObject<Model.StoreLoginInfo>("StoreLoginInfo.QueryByUser", user);
                        if (login.PWD != oldPwd)
                        {
                            Alert("旧密码不正确");
                        }
                        else
                        {
                            login.PWD = newPwd;
                            dbHelper.mapper.Update("StoreLoginInfo.Update", login);
                            Alert("更新成功");
                        }
                    }
                    else if (user == "admin")
                    {
                        Model.Admin admin = dbHelper.mapper.QueryForObject<Model.Admin>("Admin.QueryByUser", user);
                        if (admin.PWD != oldPwd)
                        {
                            Alert("旧密码不正确");
                        }
                        else
                        {
                            admin.PWD = newPwd;
                            dbHelper.mapper.Update("Admin.Update", admin);
                            Alert("更新成功");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Alert("系统错误，请稍后再试");
            }
        }
    }
}