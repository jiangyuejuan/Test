/**  版本信息模板在安装目录下，可自行修改。
* StoreLoginInfo.cs
*
* 功 能： N/A
* 类 名： StoreLoginInfo
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
	/// StoreLoginInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class StoreLoginInfo
	{
		public StoreLoginInfo()
		{}
		#region Model
		private string _countercode;
		private string _pwd;
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
		public string PWD
		{
			set{ _pwd=value;}
			get{return _pwd;}
		}
		#endregion Model

	}
}

