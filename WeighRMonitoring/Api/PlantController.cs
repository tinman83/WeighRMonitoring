using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeighRMonitoring.Models.Components;
using WeighRMonitoring.Models.Entities;

namespace WeighRMonitoring.Api
{
    public class PlantController : ApiController
    {

        // GET: api/Dashboard
        public List<Plant> GetPlants()
        {
            PlantComponent plantComp = new PlantComponent();

            return plantComp.GetPlants();
        }
    }
}
