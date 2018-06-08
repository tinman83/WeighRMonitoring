using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeighRMonitoring.Models.Components;
using Microsoft.Reporting.WebForms;

namespace WeighRMonitoring.Reports
{
    public partial class ReportViewerPanel : System.Web.UI.Page
    {
        private void renderProductsListReport()
        {
            DashboardData reportData = new DashboardData();
            var data = reportData.GetProductsList();
            var reportDataSource1 = new Microsoft.Reporting.WebForms.ReportDataSource();
            reportDataSource1.Name = "dsProducts";
            reportDataSource1.Value = data;
            this.ReportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/Rdlc/ProductsList.rdlc");
            ReportViewer1.ShowPrintButton = true;
            ReportViewer1.ZoomMode = ZoomMode.PageWidth;

        }
        private void renderPlantsListReport()
        {
            DashboardData reportData = new DashboardData();
            var data = reportData.GetPlantsList();
            var reportDataSource1 = new Microsoft.Reporting.WebForms.ReportDataSource();
            reportDataSource1.Name = "dsPlantsList";
            reportDataSource1.Value = data;
            this.ReportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/Rdlc/PlantsList.rdlc");
            ReportViewer1.ShowPrintButton = true;
            ReportViewer1.ZoomMode = ZoomMode.PageWidth;

        }

        private void renderMachinesListReport()
        {
            DashboardData reportData = new DashboardData();
            var data = reportData.GetMachinesList();
            var reportDataSource1 = new Microsoft.Reporting.WebForms.ReportDataSource();
            reportDataSource1.Name = "dsMachinesList";
            reportDataSource1.Value = data;
            this.ReportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/Rdlc/MachinesList.rdlc");
            ReportViewer1.ShowPrintButton = true;
            ReportViewer1.ZoomMode = ZoomMode.PageWidth;

        }
    }
}