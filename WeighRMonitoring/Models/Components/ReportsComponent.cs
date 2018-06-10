using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeighRMonitoring.Models.Entities;

namespace WeighRMonitoring.Models.Components
{
    public class ReportsComponent
    {
        //private readonly WeighRDbContext _db;
        //public ReportComponent(WeighRDbContext context)
        //{
        //    _db = context;

        //}
        WeighREntities _db = new WeighREntities();
        public void AddReport(Report report)
        {
            _db.Reports.Add(report);
            _db.SaveChanges();

        }
        public void UpdateReport(Report report)
        {
            _db.Reports.Attach(report);
            _db.SaveChanges();
        }

        public Report GetReport(string reportName)
        {
            return _db.Reports
                  .Where(p => p.ReportName == reportName).FirstOrDefault();

        }
        public List<Report> GetReports(int id)
        {

            return _db.Reports.Where(r=>r.ParentId==id).ToList();
        }

        public void GenerateReports()
        {

        }
    }
}