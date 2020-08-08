using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace lindaniDS.Models
{
    public class Hire
    {
        [Key]
        public int HireID { get; set; }

        [ForeignKey("VehicleModel")]  
        public int modelID { get; set; }
        public virtual VehicleModel VehicleModel { get; set; }

        [ForeignKey("VehicleModel")]
        public int vehicleID { get; set; }
        public virtual VehicleHire VehicleHire { get; set; }

        [ForeignKey("VehicleModel")]   
        public int UserID { get; set; }
        public virtual User User { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Please provide with valid E-mail!")]
        [Display(Name = "Email")]
        public DateTime PickDate { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Please provide with valid E-mail!")]
        [Display(Name = "Email")]
        public DateTime DropDate { get; set; }

        [ForeignKey("VehicleModel")]
        [StringLength(50, ErrorMessage = "Please provide with valid E-mail!")]
        [Display(Name = "Email")]
        public string AddressID { get; set; }
        public virtual Address Address { get; set; }



    }
}