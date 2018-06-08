using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeighRMonitoring.Models.ReportEntities
{
    public class DensityTrend
    {
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string BatchCode { get; set; }
        public decimal avgDensity { get; set; }
    }
}