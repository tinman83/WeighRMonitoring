using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeighRMonitoring.Models;
using WeighRMonitoring.Models.Components;
using WeighRMonitoring.Models.ReportEntities;

namespace WeighRMonitoring.Api
{
    public class KPIReportController : ApiController
    {
        [HttpPost]
        public KPIReport GetKPIReport([FromBody]DashboardParameters para)
        {
            DashboardData reportData = new DashboardData();
            KPIReport kPIReport = reportData.GetKPIReport(para);


            return kPIReport;
        }
    }
}
