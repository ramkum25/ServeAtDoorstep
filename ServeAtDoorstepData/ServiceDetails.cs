using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServeAtDoorstepData
{
    public class CategoryDetails
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public string CreatedOn { get; set; }
        public int CreatedBy { get; set; }
    }

    public class ServiceDetails
    {
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public string ServiceKeyword { get; set; }
        public int CategoryId { get; set; }
        public string ServiceType { get; set; }
        public string PriceRangeFrom { get; set; }
        public string PriceRangeTo { get; set; }
        public int NoOfPair { get; set; }
        public string BrandName { get; set; }
        public string BrandType { get; set; }
        public string CreatedOn { get; set; }
        public int CreatedBy { get; set; }
    }
}
