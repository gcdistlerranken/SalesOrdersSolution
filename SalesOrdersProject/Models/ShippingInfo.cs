using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalesOrdersProject.Models
{
    public class ShippingInfo
    {
        [Required(ErrorMessage = "Please add Shipping Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please add Shipping City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please add Shipping State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please add Shipping Postal Code")]
        public string PostalCode { get; set; }

    }
}