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
        public ActionResult Index(int? id)
        {
            ReportsViewModel reportsViewModel = new ReportsViewModel()
            {
                ParentId = id,
            };

            //return View(reportsList.Where(x => !x.ParentId.HasValue).ToList());
            return View(reportsViewModel);
        }

        public ActionResult GetReport()
        {
            ReportsViewModel reportsViewModel = new ReportsViewModel()
            {
            };

            return View(reportsViewModel);
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