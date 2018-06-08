using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeighRMonitoring.Models.ReportEntities
{
    public class DashboardReport
    {
        public int Units { get; set; }
        public decimal RequiredWeight { get; set; }
        public decimal ActualWeight { get; set; }
        public decimal AverageWeight { get; set; }
        public decimal PercDiffWeight { get; set; }
        public decimal? AverageFillTime { get; set; }
    }

    
}