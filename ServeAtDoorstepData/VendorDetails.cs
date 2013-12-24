using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServeAtDoorstepData
{
    public class VendorDetails
    {
        public int VendorID { get; set; }
        public string VendorName { get; set; }
        public string VendorAddress { get; set; }
        public string VendorStreet { get; set; }
        public int VendorCityId { get; set; }
        public int VendorStateId { get; set; }
        public int VendorCountryId { get; set; }
        public string VendorZipcode { get; set; }
        public string VendorEmail { get; set; }
        public string VendorMobile { get; set; }
        public string VendorBusinessPhone { get; set; }
        public string LoginName { get; set; }
        public string LoginPassword { get; set; }
        public string CompanyName { get; set; }
        public string OwnerName { get; set; }
        public string ContactName { get; set; }
        public string ContactNumber { get; set; }
        public int CategoryId { get; set; }
        public string CoverageArea { get; set; }
        public string WebsiteUrl { get; set; }
        public string GeoCode { get; set; }
        public int MemberShipId { get; set; }
        public string CreditCardNumber { get; set; }
        public string CreditCardType { get; set; }
        public string CreditCardExpired { get; set; }
        public string CVCNumber { get; set; }
        public int VendorStatus { get; set; }
        public int VendorType { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedOn { get; set; }
        public int VendorBlocked { get; set; }
        public int VendorDeleted { get; set; }

    }

    public class VendorMessageDetails
    {
        public int VendorMessageId { get; set; }
        public int QuoteId { get; set; }
        public int SendCustomerId { get; set; }
        public int VendorId { get; set; }
        public int CategoryId { get; set; }
        public string MessageTitle { get; set; }
        public string Description { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedOn { get; set; }
        public int CreatedBy { get; set; }
        public string Status { get; set; }

    }


}
