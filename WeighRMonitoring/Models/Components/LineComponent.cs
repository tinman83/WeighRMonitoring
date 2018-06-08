using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeighRMonitoring.Models.Entities;

namespace WeighRMonitoring.Models.Components
{
    public class LineComponent
    {
        //private readonly WeighRDbContext _db;
        //public LineComponent(WeighRDbContext context)
        //{
        //    _db = context;

        //}
        WeighREntities _db = new WeighREntities();
        public void AddLine(Line line)
        {
            _db.Lines.Add(line);
            _db.SaveChanges();

        }
        public void UpdateLine(Line line)
        {
            _db.Lines.Attach(line);
            _db.SaveChanges();
        }

        public Line GetLine(int lineId)
        {
            return _db.Lines
                  .Where(p => p.LineId == lineId).FirstOrDefault();

        }
        public List<Line> GetLinees()
        {

            return _db.Lines.ToList();
        }

    }
}