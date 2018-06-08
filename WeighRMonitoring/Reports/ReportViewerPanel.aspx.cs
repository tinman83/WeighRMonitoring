using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WeighRMonitoring.Models.Components;
using WeighRMonitoring.Models.Entities;

namespace WeighRMonitoring.Reports
{
    public partial class ReportViewerPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string reportName = Request.QueryString["reportName"];
                if (reportName != null)
                {
                    reportName = reportName.Trim();
                }
                RenderReport(reportName);
            }
        }

        private void RenderReport(string reportName)
        {
           
            ReportViewer1.Reset();

            //if (reportName == "ProductsList")
            //{
            //    renderProductsListReport();
            //}
            //else if (reportName == "PlantsList")
            //{
            //    renderPlantsListReport();
            //}
            //else if (reportName == "ManchinesList")
            //{
            //    renderMachinesListReport();
            //}

            switch (reportName)
            {
                case "ProductsList":
                    renderProductsListReport();
                    break;
                case "PlantsList":
                    renderPlantsListReport();
                    break;
                case "ManchinesList":
                    renderMachinesListReport();
                    break;
                case "Default":
                    break;
            }


        }

      
    }
}