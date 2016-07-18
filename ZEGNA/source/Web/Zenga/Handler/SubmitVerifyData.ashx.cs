using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zenga.Web.Code;
using Model = Zenga.Model;

namespace Zenga.Web.Handler
{
    /// <summary>
    /// Summary description for SubmitVerifyData
    /// </summary>
    public class SubmitVerifyData : IHttpHandler
    {
        DBHelper dbHelper = new DBHelper();
        Loger logger = new Loger();

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                logger.Instance.Debug( context.Request.Cookies["User"] == null);
                logger.Instance.Debug(context.Request.Cookies["User"].Value == "");
                logger.Instance.Info("" + context.Request.HttpMethod.ToUpper());
                if (context.Request.Cookies["User"] == null || context.Request.Cookies["User"].Value == "" || context.Request.HttpMethod.ToUpper() != "POST")
                {
                    logger.Instance.Info("111111");
                    return;
                }
                else
                {
                    string memberCode=context.Request.Form["customerCode"].ToString();
                    Model.VIPCardResult dbVip = dbHelper.mapper.QueryForObject<Model.VIPCardResult>("VIPCardResult.GetByMemberCode", memberCode);
                    if (dbVip != null)
                    {
                        context.Response.Write("该用户已核销过");
                    }
                    else
                    {
                        Model.VIPCardResult db = new Model.VIPCardResult();
                        db.CreateTime = Convert.ToDateTime(context.Request.Form["verifyTime"].ToString());
                        db.ConsumeAmount = Convert.ToDecimal(context.Request.Form["consumeAmount"].ToString());
                        db.CounterCode = context.Request.Cookies["User"].Value.ToString();
                        db.Mobile = context.Request.Form["vipMobile"].ToString();
                        db.Remark = context.Request.Form["remark"].ToString();
                        db.MemberCode = memberCode;
                        db.Status = 1;
                        db.UpdateTime = null;

                        dbHelper.mapper.Insert("VIPCardResult.Insert", db);

                        context.Response.Write("1");
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Instance.Debug("ex>>>" + ex.Message + " ====== " + ex.StackTrace );
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}