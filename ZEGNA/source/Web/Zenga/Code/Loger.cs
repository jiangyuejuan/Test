using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Zenga.Web.Code
{
    public class Loger : System.Web.UI.Page
    {
        public log4net.ILog Instance = null;

        public Loger()
        {
            Instance = GetLoger("");
        }

        public Loger(string s)
        {
            //FileInfo fi = new FileInfo(System.Web.HttpContext.Current.Server.MapPath("/config/log4net.config"));
            FileInfo fi = new FileInfo(Server.MapPath("/config/log4net.config"));
            log4net.Config.XmlConfigurator.Configure(fi);

            Instance = log4net.LogManager.GetLogger(s);

        }

        public log4net.ILog GetLoger(string s)
        {
            //FileInfo fi = new FileInfo(System.Web.HttpContext.Current.Server.MapPath("/config/log4net.config"));
            FileInfo fi = new FileInfo(Server.MapPath("/config/log4net.config"));
            log4net.Config.XmlConfigurator.Configure(fi);

            log4net.ILog logger = log4net.LogManager.GetLogger(s);

            return logger;
        }
    }
}