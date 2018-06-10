using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;

namespace WeighRMonitoring.Models.Entities
{
    public class WeighRDataContextConfiguration :DbConfiguration
    {
        public WeighRDataContextConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
        }
    }
}