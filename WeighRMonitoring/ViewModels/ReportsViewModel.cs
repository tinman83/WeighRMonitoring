using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeighRMonitoring.Models;

namespace WeighRMonitoring.ViewModels
{
    public class ReportsViewModel
    {
        public string ReportName { get; set; }
        public List<ReportCategory> ReportList { get; set; }
    }
}