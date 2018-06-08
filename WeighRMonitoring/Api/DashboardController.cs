using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WeighRMonitoring.Models;
using WeighRMonitoring.Models.Components;
using WeighRMonitoring.Models.Entities;
using WeighRMonitoring.Models.ReportEntities;

namespace WeighRMonitoring.Api
{
    public class DashboardController : ApiController
    {

        [HttpPost]
        public DashboardReport GetDashboardReport([FromBody]DashboardParameters para)
        {
            DashboardData reportData = new DashboardData();
            DashboardReport dashboardReport = reportData.GetDashboardReport(para);


            return dashboardReport;
        }

        

    }
}