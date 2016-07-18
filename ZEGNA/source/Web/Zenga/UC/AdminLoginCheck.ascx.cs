using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Zenga.Web.UC
{
    public partial class AdminLoginCheck : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["User"] == null || Request.Cookies["User"].Value.Trim() == "")
            {
                Response.Redirect("/Login.aspx");
            }
        }
    }
}