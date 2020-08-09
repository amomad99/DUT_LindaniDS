using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace lindaniDS.Models
{
    public class Learners
    {
        [Key]
        public int LearnerID { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("BookingPackages")]
        public int PackageID { get; set; }
        public virtual BookingPackages BookingPackages { get; set; }
    }
}