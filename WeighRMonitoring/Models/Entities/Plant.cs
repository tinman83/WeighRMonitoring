//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WeighRMonitoring.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Plant
    {
        public int PlantId { get; set; }
        public string ClientId { get; set; }
        public string PlantName { get; set; }
        public string Location { get; set; }
        public string coordinates { get; set; }
        public Nullable<System.Guid> rowguid { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string userId { get; set; }
    }
}