using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeighRMonitoring.Models.Entities;

namespace WeighRMonitoring.Models.Components
{
    public class PlantComponent
    {
        //private readonly WeighRDbContext _db;
        //public PlantComponent(WeighRDbContext context)
        //{
        //    _db = context;

        //}
        WeighREntities _db = new WeighREntities();
        public void AddPlant(Plant plant)
        {
            _db.Plants.Add(plant);
            _db.SaveChanges();

        }
        public void UpdatePlant(Plant plant)
        {
            _db.Plants.Attach(plant);
            _db.SaveChanges();
        }

        public Plant GetPlant(int plantId)
        {
            return _db.Plants
                  .Where(p => p.PlantId == plantId).FirstOrDefault();

        }
        public List<Plant> GetPlants()
        {

            return _db.Plants.ToList();
        }

    }
}