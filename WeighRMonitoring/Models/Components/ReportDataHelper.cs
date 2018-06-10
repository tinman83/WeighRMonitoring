using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeighRMonitoring.Helpers;
using WeighRMonitoring.Models.Entities;

namespace WeighRMonitoring.Models.Components
{
    public class ReportDataHelper
    {
        WeighREntities _db = new WeighREntities();

        public decimal GetTotalUnits(ReportParameters para)
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

            result = result.Where(p => p.ClientId == para.ClientId);

            return result.Count();


        }

        public decimal GetUnitsWithinWeightRange(ReportParameters para)
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

            var data = result
                        .Where(p => p.ClientId == para.ClientId && (p.ActualWeight > (p.TargetWeight - (p.LowerLimit / 1000)) && p.ActualWeight < (p.TargetWeight + (p.UpperLimit / 1000))));


            return data.Count();
        }

        public decimal GetUnitsWithinFillTimeLimits(ReportParameters para)
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

            var data = result
                        .Where(p => p.ClientId == para.ClientId && p.ActualFillTime <= p.ExpectedFillTime);


            return data.Count();
        }
    }
}