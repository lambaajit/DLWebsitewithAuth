using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation.Attributes;

namespace DLWebsiteWithAuth.Models
{
    [Validator(typeof(ContactModelValidation))]
    public class ContactModel
    {
        public int ID { get; set; }
        public int Step { get; set; }
        public string FeeEarner { get; set; }
        public string FeeEarnerDepartment { get; set; }
        public string Clientname { get; set; }
        public string Client_Forename { get; set; }
        public string Client_Surname { get; set; }
        public string Client_Postcode { get; set; }
        public string Client_email { get; set; }
        public Nullable<long> Client_Mob { get; set; }
        public Nullable<System.DateTime> DateRef1 { get; set; }
        public string Ref_Department { get; set; }
        public string Preferred_Location { get; set; }
        public string Location { get; set; }
        public string Ref_Feeearner { get; set; }
        public string New_FeeEarner { get; set; }
        public string Referral_to { get; set; }
        public string RoomBooked { get; set; }
        public string CustomerServiceMember { get; set; }
        public string Source { get; set; }
        public string Description { get; set; }
        public Nullable<bool> New_old_Client { get; set; }
        public string Ref_SubDepartment { get; set; }
        public Nullable<System.DateTime> DateRef2 { get; set; }
        public bool consent {get;set;}
        public string ConfirmEmail { get; set; }
        public string QueryType { get; set; }
        public string ModeOfCommunication { get; set; }

    }
}