using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zenga.Model
{
    public class CancelInfo
    {

        /// <summary>
        /// CardCode
        /// </summary>		
        private string _cardcode;
        public string CardCode
        {
            get { return _cardcode; }
            set { _cardcode = value; }
        }
        /// <summary>
        /// CardAmount
        /// </summary>		
        private string _cardamount;
        public string CardAmount
        {
            get { return _cardamount; }
            set { _cardamount = value; }
        }
        /// <summary>
        /// CustomerTime
        /// </summary>		
        private DateTime? _customertime;
        public DateTime? CustomerTime
        {
            get { return _customertime; }
            set { _customertime = value; }
        }
        /// <summary>
        /// CounterCode
        /// </summary>		
        private string _countercode;
        public string CounterCode
        {
            get { return _countercode; }
            set { _countercode = value; }
        }
        /// <summary>
        /// MemberCode
        /// </summary>		
        private string _membercode;
        public string MemberCode
        {
            get { return _membercode; }
            set { _membercode = value; }
        }
        /// <summary>
        /// MemberName
        /// </summary>		
        private string _membername;
        public string MemberName
        {
            get { return _membername; }
            set { _membername = value; }
        }
        /// <summary>
        /// Mobile
        /// </summary>		
        private string _mobile;
        public string Mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }
        /// <summary>
        /// CustomerAmount
        /// </summary>		
        private string _customeramount;
        public string CustomerAmount
        {
            get { return _customeramount; }
            set { _customeramount = value; }
        }
        /// <summary>
        /// Remark
        /// </summary>		
        private string _remark;
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        /// <summary>
        /// CreateTime
        /// </summary>		
        private DateTime? _createtime;
        public DateTime? CreateTime
        {
            get { return _createtime; }
            set { _createtime = value; }
        }
        /// <summary>
        /// UpdateTime
        /// </summary>		
        private DateTime? _updatetime;
        public DateTime? UpdateTime
        {
            get { return _updatetime; }
            set { _updatetime = value; }
        }

        public string ActionRemark { get; set; }
        public int ActionType { get; set; }
    }
}

