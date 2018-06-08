using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using WeighRMonitoring.Models.Entities;

namespace WeighRMonitoring.Models.Components
{
    public class TransactionLogComponent
    {
        //private readonly WeighRDbContext _db;
        //public TransactionLogComponent(WeighRDbContext context)
        //{
        //    _db = context;

        //}
        WeighREntities _db = new WeighREntities();
        public void AddTransactionLog(TransactionLog transactionLog)
        {
           
                _db.TransactionLogs.Add(transactionLog);
                _db.SaveChanges();

           
        }

        public TransactionLog GetTransactionLog(int transactionLogId)
        {
           
                return _db.TransactionLogs
                    .Where(p => p.TransactionLogId == transactionLogId).FirstOrDefault();

           
        }
        public List<TransactionLog> GetTransactionLogs()
        {
            
                return _db.TransactionLogs.ToList();

            
        }

        public DataTable GetTransactionLogsTable()
        {

            //IEnumerable<DataRow> query = (from t in _db.TransactionLogs.AsEnumerable()
            //                              select new
            //                              {
            //                                  t.TransactionDate,
            //                                  t.ProductCode,
            //                                  t.TargetWeight,
            //                                  t.Units

            //                              }) as IEnumerable<DataRow>;
            IEnumerable<DataRow> query = new TransactionLog
            {
                ProductId=1,
                TransactionDate =DateTime.Parse("2001, 8, 1"),
                ProductCode = "PROA",
                TargetWeight = 20,
                Units = "10",
                rowguid=new Guid()

            } as IEnumerable<DataRow>;



            DataTable boundTable = query.CopyToDataTable<DataRow>();
            return boundTable;

            //t.TransactionDate,
            //                                  t.ProductCode,
            //                                  t.TargetWeight,
            //                                  t.Units
        }

        public List<TransactionLog> GetTransactionLogsByProductCode(string productCode)
        {
            
                return _db.TransactionLogs
                    .Where(t=>t.ProductCode==productCode)
                    .ToList();

            
        }
    }
}
