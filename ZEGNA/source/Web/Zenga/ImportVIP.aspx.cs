using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Zenga.Web
{
    public partial class ImportVIP : System.Web.UI.Page
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }
    }
}