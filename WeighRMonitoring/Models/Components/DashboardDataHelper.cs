using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeighRMonitoring.Helpers;
using WeighRMonitoring.Models.Entities;

namespace WeighRMonitoring.Models.Components
{
    public class DashboardDataHelper
    {
        WeighREntities _db = new WeighREntities();

        public decimal GetTotalUnits(DashboardParameters para)
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
            if (para.Duration == 0)
            {
                DateTime dateTimeFrom = DateHelper.StartOfDay(DateTime.Now).ToUniversalTime();
                DateTime dateTimeTo = DateHelper.EndOfDay(DateTime.Now).ToUniversalTime();
                result = result.Where(p => (p.TransactionDate >= dateTimeFrom && p.TransactionDate <= dateTimeTo));
            }
            else
            {
                DateTime start = DateHelper.StartDate(para.Duration);
                DateTime end = DateHelper.EndDate(para.Duration);

                DateTime dateTimeFrom = DateHelper.StartOfDay(start).ToUniversalTime();
                DateTime dateTimeTo = DateHelper.EndOfDay(end).ToUniversalTime();

                result = result.Where(p => (p.TransactionDate >= dateTimeFrom && p.TransactionDate <= dateTimeTo));
            }
            result = result.Where(p => p.ClientId == para.ClientId);

            return result.Count();

        }

        public decimal GetUnitsWithinWeightRange(DashboardParameters para)
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
            if (para.Duration == 0)
            {
                DateTime dateTimeFrom = DateHelper.StartOfDay(DateTime.Now).ToUniversalTime();
                DateTime dateTimeTo = DateHelper.EndOfDay(DateTime.Now).ToUniversalTime();
                result = result.Where(p => (p.TransactionDate >= dateTimeFrom && p.TransactionDate <= dateTimeTo));
            }
            else
            {
                DateTime start = DateHelper.StartDate(para.Duration);
                DateTime end = DateHelper.EndDate(para.Duration);

                DateTime dateTimeFrom = DateHelper.StartOfDay(start).ToUniversalTime();
                DateTime dateTimeTo = DateHelper.EndOfDay(end).ToUniversalTime();

                result = result.Where(p => (p.TransactionDate >= dateTimeFrom && p.TransactionDate <= dateTimeTo));
            }

            var data = result
                        .Where(p => p.ClientId == para.ClientId && (p.ActualWeight > (p.TargetWeight - (p.LowerLimit / 1000)) && p.ActualWeight < (p.TargetWeight + (p.UpperLimit / 1000))));
                        

            return data.Count();
        }

        public decimal GetUnitsWithinFillTimeLimits(DashboardParameters para)
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
            if (para.Duration == 0)
            {
                DateTime dateTimeFrom = DateHelper.StartOfDay(DateTime.Now).ToUniversalTime();
                DateTime dateTimeTo = DateHelper.EndOfDay(DateTime.Now).ToUniversalTime();
                result = result.Where(p => (p.TransactionDate >= dateTimeFrom && p.TransactionDate <= dateTimeTo));
            }
            else
            {
                DateTime start = DateHelper.StartDate(para.Duration);
                DateTime end = DateHelper.EndDate(para.Duration);

                DateTime dateTimeFrom = DateHelper.StartOfDay(start).ToUniversalTime();
                DateTime dateTimeTo = DateHelper.EndOfDay(end).ToUniversalTime();

                result = result.Where(p => (p.TransactionDate >= dateTimeFrom && p.TransactionDate <= dateTimeTo));
            }

            var data = result
                        .Where(p => p.ClientId == para.ClientId && p.ActualFillTime<=p.ExpectedFillTime);


            return data.Count();
        }
    }
}