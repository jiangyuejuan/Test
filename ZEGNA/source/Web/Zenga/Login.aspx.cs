using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Zenga.Web
{
    public partial class Login : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string pwd = txtPwd.Text.Trim();
            Hashtable ht=new Hashtable();
            ht.Add("UserName", username);
            ht.Add("Pwd", pwd);
            Model.Admin admin=  dbHelper.mapper.QueryForObject<Model.Admin>("Admin.QueryUser", ht);
            Model.StoreLoginInfo storeLogin = dbHelper.mapper.QueryForObject<Model.StoreLoginInfo>("StoreLoginInfo.QueryByLogin", ht);
            if (admin != null || storeLogin != null)
            {
                if (admin != null)
                {
                    Response.Cookies["User"].Value = "admin";
                    Response.Cookies["User"].Expires = DateTime.Now.AddDays(1);
                    Response.Cookies["StoreName"].Value = "";
                    Response.Cookies["StoreName"].Expires = DateTime.Now.AddDays(1);
                    Response.Cookies["StoreType"].Value = "";
                    Response.Cookies["StoreType"].Expires = DateTime.Now.AddDays(1);
                }
                else
                {
                    Model.StoreInfo store = dbHelper.mapper.QueryForObject<Model.StoreInfo>("StoreInfo.QueryStoreByCode", storeLogin.CounterCode);

                    Response.Cookies["User"].Value = Server.UrlEncode(storeLogin.CounterCode);
                    Response.Cookies["User"].Expires = DateTime.Now.AddDays(1);
                    Response.Cookies["StoreName"].Value = Server.UrlEncode(store.SotreNameEN);
                    Response.Cookies["StoreName"].Expires = DateTime.Now.AddDays(1);
                    Response.Cookies["StoreType"].Value = Server.UrlDecode(store.StopType);
                    Response.Cookies["StoreType"].Expires = DateTime.Now.AddDays(1);
                }
               // AlertAndRedirect("登录成功", "VerifyList.aspx");
                AlertAndRedirect("登录成功", "MemberList.aspx");
            }
            else
            {
                Alert("您输入的账号或密码错误，请重新输入");
            }
        }
    }
}