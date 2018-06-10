using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeighRMonitoring.Models.ReportEntities
{
    public class rptProductionSummary
    {

        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal ProductWeight { get; set; }
        public decimal Units { get; set; }
        public decimal TotalTargetWeight { get; set; }
        public decimal TotalActualWeight { get; set; }
        public decimal Diff { get; set; }
    }
}