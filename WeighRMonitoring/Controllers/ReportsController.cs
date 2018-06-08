using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeighRMonitoring.Models;
using WeighRMonitoring.Models.Components;
using WeighRMonitoring.ViewModels;

namespace WeighRMonitoring.Controllers
{
    [Authorize]
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index()
        {
            ReportsComponent reportsComp = new ReportsComponent();
            var reports = reportsComp.GetReports();

            List<ReportCategory> reportsList = new List<ReportCategory>();

            foreach (var item in reports)
            {
                reportsList.Add(new ReportCategory { ID = item.ID, Name = item.ReportName, ParentId = item.ParentId, Description = item.ReportDescription, Url = item.ReportURL });
            }

            List<ReportCategory> reportslist = new List<ReportCategory>
            {
                  new ReportCategory  { ID =1 , Name="Main Cat1"     , ParentId = null , Description  = "Main Cat1" ,    Url=""   },
                  new ReportCategory  { ID =2 , Name="Sub Main Cat1" , ParentId = 1    , Description  ="Sub Main Cat1",  Url="" },
                  new ReportCategory  { ID =3 , Name="Sub Sub"       , ParentId = 2    , Description  ="Sub Sub",        Url=""       },
                  new ReportCategory  { ID =4 , Name="Main Cat2"     , ParentId = null , Description  ="Main Cat2"     ,Url=""},
                  new ReportCategory  { ID =5 , Name="Main Cat3"     , ParentId = null , Description  ="Main Cat3"     ,Url=""},
                  new ReportCategory  { ID =6 , Name="Sub Main Cat3" , ParentId = 5 , Description  ="Sub Main Cat3" ,Url=""}
            };

            return View(reportslist.Where(x => !x.ParentId.HasValue).ToList());
        }
        public ActionResult Products()
        {
            ReportsViewModel reportsViewModel = new ReportsViewModel()
            {
                ReportName ="Products"
            };

            return View(reportsViewModel);
        }
        public ActionResult PlantsList()
        {
            ReportsViewModel reportsViewModel = new ReportsViewModel()
            {
                ReportName = "PlantsList"
            };

            return View(reportsViewModel);
        }
        public ActionResult MachinesList()
        {
            ReportsViewModel reportsViewModel = new ReportsViewModel()
            {
                ReportName = "MachinesList"
            };

            return View(reportsViewModel);
        }
    }
}