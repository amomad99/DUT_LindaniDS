using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace lindaniDS.Models
{
    public class payment
    {
        [Key]
        public int HireID { get; set; }

        [ForeignKey("VehicleModel")]
        public int modelID { get; set; }
        public virtual VehicleModel VehicleModel { get; set; }
    
        [ForeignKey("VehicleModel")]
        public int UserID { get; set; }
        public virtual VehicleModel User { get; set; }

        public DateTime Date { get; set; }
     
        public string PayType { get; set; }

     

    }
}