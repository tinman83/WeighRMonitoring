using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeighRMonitoring.Models.ReportEntities
{
    public class rptMachinePerformance
    {
        public string MachineName { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal UnitWeight { get; set; }
        public decimal AvgFillTime { get; set; }
        public int TotalUnits { get; set; }
        public decimal TotalUnitsWithinRange { get; set; }
        public decimal MachinePrecision { get; set; }
    }
}