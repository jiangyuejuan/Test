using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zenga.Web.Code;

namespace Zenga.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //DBHelper dbhelper = new DBHelper();
            //DataSet ds = dbhelper.QueryForDataSet("Admin.GetAll", null);
            //Response.Write(ds.Tables[0].Rows[0][0].ToString());
        }
    }
}