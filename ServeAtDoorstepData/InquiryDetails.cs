using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServeAtDoorstepData
{
    public class InquiryDetails
    {
        public int InquiryID { get; set; }
        public string InquiryTitle { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public int CategoryId { get; set; }
        public int ServiceId { get; set; }
        public int CustomerId { get; set; }
        public int CityId { get; set; }
        public string ImagePath { get; set; }
        public string VideoPath { get; set; }
        public string CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        
    }
}
