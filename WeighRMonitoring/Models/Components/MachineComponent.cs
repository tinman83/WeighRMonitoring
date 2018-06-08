using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeighRMonitoring.Models.Entities;

namespace WeighRMonitoring.Models.Components
{
    public class MachineComponent
    {
        //private readonly WeighRDbContext _db;
        //public MachineComponent(WeighRDbContext context)
        //{
        //    _db = context;

        //}
        WeighREntities _db = new WeighREntities();
        public void AddMachine(Machine machine)
        {
            _db.Machines.Add(machine);
            _db.SaveChanges();

        }
        public void UpdateMachine(Machine machine)
        {
            _db.Machines.Attach(machine);
            _db.SaveChanges();
        }

        public Machine GetMachine(string serialNumber)
        {
            return _db.Machines
                  .Where(p => p.SerialNumber == serialNumber).FirstOrDefault();

        }
        public List<Machine> GetMachines()
        {

            return _db.Machines.ToList();
        }
    }
}