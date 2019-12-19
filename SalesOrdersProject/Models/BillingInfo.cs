using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesOrdersProject.Models
{
    public class BillingInfo
    {
        [Required(ErrorMessage = "Please add Billing First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please add Billing Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please add Billing Credit Card Number")]
        public string CreditCardNumber { get; set; }

        [Required(ErrorMessage = "Please add Billing Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please add Billing City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please add Billing State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please add Billing Postal Code")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Please add Billing Credit Card Expire Month")]
        public string ExpireMonth { get; set; }

        public SelectList Months()
        {
            return new SelectList(new string[]
            {
                "01", "02", "03", "04", "05", "06",
                "07", "08", "09", "10", "11", "12"
            });
        }

        [Required(ErrorMessage = "Please add Billing Credit Card Expire Year")]
        public string ExpireYear { get; set; }

        //public SelectList Years()
        //{
        //    @Html.DropDownList("ExpiryYear", Enumerable.Range(DateTime.Now.Year, 10).Select(x => new SelectListItem { Text = x.ToString() }), "Expiry Year")
        //    List<KeyValuePair<string, string>> expirationDateYears = new List<KeyValuePair<string, string>>();
        //    for (int i = 0; i <= 11; i++)
        //    {
        //        String year = (DateTime.Today.Year + i).ToString();
        //        expirationDateYears.Add(new KeyValuePair<string, string>(year, year));
        //    }
        //    this.ExpireYear = new SelectList(expirationDateYears, "key", "value", DateTime.Today.Year.ToString());
        //    //Add code to grab current year and go from there 11 years
        //    return new SelectList(new string[]
        //    {
        //        "2019", "2020", "2021", "2022", "2023", "2024",
        //        "2025", "2026", "2027", "2028", "2029", "2030"
        //    });
        //}
    }
}