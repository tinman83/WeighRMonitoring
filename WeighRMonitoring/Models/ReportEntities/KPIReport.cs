using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeighRMonitoring.Models.ReportEntities
{
    public class KPIReport
    {
        public decimal Performance { get; set; }
        public decimal Precision { get; set; }
        public decimal Efficiency { get; set; }
    }
}