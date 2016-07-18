/**  版本信息模板在安装目录下，可自行修改。
* VIPCardResult.cs
*
* 功 能： N/A
* 类 名： VIPCardResult
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/7/20 11:29:51   N/A    初版
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
	/// VIPCardResult:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class VIPCardResult
	{
		public VIPCardResult()
		{}
		#region Model
		private string _mobile;
		private string _countercode;
		private int? _status;
		private decimal? _consumeamount;
		private string _remark;
		private DateTime? _createtime;
		private DateTime? _updatetime;
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
		public string CounterCode
		{
			set{ _countercode=value;}
			get{return _countercode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? ConsumeAmount
		{
			set{ _consumeamount=value;}
			get{return _consumeamount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UpdateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		#endregion Model

        public string MemberCode { get; set; }
	}
}

