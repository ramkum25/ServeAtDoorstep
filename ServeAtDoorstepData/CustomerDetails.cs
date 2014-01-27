using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServeAtDoorstepData
{
    public class CustomerDetails
    {
        public int CustomerID { get; set; }
        public string LoginName { get; set; }
        public string LoginPassword { get; set; }
        public string ImagePath { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        
        public string Address { get; set; }
        public string StreetName { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public string ZipCode { get; set; }
       
        
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string LastLogedDateAndLocation { get; set; }
        public int CustomerStatus { get; set; }
        public int CustomerType { get; set; }
        public int CustomerBlocked { get; set; }
        public int CustomerDeleted { get; set; }

    }

    public class CusBankDetails
    {
        public int BankId { get; set; }
        public int CustomerId { get; set; }
        public string BankName { get; set; }
        public string CardHolderName { get; set; }
        public string CreditCardNumber { get; set; }
        public string CVCNumber { get; set; }
    }

    public class CustomerMessageDetails
    {
        public int CustomerMessageId { get; set; }
        public int QuiryId { get; set; }
        public int RecCustomerId { get; set; }
        public int SendVendorId { get; set; }
        public int CategoryId { get; set; }
        public string MessageTitle { get; set; }
        public string Description { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedOn { get; set; }
        public int CreatedBy { get; set; }
        public string Status { get; set; }

    }

}
