/**  版本信息模板在安装目录下，可自行修改。
* SendSmsHis.cs
*
* 功 能： N/A
* 类 名： SendSmsHis
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/7/20 11:29:47   N/A    初版
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
	/// SendSmsHis:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SendSmsHis
	{
		public SendSmsHis()
		{}
		#region Model
		private int _id;
		private int? _actiontype;
		private string _destmobile;
		private string _sendcontent;
		private DateTime? _createtime;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ActionType
		{
			set{ _actiontype=value;}
			get{return _actiontype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DestMobile
		{
			set{ _destmobile=value;}
			get{return _destmobile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SendContent
		{
			set{ _sendcontent=value;}
			get{return _sendcontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}

        public string SendResult { get; set; }
		#endregion Model


	}
}

