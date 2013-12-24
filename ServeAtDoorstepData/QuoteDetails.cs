using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServeAtDoorstepData
{
    public class QuoteDetails
    {
        public int QuoteID { get; set; }
        public string QuoteTitle { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public int CategoryId { get; set; }
        public int ServiceId { get; set; }
        public int CustomerId { get; set; }
        public int CityId { get; set; }
        public string CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        
    }
}
