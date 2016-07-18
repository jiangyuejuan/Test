/**  版本信息模板在安装目录下，可自行修改。
* VIPCardInfoTemp.cs
*
* 功 能： N/A
* 类 名： VIPCardInfoTemp
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/7/20 11:29:48   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Zenga.Model
{
	/// <summary>
	/// VIPCardInfoTemp:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class VIPCardInfoTemp
	{
		public VIPCardInfoTemp()
		{}
		#region Model
		private string _mobile;
		private string _customercode;
		private string _membercode;
		private string _membername;
		private string _cardcode;
		private string _cardamount;
		private string _storename;
		private string _storephone;
		/// <summary>
		/// 
		/// </summary>
		public string Mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CustomerCode
		{
			set{ _customercode=value;}
			get{return _customercode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MemberCode
		{
			set{ _membercode=value;}
			get{return _membercode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MemberName
		{
			set{ _membername=value;}
			get{return _membername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CardCode
		{
			set{ _cardcode=value;}
			get{return _cardcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CardAmount
		{
			set{ _cardamount=value;}
			get{return _cardamount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StoreName
		{
			set{ _storename=value;}
			get{return _storename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StorePhone
		{
			set{ _storephone=value;}
			get{return _storephone;}
		}
		#endregion Model

        public string CounterCode { get; set; }
	}
}

