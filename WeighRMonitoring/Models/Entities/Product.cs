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
    
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public decimal Density { get; set; }
        public decimal DribblePoint { get; set; }
        public decimal Inflight { get; set; }
        public decimal LowerLimit { get; set; }
        public string Name { get; set; }
        public decimal TargetWeight { get; set; }
        public decimal UpperLimit { get; set; }
        public bool isCurrent { get; set; }
        public string ClientId { get; set; }
        public bool persistedServer { get; set; }
        public Nullable<System.Guid> rowguid { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<decimal> ExpectedFillTime { get; set; }
    }
}