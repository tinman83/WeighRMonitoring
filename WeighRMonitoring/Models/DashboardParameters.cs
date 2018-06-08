using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeighRMonitoring.Models
{
    public class DashboardParameters
    {
        public string ClientId { get; set; }
        public string Plant { get; set; }
        public string FillingMachine { get; set; }
        public string ProductCode { get; set; }
        public int Duration { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

    }
}