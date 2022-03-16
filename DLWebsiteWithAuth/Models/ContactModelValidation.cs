using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;

namespace DLWebsiteWithAuth.Models
{

    public class ContactModelValidation : AbstractValidator<ContactModel>
    {
        public ContactModelValidation()
        {
            RuleFor(x => x.Client_Forename).NotEmpty().WithMessage("Enter Forename").Matches("^[A-Za-z']+([\\s])*([A-Za-z']+)*$").WithMessage("Invalid Name");
            RuleFor(x => x.Client_Surname).NotEmpty().WithMessage("Enter Surname").Matches("^[A-Za-z']+([\\s])*([A-Za-z']+)*$").WithMessage("Invalid Surname"); ;
            RuleFor(x => x.Client_Postcode).NotEmpty().WithMessage("Enter Postcode").Matches("^(([gG][iI][rR] {0,}0[aA]{2})|((([a-pr-uwyzA-PR-UWYZ][a-hk-yA-HK-Y]?[0-9][0-9]?)|(([a-pr-uwyzA-PR-UWYZ][0-9][a-hjkstuwA-HJKSTUW])|([a-pr-uwyzA-PR-UWYZ][a-hk-yA-HK-Y][0-9][abehmnprv-yABEHMNPRV-Y]))) {0,}[0-9][abd-hjlnp-uw-zABD-HJLNP-UW-Z]{2}))$").WithMessage("Invalid Postcode");
            RuleFor(x => x.Client_Mob).NotEmpty().WithMessage("Enter Contact Number").LessThan(9999999999);
            RuleFor(x => x.New_old_Client).NotEmpty().WithMessage("Select New or Existing Client");
            RuleFor(x => x.Client_email).NotEmpty().WithMessage("Enter Email").EmailAddress().WithMessage("Invalid Email");
            RuleFor(x => x.ConfirmEmail).NotEmpty().WithMessage("Confirm Email").EmailAddress().WithMessage("Invalid Email").Equal(x => x.Client_email).WithMessage("Email not Matching");
            RuleFor(x => x.Ref_Department).NotEmpty().WithMessage("Select what does your Query relates to");//.Matches("^[a-zA-Z0-9 ]+$").WithMessage("Invalid Department")
            RuleFor(x => x.Description).NotEmpty().WithMessage("Enter details of your query").MaximumLength(500);
            RuleFor(x => x.QueryType).NotEmpty().WithMessage("Select Query type");
            //RuleFor(x => x.ValidationTrue).Equal(true);
            RuleFor(x => x.consent).Equal(true).WithMessage("Please select at least one option for communication");
        }
    }
}