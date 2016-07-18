using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zenga.Model
{
    [Serializable]
    public partial class MemberInfo
    {
        public MemberInfo()
        { }

        public long UserID { get; set; }
        public string Name { get; set; }
        public string ConfirmName { get; set; }
        public string Mobile { get; set; }
        public string ConfirmMobile { get; set; }
        public string ManageStore { get; set; }
        public string InUserStore { get; set; }
        public decimal? Amount { get; set; }
        public string Remark { get; set; }
        public DateTime CreateTime { get; set; }
        public bool Status { get; set; }
    }


}
