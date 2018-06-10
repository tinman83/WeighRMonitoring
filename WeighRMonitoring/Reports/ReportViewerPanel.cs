using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeighRMonitoring.Models.Components;
using Microsoft.Reporting.WebForms;
using WeighRMonitoring.Models;

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

        private void renderProductsPerMachineDetailedReport(ReportParameters para)
        {
            ReportData reportData = new ReportData();
            var data = reportData.GetProductPerMachineDetailedReport(para);
            var reportDataSource1 = new Microsoft.Reporting.WebForms.ReportDataSource();
            reportDataSource1.Name = "dsTransactionLogs";
            reportDataSource1.Value = data;
            this.ReportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/Rdlc/ProductPerMachineDetailedReport.rdlc");

            ReportParameter[] rptParams = new ReportParameter[2];
            rptParams[0] = new ReportParameter("paraDateFrom", para.DateFrom.Date.ToString(), true);
            rptParams[1] = new ReportParameter("paraDateTo", para.DateTo.Date.ToString(), true);
            this.ReportViewer1.LocalReport.SetParameters(rptParams);

            ReportViewer1.ShowPrintButton = true;
            ReportViewer1.ZoomMode = ZoomMode.PageWidth;

        }

        private void renderProductsPerMachineSummaryReport(ReportParameters para)
        {
            ReportData reportData = new ReportData();
            var data = reportData.GetProductPerMachineSummaryReport(para);
            var reportDataSource1 = new Microsoft.Reporting.WebForms.ReportDataSource();
            reportDataSource1.Name = "dsProductPerMachineSummary";
            reportDataSource1.Value = data;
            this.ReportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/Rdlc/ProductPerMachineSummaryReport.rdlc");

            ReportParameter[] rptParams = new ReportParameter[2];
            rptParams[0] = new ReportParameter("paraDateFrom", para.DateFrom.Date.ToString(), true);
            rptParams[1] = new ReportParameter("paraDateTo", para.DateTo.Date.ToString(), true);
            this.ReportViewer1.LocalReport.SetParameters(rptParams);

            ReportViewer1.ShowPrintButton = true;
            ReportViewer1.ZoomMode = ZoomMode.PageWidth;

        }

        private void renderProductionDetailedReport(ReportParameters para)
        {
            ReportData reportData = new ReportData();
            var data = reportData.GetProductionDetailedReport(para);
            var reportDataSource1 = new Microsoft.Reporting.WebForms.ReportDataSource();
            reportDataSource1.Name = "dsProductionDetailedReport";
            reportDataSource1.Value = data;
            this.ReportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/Rdlc/ProductionDetailedReport.rdlc");

            ReportParameter[] rptParams = new ReportParameter[2];
            rptParams[0] = new ReportParameter("paraDateFrom", para.DateFrom.Date.ToString(), true);
            rptParams[1] = new ReportParameter("paraDateTo", para.DateTo.Date.ToString(), true);
            this.ReportViewer1.LocalReport.SetParameters(rptParams);

            ReportViewer1.ShowPrintButton = true;
            ReportViewer1.ZoomMode = ZoomMode.PageWidth;

        }

        private void renderProductionSummaryReport(ReportParameters para)
        {
            ReportData reportData = new ReportData();
            var data = reportData.GetProductionSummaryReport(para);
            var reportDataSource1 = new Microsoft.Reporting.WebForms.ReportDataSource();
            reportDataSource1.Name = "dsProductionSummaryReport";
            reportDataSource1.Value = data;
            this.ReportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/Rdlc/ProductionSummaryReport.rdlc");

            ReportParameter[] rptParams = new ReportParameter[2];
            rptParams[0] = new ReportParameter("paraDateFrom", para.DateFrom.Date.ToString(), true);
            rptParams[1] = new ReportParameter("paraDateTo", para.DateTo.Date.ToString(), true);
            this.ReportViewer1.LocalReport.SetParameters(rptParams);

            ReportViewer1.ShowPrintButton = true;
            ReportViewer1.ZoomMode = ZoomMode.PageWidth;

        }

        private void renderProductionRunTimeReport(ReportParameters para)
        {
            ReportData reportData = new ReportData();
            var data = reportData.GetProductionRunTimeReport(para);
            var reportDataSource1 = new Microsoft.Reporting.WebForms.ReportDataSource();
            reportDataSource1.Name = "dsProductionRunTimeReport";
            reportDataSource1.Value = data;
            this.ReportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/Rdlc/ProductionRunTimeReport.rdlc");

            ReportParameter[] rptParams = new ReportParameter[2];
            rptParams[0] = new ReportParameter("paraDateFrom", para.DateFrom.Date.ToString(), true);
            rptParams[1] = new ReportParameter("paraDateTo", para.DateTo.Date.ToString(), true);
            this.ReportViewer1.LocalReport.SetParameters(rptParams);

            ReportViewer1.ShowPrintButton = true;
            ReportViewer1.ZoomMode = ZoomMode.PageWidth;

        }

        private void renderMachinePerformanceReport(ReportParameters para)
        {
            ReportData reportData = new ReportData();
            var data = reportData.GetMachinePerformanceReport(para);
            var reportDataSource1 = new Microsoft.Reporting.WebForms.ReportDataSource();
            reportDataSource1.Name = "dsMachinePerformanceReport";
            reportDataSource1.Value = data;
            this.ReportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/Rdlc/MachinePerformanceReport.rdlc");

            ReportParameter[] rptParams = new ReportParameter[2];
            rptParams[0] = new ReportParameter("paraDateFrom", para.DateFrom.Date.ToString(), true);
            rptParams[1] = new ReportParameter("paraDateTo", para.DateTo.Date.ToString(), true);
            this.ReportViewer1.LocalReport.SetParameters(rptParams);

            ReportViewer1.ShowPrintButton = true;
            ReportViewer1.ZoomMode = ZoomMode.PageWidth;

        }

        private void renderBatchesPerProductSummaryReport(ReportParameters para)
        {
            ReportData reportData = new ReportData();
            var data = reportData.GetBatchesPerProductSummaryReport(para);
            var reportDataSource1 = new Microsoft.Reporting.WebForms.ReportDataSource();
            reportDataSource1.Name = "dsBatchesPerProductSummaryReport";
            reportDataSource1.Value = data;
            this.ReportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Reports/Rdlc/BatchesPerProductSummaryReport.rdlc");

            ReportParameter[] rptParams = new ReportParameter[2];
            rptParams[0] = new ReportParameter("paraDateFrom", para.DateFrom.Date.ToString(), true);
            rptParams[1] = new ReportParameter("paraDateTo", para.DateTo.Date.ToString(), true);
            this.ReportViewer1.LocalReport.SetParameters(rptParams);

            ReportViewer1.ShowPrintButton = true;
            ReportViewer1.ZoomMode = ZoomMode.PageWidth;

        }

    }
}