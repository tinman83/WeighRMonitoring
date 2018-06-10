using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeighRMonitoring.Models;
using WeighRMonitoring.Models.Components;

namespace WeighRMonitoring.Api
{
    public class ReportsController : ApiController
    {
        // GET: api/Dashboard
        public List<ReportCategory> GetReports(int id)
        {
            ReportsComponent reportsComp = new ReportsComponent();
            var reports = reportsComp.GetReports(id);

            List<ReportCategory> reportsList = new List<ReportCategory>();

            foreach (var item in reports)
            {
                reportsList.Add(new ReportCategory { ID = item.ID, Name = item.ReportName, ParentId = item.ParentId, Description = item.ReportDescription, Url = item.ReportURL });
            }

            return reportsList;

        }
    }
}
