﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DLWebsiteWithAuth
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WEBDLEntities : DbContext
    {
        public WEBDLEntities()
            : base("name=WEBDLEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AssentManagement_ProductDetails> AssentManagement_ProductDetails { get; set; }
        public virtual DbSet<Blue_Print> Blue_Print { get; set; }
        public virtual DbSet<ClientReferral> ClientReferrals { get; set; }
        public virtual DbSet<Internship> Internships { get; set; }
        public virtual DbSet<Mobile> Mobiles { get; set; }
        public virtual DbSet<Office> Offices { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Recruitment> Recruitments { get; set; }
        public virtual DbSet<Recruitment_CV_Binary> Recruitment_CV_Binary { get; set; }
        public virtual DbSet<Recruitment_DlWeb> Recruitment_DlWeb { get; set; }
        public virtual DbSet<SMSSentDetail> SMSSentDetails { get; set; }
        public virtual DbSet<StaffWith404Error> StaffWith404Error { get; set; }
        public virtual DbSet<SubDepartment> SubDepartments { get; set; }
        public virtual DbSet<Trustpilot_Webhooks> Trustpilot_Webhooks { get; set; }
        public virtual DbSet<UnsubscribeEmail> UnsubscribeEmails { get; set; }
        public virtual DbSet<VideoCallRequest> VideoCallRequests { get; set; }
        public virtual DbSet<Staff_Details> Staff_Details { get; set; }
    }
}
