using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DLWebsiteWithAuth.Models
{
    public class PaymentModelValidation : AbstractValidator<PaymentModel>
    {
        public PaymentModelValidation()
        {
            RuleFor(x => x.Amount).NotEmpty().WithMessage("Enter Amount").InclusiveBetween(1,5000).WithMessage("The payment amount should be inbetween 1 and 5000");
            RuleFor(x => x.Caseworker).NotEmpty().WithMessage("Enter Caseworker").Matches("^[A-Za-z']+(\\s[A-Za-z']+)*$").WithMessage("Invalid Name"); 
            RuleFor(x => x.ClientName).NotEmpty().WithMessage("Enter Client Name").Matches("^[A-Za-z']+(\\s[A-Za-z']+)*$").WithMessage("Invalid Name"); 
            RuleFor(x => x.ClientReference).NotEmpty().WithMessage("Enter Client Reference Number").Matches("^[A-Z][0-9]{9}$").WithMessage("Invalid Client Reference");
            RuleFor(x => x.ConfirmEmail).NotEmpty().WithMessage("Confirm Email").EmailAddress().WithMessage("Invalid Email Address").Equal(x => x.Email).WithMessage("Email not matching");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Enter Email").EmailAddress().WithMessage("Invalid Email Address");
        }
    }
}