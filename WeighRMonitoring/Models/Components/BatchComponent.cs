using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeighRMonitoring.Models.Entities;

namespace WeighRMonitoring.Models.Components
{
   
    public class BatchComponent
    {
        //private readonly WeighRDbContext _db;
        //public BatchComponent(WeighRDbContext context)
        //{
        //    _db = context;

        //}
        WeighREntities _db = new WeighREntities();
        public void AddBatch(Batch Batch)
        {
                _db.Batches.Add(Batch);
                _db.SaveChanges();

        }
        public void UpdateBatch(Batch Batch)
        {
                _db.Batches.Attach(Batch);
                _db.SaveChanges();
        }

        public Batch GetBatch(int batchId)
        {
                return _db.Batches
                      .Where(p => p.BatchId == batchId).FirstOrDefault();

        }
        public List<Batch> GetBatches()
        {

                return _db.Batches.ToList();
        }

        public Batch SetCurrentBatch(string batchCode)
        {
            var previousCurrent = _db.Batches
                    .Where(p => p.isCurrent == true).FirstOrDefault();

            if (previousCurrent != null)
            {
                previousCurrent.EndTime = DateTime.Now;
                previousCurrent.isCurrent = false;
                _db.Batches.Attach(previousCurrent);
            }


            var current = _db.Batches
                .Where(p => p.BatchCode == batchCode).FirstOrDefault();

            current.isCurrent = true;
            _db.Batches.Attach(current);
            _db.SaveChanges();

            return current;
        }

        public Batch GetCurrentBatch()
        {
            return _db.Batches
                     .Where(p => p.isCurrent == true).FirstOrDefault();
        }
    }
}
