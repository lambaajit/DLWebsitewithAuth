using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DLWebsiteWithAuth.Models
{
    public class ApplyModelValidation : AbstractValidator<ApplyModel>
    {
        public ApplyModelValidation()
        {
            RuleFor(x => x.Forename).NotEmpty().WithMessage("Enter Forename").Matches("^[A-Za-z']+([\\s])*([A-Za-z']+)*$").WithMessage("Invalid Name");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Enter Surname").Matches("^[A-Za-z']+([\\s])*([A-Za-z']+)*$").WithMessage("Invalid Surname");
            RuleFor(x => x.Post_ID).NotEmpty().WithMessage("Select Post Applied for");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Enter Email");
            RuleFor(x => x.ConfirmEmail).NotEmpty().WithMessage("Confirm Email").Equal(x => x.Email).WithMessage("Email not matching");
            RuleFor(x => x.Source).NotEmpty().WithMessage("Select Source");
            RuleFor(x => x.Source_Others).Matches("^[\\.a-zA-Z0-9,!? ]*$").WithMessage("Please only use alphanumeric characters");
            RuleFor(x => x.consent).Equal(true).WithMessage("Please select at least one option for communication");
        }
    }
    
}