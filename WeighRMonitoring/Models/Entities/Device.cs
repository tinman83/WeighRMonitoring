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
    
    public partial class Device
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public string OSName { get; set; }
        public string SerialNumber { get; set; }
        public string ClientId { get; set; }
        public string PlantId { get; set; }
        public string MachineName { get; set; }
        public Nullable<bool> pushToCloud { get; set; }
        public string iotHubUri { get; set; }
        public string iotHubDeviceKey { get; set; }
        public Nullable<bool> pushToWebApi { get; set; }
        public string ServerUrl { get; set; }
        public string Coordinates { get; set; }
    }
}
