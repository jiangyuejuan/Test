using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Zenga.Web
{
    public partial class VerifyInfo : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Init();
            }
        }

        private void Init()
        {
            string code = Request["voncher"];
            string storeCode = Request["Code"];
            try
            {
                Model.VIPCardInfo tempCard = dbHelper.mapper.QueryForObject<Model.VIPCardInfo>("VIPCardInfo.GetCardByCardCode", code);
                Model.VIPCardResult db = dbHelper.mapper.QueryForObject<Model.VIPCardResult>("VIPCardResult.GetByMemberCode", tempCard.MemberCode);
                Model.StoreInfo storeDB = dbHelper.mapper.QueryForObject<Model.StoreInfo>("StoreInfo.QueryStoreByCode", storeCode);
                Model.VIPCardInfo vipCard = dbHelper.mapper.QueryForObject<Model.VIPCardInfo>("VIPCardInfo.GetCardByMemberCode", tempCard.MemberCode);
            
                lblCardAmount.Text = vipCard.CardAmount;
                lblCardCode.Text = vipCard.CardCode;
                lblConsumeMoney.Text = db.ConsumeAmount.ToString();
                lblConsumeTime.Text = db.CreateTime.Value.ToString("yyyy-MM-dd hh:mm:ss");
                lblMemberCode.Text = db.MemberCode;
                lblMobile.Text = db.Mobile;
                lblName.Text = vipCard.MemberName;
                lblRemark.Text = db.Remark;
                lblStoreCode.Text = storeDB.CounterCode;
                lblStoreName.Text = storeDB.StoreName;

                txtCardCode.Text = vipCard.CardCode;
                txtCodeAmount.Text = vipCard.CardAmount;
                txtConsumeMoney.Text = db.ConsumeAmount.ToString();
                txtConsumeTime.Text = db.CreateTime.ToString();
                txtMemberCode.Text = db.MemberCode;
                txtMobile.Text = db.Mobile;
                txtName.Text = vipCard.MemberName;
                txtRemark.Value = db.Remark;
            }
            catch (Exception ex)
            {

            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //btnSave.Text = "修改信息";
            //HiddenField1.Value = "edit";
            try
            {
                string voncherCode = Request["voncher"];
                //string code = hidStoreCode.Value;
                Model.VIPCardInfo tempCard = dbHelper.mapper.QueryForObject<Model.VIPCardInfo>("VIPCardInfo.GetCardByCardCode", voncherCode);
                Model.VIPCardResult resultdb = dbHelper.mapper.QueryForObject<Model.VIPCardResult>("VIPCardResult.GetByMemberCode", tempCard.MemberCode);
                //Model.StoreInfo storeDB = dbHelper.mapper.QueryForObject<Model.StoreInfo>("StoreInfo.QueryStoreByCode", code);
                Model.VIPCardInfo vipCard = dbHelper.mapper.QueryForObject<Model.VIPCardInfo>("VIPCardInfo.GetCardByMemberCode", tempCard.MemberCode);

                Model.CancelInfo db = new Model.CancelInfo();
                db.CardAmount = vipCard.CardAmount.ToString();
                db.CardCode = vipCard.CardCode;
                db.CounterCode = resultdb.CounterCode;
                db.CreateTime = DateTime.Now;
                db.CustomerAmount = resultdb.ConsumeAmount.ToString();
                db.CustomerTime = resultdb.CreateTime;
                db.MemberCode = vipCard.MemberCode;
                db.MemberName = vipCard.MemberName;
                db.Mobile = vipCard.Mobile;
                db.Remark = resultdb.Remark;
                db.ActionRemark = "改单: 消费金额 "+ resultdb.ConsumeAmount +" -> " +txtConsumeMoney.Text.Trim();
                db.ActionType = 2;

                

                string money = txtConsumeMoney.Text.Trim();
                string remark = txtRemark.Value;
                Hashtable ht = new Hashtable();
                ht.Add("ConsumeAmount", txtConsumeMoney.Text.Trim());
                ht.Add("Remark", remark);
                ht.Add("UpdateTime", DateTime.Now);
                ht.Add("MemberCode", tempCard.MemberCode);

                try
                {
                    dbHelper.mapper.BeginTransaction();
                    dbHelper.mapper.Update("VIPCardResult.UpdateResult", ht);
                    dbHelper.mapper.Insert("CancelInfo.Insert", db);
                    AlertAndParentRedirect("修改成功", "VerifyList.aspx");
                    dbHelper.mapper.CommitTransaction();
                }
                catch (Exception ee)
                {
                    dbHelper.mapper.RollBackTransaction();
                    logger.Debug("" + this.GetType() + " >>>" + ee.Message);
                    Alert("修改失败");
                }
                
                
            }
            catch (Exception ex)
            {
                logger.Debug("" + this.GetType() + " >>>" + ex.Message);
                Alert("修改失败");
            }
            //Model.VIPCardResult dbCardResult = new Model.VIPCardResult();
            //dbCardResult.ConsumeAmount = Convert.ToDecimal(txtConsumeMoney.Text.Trim());
            //dbCardResult.CreateTime =Convert.ToDateTime(txtConsumeTime.Text.Trim());
            //dbCardResult.MemberCode = txtMemberCode.Text.Trim();
            //dbCardResult.Mobile = txtMobile.Text.Trim();
            //dbCardResult.Remark = txtRemark.Value;
            //dbCardResult.Status = 1;
            //dbCardResult.UpdateTime = DateTime.Now;
            //dbHelper.mapper.Update("VIPCardResult.Update", dbCardResult);
        }
    }
}