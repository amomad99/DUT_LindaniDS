using lindaniDS.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace lindaniDS.ViewModels
{
    public class HireViewModels
    {
        [Key]
        public int HireID { get; set; }
        
        public int vehicleID { get; set; }
        

     
        public int UserID { get; set; }
        

        [Required]
        [Display(Name = "PickDate")]
        public DateTime PickDate { get; set; }

        [Required]
        [Display(Name = "DropDate")]
        public DateTime DropDate { get; set; }

      
        [Display(Name = "Address")]
        public int AddreessID { get; set; }
        public IEnumerable<Address> Address { get; set; }
        public IEnumerable<VehicleHire> VehicleHire { get; set; }
        public IEnumerable<User> User { get; set; }
    }
}