//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AMSProjectNew
{
    using System;
    using System.Collections.Generic;
    
    public partial class AMS_JobEditRequests
    {
        public long Id { get; set; }
        public Nullable<long> JobId { get; set; }
        public string RequestTitle { get; set; }
        public string RequestDetails { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedByName { get; set; }
        public string CreatedByType { get; set; }
        public Nullable<long> CreatedById { get; set; }
    }
}