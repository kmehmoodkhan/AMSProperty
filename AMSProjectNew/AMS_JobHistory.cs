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
    
    public partial class AMS_JobHistory
    {
        public long Id { get; set; }
        public Nullable<long> JobId { get; set; }
        public Nullable<long> UserId { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string HistoryType { get; set; }
    }
}
