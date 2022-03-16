using DLWebsiteWithAuth.Models;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DLWebsiteWithAuth.Models
{
    [Validator(typeof(PaymentModelValidation))]
    public class PaymentModel
    {

        public long ID { get; set; }
        public string ClientReference { get; set; }
        public string ClientName { get; set; }
        public string Caseworker { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Description { get; set; }
        public string Payment_Status { get; set; }
        public string Email { get; set; }
        public string ConfirmEmail { get; set; }

    }
}