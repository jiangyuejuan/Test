using System;
namespace Zenga.Model
{
    /// <summary>
    /// StoreInfo:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class StoreInfo
    {
        public StoreInfo()
        { }
        #region Model
        private string _city;
        private string _countercode;
        private string _storename;
        private string _sotrenameen;
        private string _stoptype;
        private string _storeaddr;
        private string _storephone;
        private string _storemasterphone;
        private string _storemastername;
        /// <summary>
        /// 
        /// </summary>
        public string City
        {
            set { _city = value; }
            get { return _city; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CounterCode
        {
            set { _countercode = value; }
            get { return _countercode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StoreName
        {
            set { _storename = value; }
            get { return _storename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SotreNameEN
        {
            set { _sotrenameen = value; }
            get { return _sotrenameen; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StopType
        {
            set { _stoptype = value; }
            get { return _stoptype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StoreAddr
        {
            set { _storeaddr = value; }
            get { return _storeaddr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StorePhone
        {
            set { _storephone = value; }
            get { return _storephone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StoreMasterPhone
        {
            set { _storemasterphone = value; }
            get { return _storemasterphone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StoreMasterName
        {
            set { _storemastername = value; }
            get { return _storemastername; }
        }
        #endregion Model

    }
}

