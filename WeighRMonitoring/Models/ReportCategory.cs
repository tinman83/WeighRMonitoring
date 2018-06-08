using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WeighRMonitoring.Models
{
    public class ReportCategory
    {
        //Report Id  
        public int ID { get; set; }

        //Report Name  
        public string Name { get; set; }

        //Report Description  
        public string Description { get; set; }

        //Report Url  
        public string Url { get; set; }

        //represnts Parent ID and it's nullable  
        public int? ParentId { get; set; }
        [ForeignKey("ParentId")]
        public virtual ReportCategory Parent { get; set; }
        public virtual ICollection<ReportCategory> Childs { get; set; }
    }
}