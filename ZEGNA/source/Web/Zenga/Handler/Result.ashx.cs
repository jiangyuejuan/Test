using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zenga.Web.Code;

namespace Zenga.Web.Handler
{
    /// <summary>
    /// Summary description for Result
    /// </summary>
    public class Result : IHttpHandler
    {
        Loger logger = new Loger();
        DBHelper dbHelper = new DBHelper();

        public void ProcessRequest(HttpContext context)
        {
            logger.Instance.Debug("Result>>>ProcessRequest");
            if (context.Request.HttpMethod.ToUpper() == "POST" && context.Request.Cookies["User"] != null && context.Request.Cookies["User"].Value != "")
            {
                SmsService.SMSServiceSoapClient client = new SmsService.SMSServiceSoapClient("SMSServiceSoap");
                //"code": code, "VipName": $("#lblVipName").text(), "ConsumeAmount": $("#lblConsumeAmount").text(), "ShopName": $("#lblShopName").text()

                //old: 尊敬的{0},感谢您光临{1}。您的尊享券{2}已使用，共消费{3}元。期待您下次光临。
                //new :尊敬的[[name]],感谢您光临[[store]]。您的尊享券[[code]]已与[[date]]在[[store]]使用。如有疑问，请咨询门店，电话[[店铺电话]]。

                string strCounterCode = context.Request["CounterCode"];
                Model.StoreInfo dbStoreInfo = dbHelper.mapper.QueryForObject<Model.StoreInfo>("StoreInfo.QueryStoreByCode", strCounterCode);

                string strContent = string.Format("尊敬的{0},感谢您光临{1}。您的尊享券{2}已与{3}在{4}使用。如有疑问，请咨询门店，电话{5}。", context.Request["VipName"], context.Request["ShopName"], context.Request["code"], context.Request["date"], context.Request["ShopName"], dbStoreInfo.StorePhone); //,context.Request["ConsumeAmount"]);
                logger.Instance.Debug(strContent + ">>>" + context.Request["mobile"]);
                string result = client.SendSMS(context.Request["mobile"], 40, strContent, DateTime.Now.AddYears(-1), "7100300630108194");

                Model.SendSmsHis dbSendSmsHis = new Model.SendSmsHis
                {
                    ActionType = 2,
                    CreateTime = DateTime.Now,
                    DestMobile = context.Request["mobile"],
                    SendContent = strContent,
                    SendResult = result
                };
                dbHelper.mapper.Insert("SendSmsHis.Insert", dbSendSmsHis);

                logger.Instance.Debug("sms >>> " + result);
                context.Response.Write(result);
            }
            else
                logger.Instance.Debug("eelse");
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