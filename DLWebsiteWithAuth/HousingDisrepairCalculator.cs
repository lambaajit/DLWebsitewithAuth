//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class HousingDisrepairCalculator
    {
        public int Id { get; set; }
        public Nullable<decimal> Rent { get; set; }
        public Nullable<int> Rooms { get; set; }
        public string RoomTypes { get; set; }
        public Nullable<int> RoomsInhabitable { get; set; }
        public string TypesOfDisrepair { get; set; }
        public Nullable<System.DateTime> DateDisrepairReported { get; set; }
        public Nullable<int> YearsOfDisrepair { get; set; }
        public Nullable<int> SeverityOfDisrepair { get; set; }
        public string DisrepairRectified { get; set; }
        public Nullable<System.DateTime> DateDisrepairRectified { get; set; }
        public string SeriousRisk { get; set; }
        public string SeriousRiskDetails { get; set; }
        public Nullable<decimal> PersonalBelongingsValue { get; set; }
        public string RentArrears { get; set; }
        public Nullable<decimal> RentArrearsValue { get; set; }
        public string Landlord { get; set; }
        public Nullable<decimal> Cost { get; set; }
    }
}