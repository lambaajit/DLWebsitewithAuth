using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using FluentValidation.Attributes;

namespace DLWebsiteWithAuth
{

    [Validator(typeof(UnsubscribeValidation))]
    public partial class UnsubscribeEmail
    {

    }

    public class UnsubscribeValidation : AbstractValidator<UnsubscribeEmail>
    {
        public UnsubscribeValidation()
        {
            RuleFor(x => x.email).NotEmpty().WithMessage("Please enter your email address").EmailAddress().WithMessage("Invalid email address");
        }

        

    }
}