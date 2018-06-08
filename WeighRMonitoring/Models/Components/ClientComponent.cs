using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeighRMonitoring.Models.Entities;

namespace WeighRMonitoring.Models.Components
{
    public class ClientComponent
    {
        //private readonly WeighRDbContext _db;
        //public ClientComponent(WeighRDbContext context)
        //{
        //    _db = context;

        //}
        WeighREntities _db = new WeighREntities();
        public void AddClient(Client client)
        {
            _db.Clients.Add(client);
            _db.SaveChanges();

        }
        public void UpdateClient(Client client)
        {
            _db.Clients.Attach(client);
            _db.SaveChanges();
        }

        public Client GetClient(string clientId)
        {
            return _db.Clients
                  .Where(p => p.ClientId == clientId).FirstOrDefault();

        }
        public List<Client> GetClients()
        {

            return _db.Clients.ToList();
        }

    }
}