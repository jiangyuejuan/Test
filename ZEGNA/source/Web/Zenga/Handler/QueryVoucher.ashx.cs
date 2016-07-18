using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Zenga.Web.Code;
using Model = Zenga.Model;

namespace Zenga.Web.Handler
{
    /// <summary>
    /// Summary description for QueryVoucher
    /// </summary>
    public class QueryVoucher : IHttpHandler
    {
        DBHelper dbHelper = new DBHelper();
        Loger logger = new Loger();
        JavaScriptSerializer js = new JavaScriptSerializer();

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                logger.Instance.Info("112233");
                if (context.Request.HttpMethod.ToUpper() == "POST")
                {
                    string strVoucherCode = context.Request.Form["code"].ToString();
                    logger.Instance.Info("strVoucherCode >> " + strVoucherCode);
                    Model.VIPCardResult db = dbHelper.mapper.QueryForObject<Model.VIPCardResult>("VIPCardResult.GetByCode", strVoucherCode);
                    Model.VIPCardInfo dbCardInfo = dbHelper.mapper.QueryForObject<Model.VIPCardInfo>("VIPCardInfo.FindOne", strVoucherCode);
                    Model.StoreInfo dbStoreInfo = dbHelper.mapper.QueryForObject<Model.StoreInfo>("StoreInfo.QueryStoreByCode", dbCardInfo.CounterCode);
                    VipCard vipCardResult = new VipCard
                    {
                        vipCardInfo = dbCardInfo,
                        vipCardResult = db,
                        VerifyStoreInfo = dbStoreInfo
                    };
                    
                    //logger.Instance.Debug("db.mobile=" + db.Mobile);
                    logger.Instance.Debug("js >>> " + js.Serialize(vipCardResult));
                    context.Response.Write(js.Serialize(vipCardResult));
                }
                else
                {
                    logger.Instance.Info("eeelllse");
                    return;
                }
            }
            catch (Exception ex)
            {
                logger.Instance.Debug( ex.Message+ " " + ex.StackTrace);
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
    class VipCard {
        public Model.VIPCardInfo vipCardInfo { get; set; }
        public Model.VIPCardResult vipCardResult { get; set; }
        public Model.StoreInfo VerifyStoreInfo { get; set; }

    }
}