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
    public class DensityTrendController : ApiController
    {
        [HttpPost]
        public List<DensityTrend> GetDensityTrend([FromBody]DashboardParameters para)
        {
            DashboardData reportData = new DashboardData();
            List<DensityTrend> densityTrend = reportData.GetBatchDensityTrend(para);

            return densityTrend;
        }
    }
}
