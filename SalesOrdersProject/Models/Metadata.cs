using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SalesOrdersProject.Models
{
    public class CustomerMetadata
    {
        [StringLength(25)]
        [Display(Name = "First Name")]
        public string CustomerFirstName;

        [StringLength(25)]
        [Display(Name = "Last Name")]
        public string CustomerLastName;

        [StringLength(50)]
        [Display(Name = "Address")]
        public string CustomerStreetAddress;

        [StringLength(30)]
        [Display(Name = "City")]
        public string CustomerCity;

        [StringLength(2)]
        [Display(Name = "State")]
        public string CustomerState;

        [StringLength(10)]
        [Display(Name = "Zip Code")]
        public string CustomerZipCode;

        [Display(Name = "Area Code")]
        public Nullable<short> CustomerAreaCode;

        [StringLength(8)]
        [Display(Name = "Phone Number")]
        public string CustomerPhoneNumber;

        [StringLength(50)]
        [Display(Name = "Billing Address")]
        public string BillingAddress;

        [StringLength(30)]
        [Display(Name = "Billing City")]
        public string BillingCity;

        [StringLength(2)]
        [Display(Name = "Billing State")]
        public string BillingState;

        [StringLength(10)]
        [Display(Name = "Billing Postal Code")]
        public string BillingPostalCode;

        [StringLength(12)]
        [Display(Name = "Credit Card Expire Month")]
        public string BillingExpireMonth;

        [StringLength(4)]
        [Display(Name = "Credit Card Expire Year")]
        public string BillingExpireYear;

        [StringLength(20)]
        [Display(Name = "Credit Card Number")]
        public string BillingCreditCardNumber;

        [StringLength(100)]
        [Display(Name = "Email Address")]
        public string CustomerEmailAddress;
    }

    public class OrderMetadata
    {
        [StringLength(50)]
        [Display(Name = "Shipping Address")]
        public string ShippingAddress;

        [StringLength(30)]
        [Display(Name = "Shipping City")]
        public string ShippingCity;

        [StringLength(2)]
        [Display(Name = "Shipping State")]
        public string ShippingState;

        [StringLength(10)]
        [Display(Name = "Shipping Postal Code")]
        public string ShippingPostalCode;
    }
}