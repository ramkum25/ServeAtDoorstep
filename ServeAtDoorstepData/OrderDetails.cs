using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServeAtDoorstepData
{
    public class OrderDetails
    {
        public int OrderDetailsID { get; set; }
        public int OrderNumber { get; set; }
        public int CustomerId { get; set; }
        public int VendorId { get; set; }
        public int CategoryId { get; set; }
        public string OrderTitle { get; set; }
        public string OrderDescription { get; set; }
        public int OrderQuantity { get; set; }
        public int OrderTotalItems { get; set; }
        public decimal OrderTotalAmount { get; set; }
        public string OrderDate { get; set; }
        public string OrderStatus { get; set; }
        public string CreatedOn { get; set; }
        public string UpdatedOn { get; set; }
        public int CreatedBy { get; set; }
    }

    public class OrderItemDetails
    {
        public int OrderItemID { get; set; }
        public int OrderNumber { get; set; }
        public int OrderDetailsId { get; set; }
        public int CategoryId { get; set; }
        public int ServiceId { get; set; }
        public int Quantity { get; set; }
        public string CreatedOn { get; set; }
        public int CreatedBy { get; set; }
    }
}
