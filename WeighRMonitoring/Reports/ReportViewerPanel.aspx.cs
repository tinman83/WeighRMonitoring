using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using WeighRMonitoring.Models;
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
                string parameters = Request.QueryString["para"];

                if (parameters != null)
                {
                    parameters = parameters.Trim();
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    ReportParameters reportParameters = js.Deserialize<ReportParameters>(parameters);
                    RenderReport(reportParameters);

                }else
                {
                    ReportParameters reportParameters = new ReportParameters();
                    reportParameters.ReportName = "ProductsList";
                    RenderReport(reportParameters);
                }

            }
        }

        private void RenderReport(ReportParameters para)
        {
           
            ReportViewer1.Reset();

            switch (para.ReportName)
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
                case "ProductPerMachineDetailedReport":
                    renderProductsPerMachineDetailedReport(para);
                    break;
                case "ProductPerMachineSummaryReport":
                    renderProductsPerMachineSummaryReport(para);
                    break;
                case "ProductionDetailedReport":
                    renderProductionDetailedReport(para);
                    break;
                case "ProductionSummaryReport":
                    renderProductionSummaryReport(para);
                    break;
                case "ProductionRunTimeReport":
                    renderProductionRunTimeReport(para);
                    break;
                case "MachinePerformanceReport":
                    renderMachinePerformanceReport(para);
                    break;
                case "BatchesPerProductSummaryReport":
                    renderBatchesPerProductSummaryReport(para);
                    break;
                case "Default":
                    break;
            }


        }

      
    }
}