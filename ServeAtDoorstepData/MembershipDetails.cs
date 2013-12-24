using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServeAtDoorstepData
{
    public class MembershipDetails
    {
        public int MemberShipID { get; set; }
        public string MemberShipName { get; set; }
        public string MemberShipType { get; set; }
        public decimal MemberShipAmount { get; set; }
        public int MemberShipDays { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedOn { get; set; }
        public int CreatedBy { get; set; }
    }
}
