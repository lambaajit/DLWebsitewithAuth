using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DLWebsiteWithAuth.Models
{
    [Validator(typeof(ApplyModelValidation))]
    public class ApplyModel
    {
        public int ID { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
        public Nullable<int> Post_ID { get; set; }
        public string Post_Title { get; set; }
        public Nullable<System.DateTime> Date_CV { get; set; }
        public string Agency { get; set; }
        public string Notes { get; set; }
        public string Added_By { get; set; }
        public string Email { get; set; }
        public string ConfirmEmail { get; set; }
        //public HttpPostedFileBase Filename { get; set; }
        //public HttpPostedFileBase Filename_CoverLetter { get; set; }
        public Nullable<int> Job_ID { get; set; }
        public string Source { get; set; }
        public string Source_Others { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public bool consent { get; set; }
    }
}