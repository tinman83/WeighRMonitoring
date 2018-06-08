using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeighRMonitoring.Helpers;
using WeighRMonitoring.Models.Entities;
using WeighRMonitoring.Models.ReportEntities;

namespace WeighRMonitoring.Models.Components
{
    public partial class DashboardData
    {
        WeighREntities _db = new WeighREntities();

        public DashboardReport GetDashboardReport(DashboardParameters para)
        {

            IQueryable<TransactionLog> result = _db.TransactionLogs;

            if (para.Plant != "All")
            {
                result =result.Where(p => p.PlantId == para.Plant);
            }
            if (para.FillingMachine != "All")
            {
                result = result.Where(p => p.MachineName == para.FillingMachine);
            }
            if (para.ProductCode != "All")
            {
                result = result.Where(p => p.ProductCode == para.ProductCode);
            }
            if (para.Duration == 0)
            {
                DateTime dateTimeFrom = DateHelper.StartOfDay(DateTime.Now).ToUniversalTime();
                DateTime dateTimeTo = DateHelper.EndOfDay(DateTime.Now).ToUniversalTime();
                result = result.Where(p => (p.TransactionDate >= dateTimeFrom && p.TransactionDate <= dateTimeTo));
            }else
            {
                DateTime start = DateHelper.StartDate(para.Duration);
                DateTime end = DateHelper.EndDate(para.Duration);

                DateTime dateTimeFrom = DateHelper.StartOfDay(start).ToUniversalTime();
                DateTime dateTimeTo = DateHelper.EndOfDay(end).ToUniversalTime();

                result = result.Where(p => (p.TransactionDate >= dateTimeFrom && p.TransactionDate <= dateTimeTo));
            }

            ///.Where(p => (p.TransactionDate >= para.DateFrom && p.TransactionDate <= para.DateTo))

            var data = result
                        .Where(p=>p.ClientId==para.ClientId)
                        .GroupBy(p => p.ProductCode)
                        .Select(s => new DashboardReport
                        {
                            Units = s.Count(),
                            RequiredWeight = s.Sum(p => p.TargetWeight),
                            ActualWeight = s.Sum(p => p.ActualWeight),
                            AverageWeight = s.Average(p => p.ActualWeight),
                            PercDiffWeight = ((s.Sum(p => p.ActualWeight) - s.Sum(p => p.TargetWeight)) / s.Sum(p => p.TargetWeight)) * 100,
                            AverageFillTime = s.Average(p => p.ActualFillTime)
                        }).FirstOrDefault();

            if (data == null)
            {
                data = new DashboardReport
                {
                    Units = 0,
                    RequiredWeight = 0,
                    ActualWeight = 0,
                    AverageWeight = 0,
                    PercDiffWeight = 0,
                    AverageFillTime = 0
                };
            }

            return (DashboardReport)data;

        }

        public List<DensityTrend> GetBatchDensityTrend(DashboardParameters para)
        {

            IQueryable<TransactionLog> result = _db.TransactionLogs;
            string rptStartDate = "";
            string rptEndDate = "";

            if (para.ProductCode != "All")
            {
                result = result.Where(p => p.ProductCode == para.ProductCode);
            }
            if (para.Duration == 0)
            {
                DateTime dateTimeFrom = DateHelper.StartOfDay(DateTime.Now).ToUniversalTime();
                DateTime dateTimeTo = DateHelper.EndOfDay(DateTime.Now).ToUniversalTime();
                result = result.Where(p => (p.TransactionDate >= dateTimeFrom && p.TransactionDate <= dateTimeTo));

                rptStartDate.ToString();
                rptEndDate = dateTimeTo.ToString();
            }
            else
            {
                DateTime start = DateHelper.StartDate(para.Duration);
                DateTime end = DateHelper.EndDate(para.Duration);

                DateTime dateTimeFrom = DateHelper.StartOfDay(start).ToUniversalTime();
                DateTime dateTimeTo = DateHelper.EndOfDay(end).ToUniversalTime();

                result = result.Where(p => (p.TransactionDate >= dateTimeFrom && p.TransactionDate <= dateTimeTo));
                rptStartDate.ToString();
                rptEndDate = dateTimeTo.ToString();
            }

            List<DensityTrend> data = result
                        .Where(p => p.ClientId == para.ClientId)
                        .GroupBy(p => new {p.BatchCode },(key, group) => new
                        {
                            BatchCode = key.BatchCode,
                            Result = group.ToList()
                        }) 
                        .Select(s => new DensityTrend
                        {
                            BatchCode = s.BatchCode,
                            startDate = rptStartDate,
                            endDate=rptEndDate,
                            avgDensity=s.Result.Average(p=>p.ProductDensity)
                        }).ToList();

            return data.ToList();

        }

        public KPIReport GetKPIReport(DashboardParameters para)
        {
            DashboardDataHelper rdHelper = new DashboardDataHelper();
            KPIReport kPIReport = new KPIReport();

            var TotalUnits = rdHelper.GetTotalUnits(para);
            var UnitsWithinRange = rdHelper.GetUnitsWithinWeightRange(para);

            decimal Precision = 0;
            if (TotalUnits != 0)
            {
                Precision= (UnitsWithinRange / TotalUnits) * 100;
            }

            var UnitsWithinFillTimeLimits = rdHelper.GetUnitsWithinFillTimeLimits(para);

            decimal Performance = 0;
            if (TotalUnits != 0)
            {
                Performance = (UnitsWithinFillTimeLimits / TotalUnits) * 100;
            }


            kPIReport.Precision = Math.Round(Precision,2);
            kPIReport.Performance = Math.Round( Performance);
            kPIReport.Efficiency = Math.Round((Performance + Precision) / 2,2);


            return kPIReport;
        }
        public List<Product> GetProductsList()
        {
            return _db.Products.ToList();

        }
        public List<Plant> GetPlantsList()
        {
            return _db.Plants.ToList();

        }
        public List<Machine> GetMachinesList()
        {
            return _db.Machines.ToList();

        }
    }
}