using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeighRMonitoring.ViewModels;
using WeighRMonitoring.Extensions;

namespace WeighRMonitoring.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {

            DashBoardViewModel dashBoardViewModel = new DashBoardViewModel()
            {
                NavTitle = "Dashboard",
                signalRHubConnection = ""
            };

            return View(dashBoardViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}