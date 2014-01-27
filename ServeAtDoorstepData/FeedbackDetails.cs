using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServeAtDoorstepData
{
    public class FeedbackDetails
    {

        public int FeedbackID { get; set; }
        public int CustomerId { get; set; }
        public int VendorId { get; set; }
        public string FeedbackTitle { get; set; }
        public string FeedbackDescription { get; set; }
        public string FeedbackStatus { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedOn { get; set; }
        public int CreatedBy { get; set; }
        
    }
}
