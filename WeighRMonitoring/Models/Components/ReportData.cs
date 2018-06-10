using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using WeighRMonitoring.Helpers;
using WeighRMonitoring.Models.Entities;
using WeighRMonitoring.Models.ReportEntities;

namespace WeighRMonitoring.Models.Components
{
    public class ReportData
    {
        WeighREntities _db = new WeighREntities();

        public IQueryable<TransactionLog> GetFilteredTransactionLog(ReportParameters para)
        {
            IQueryable<TransactionLog> result = _db.TransactionLogs;

            if (para.Plant != "All")
            {
                result = result.Where(p => p.PlantId == para.Plant);
            }
            if (para.FillingMachine != "All")
            {
                result = result.Where(p => p.MachineName == para.FillingMachine);
            }
            if (para.ProductCode != "All")
            {
                result = result.Where(p => p.ProductCode == para.ProductCode);
            }

            DateTime dateTimeFrom = DateHelper.StartOfDay(para.DateFrom.Date);
            DateTime dateTimeTo = DateHelper.EndOfDay(para.DateTo.Date);
            result = result.Where(p => (p.TransactionDate >= dateTimeFrom && p.TransactionDate <= dateTimeTo));

            return result;

        }

        public List<TransactionLog> GetProductPerMachineDetailedReport(ReportParameters para)
        {

            IQueryable<TransactionLog> result = GetFilteredTransactionLog(para);

            return result.ToList();

        }
        public List<rptProductPerMachineSummary> GetProductPerMachineSummaryReport(ReportParameters para)
        {

            IQueryable<TransactionLog> result = GetFilteredTransactionLog(para);

             var data = result
                        .Where(p=>p.ClientId==para.ClientId)
                        .GroupBy(p => new { p.MachineName, p.ProductCode, p.ProductName }, (key, group) => new
                        {
                            MachineName = key.MachineName,
                            ProductCode = key.ProductCode,
                            ProductName = key.ProductName,
                            Result = group.ToList()
                        })
                        .Select(s => new rptProductPerMachineSummary
                        {
                            MachineName=s.MachineName,
                            ProductCode=s.ProductCode,
                            ProductName=s.ProductName,
                            Units = s.Result.Count(),
                            ProductWeight = s.Result.Min(p => p.TargetWeight),
                            TotalTargetWeight = s.Result.Sum(p => p.TargetWeight),
                            TotalActualWeight = s.Result.Sum(p => p.ActualWeight),
                            Diff = s.Result.Sum(p => p.ActualWeight)- s.Result.Sum(p => p.TargetWeight),
                        }).ToList();

            return data.ToList();

        }

        public List<TransactionLog> GetProductionDetailedReport(ReportParameters para)
        {

            IQueryable<TransactionLog> result = GetFilteredTransactionLog(para);

            return result.ToList();

        }

        public List<rptProductionSummary> GetProductionSummaryReport(ReportParameters para)
        {

            IQueryable<TransactionLog> result = GetFilteredTransactionLog(para);

            var data = result
                       .Where(p => p.ClientId == para.ClientId)
                       .GroupBy(p => new { p.ProductCode, p.ProductName }, (key, group) => new
                       {
                           ProductCode = key.ProductCode,
                           ProductName = key.ProductName,
                           Result = group.ToList()
                       })
                       .Select(s => new rptProductionSummary
                       {
                           ProductCode = s.ProductCode,
                           ProductName = s.ProductName,
                           Units = s.Result.Count(),
                           ProductWeight = s.Result.Min(p => p.TargetWeight),
                           TotalTargetWeight = s.Result.Sum(p => p.TargetWeight),
                           TotalActualWeight = s.Result.Sum(p => p.ActualWeight),
                           Diff = s.Result.Sum(p => p.ActualWeight) - s.Result.Sum(p => p.TargetWeight),
                       }).ToList();

            return data.ToList();

        }

        public List<rptProductionRuntime> GetProductionRunTimeReport(ReportParameters para)
        {

            IQueryable<TransactionLog> result = GetFilteredTransactionLog(para);

            var data = result
                       .Where(p => p.ClientId == para.ClientId)
                       .GroupBy(p => new {
                           p.MachineName,
                           TransDate=(DateTime)DbFunctions.TruncateTime(p.TransactionDate),
                           TransHour = (int)SqlFunctions.DatePart("hour", p.TransactionDate) }, (key, group) => new
                       {
                               MachineName = key.MachineName,
                               TransDate = key.TransDate,
                               TransHour = key.TransHour,
                               Result = group.ToList()
                       })
                       .OrderBy(p => p.MachineName).ThenBy(p => p.TransDate).ThenBy(p => p.TransHour)
                       .Select(s => new rptProductionRuntime
                       {
                           MachineName = s.MachineName,
                           TransDate = s.TransDate,
                           TransHour = s.TransHour,
                           TotalUnits = s.Result.Count()
                       }).ToList();

            return data.ToList();

        }

        public List<rptMachinePerformance> GetMachinePerformanceReport(ReportParameters para)
        {
            ReportDataHelper rdHelper = new ReportDataHelper();

            var TotalUnits = rdHelper.GetTotalUnits(para);
            var UnitsWithinRange = rdHelper.GetUnitsWithinWeightRange(para);

            decimal Precision = 0;
            if (TotalUnits != 0)
            {
                Precision = (UnitsWithinRange / TotalUnits) * 100;
            }

            IQueryable<TransactionLog> result = GetFilteredTransactionLog(para);

            var data = result
                       .Where(p => p.ClientId == para.ClientId)
                       .GroupBy(p => new {
                           p.MachineName,
                           p.ProductCode,
                           p.ProductName,
                           p.TargetWeight
                       }, (key, group) => new
                       {
                           MachineName = key.MachineName,
                           ProductCode = key.ProductCode,
                           ProductName = key.ProductName,
                           TargetWeight = key.TargetWeight,
                           Result = group.ToList()
                       })
                       .OrderBy(p => p.MachineName).ThenBy(p => p.ProductCode)
                       .Select(s => new rptMachinePerformance
                       {
                           MachineName = s.MachineName,
                           ProductCode = s.ProductCode,
                           ProductName = s.ProductName,
                           UnitWeight = s.Result.Min(p => p.TargetWeight),
                           AvgFillTime =(Decimal)s.Result.Average(p=>p.ActualFillTime),
                           TotalUnits = s.Result.Count(),
                           TotalUnitsWithinRange = UnitsWithinRange,
                           MachinePrecision =Precision
                       }).ToList();

            return data.ToList();

        }

        public List<rptBatchesPerProductSummary> GetBatchesPerProductSummaryReport(ReportParameters para)
        {

            IQueryable<TransactionLog> result = GetFilteredTransactionLog(para);

            var data = result
                       .Where(p => p.ClientId == para.ClientId)
                       .GroupBy(p => new { p.BatchCode, p.ProductCode, p.ProductName }, (key, group) => new
                       {
                           BatchCode = key.BatchCode,
                           ProductCode = key.ProductCode,
                           ProductName = key.ProductName,
                           Result = group.ToList()
                       })
                       .Select(s => new rptBatchesPerProductSummary
                       {
                           BatchCode = s.BatchCode,
                           ProductCode = s.ProductCode,
                           ProductName = s.ProductName,
                           Units = s.Result.Count(),
                           ProductWeight = s.Result.Min(p => p.TargetWeight),
                           TotalTargetWeight = s.Result.Sum(p => p.TargetWeight),
                           TotalActualWeight = s.Result.Sum(p => p.ActualWeight),
                           AvgDensity=Math.Round(s.Result.Average(p=>p.ProductDensity),2),
                           Diff = s.Result.Sum(p => p.ActualWeight) - s.Result.Sum(p => p.TargetWeight),
                       }).ToList();

            return data.ToList();

        }
    }
}