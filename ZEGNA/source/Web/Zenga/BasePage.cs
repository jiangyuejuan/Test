using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Configuration;
//using System.Web.Script.Serialization;


using System.Web.Configuration;
using Zenga.Web.Code;
using Model = Zenga.Model;


namespace Zenga.Web
{
    public class BasePage : System.Web.UI.Page
    {
        internal DBHelper dbHelper = new DBHelper();
        internal log4net.ILog logger = new Loger().Instance;

        //static public readonly string[] ValidPicType = WebConfigurationManager.AppSettings["ValidPic"].ToString().Split(',');


        public void Alert(string strMsg)
        {
            ClientScript.RegisterClientScriptBlock(new Page().GetType(), "", "<script language='javascript'>alert('" + strMsg + "')</script>");
        }

        public void AlertAndRefresh(string strMsg)
        {
            ClientScript.RegisterClientScriptBlock(new Page().GetType(), "", "<script language='javascript'>alert('" + strMsg + "');window.location.href = window.location.href;</script>");
        }

        public void AlertAndRedirect(string strMsg, string TargetURL)
        {
            ClientScript.RegisterClientScriptBlock(new Page().GetType(), "", "<script language='javascript'>alert('" + strMsg + "');window.location.href = '" + TargetURL + "';</script>");
        }

        public void AlertAndParentRedirect(string strMsg, string TargetURL)
        {
            ClientScript.RegisterClientScriptBlock(new Page().GetType(), "", "<script language='javascript'>alert('" + strMsg + "');window.parent.location.href = '" + TargetURL + "';</script>");
        }


        public bool IsQueryStringNullOrEmpty(string Name)
        {
            if (Request.QueryString[Name] == null || string.IsNullOrEmpty(Request.QueryString[Name].ToString()))
                return true;
            else
                return false;
        }

        public bool IsFormNullOrEmpty(string Name)
        {
            if (Request.Form[Name] == null || string.IsNullOrEmpty(Request.Form[Name].ToString()))
                return true;
            else
                return false;
        }

        public bool IsCookieNullOrEmpy(string Name)
        {
            if (Request.Cookies[Name] == null || string.IsNullOrEmpty(Request.Cookies[Name].Value.ToString()))
                return true;
            else
                return false;
        }

      
    }
}