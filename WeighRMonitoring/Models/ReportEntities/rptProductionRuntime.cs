using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeighRMonitoring.Models.ReportEntities
{
    public class rptProductionRuntime
    {
        public string MachineName { get; set; }
        public DateTime TransDate { get; set; }
        public int TransHour { get; set; }
        public int TotalUnits { get; set; }

    }
}