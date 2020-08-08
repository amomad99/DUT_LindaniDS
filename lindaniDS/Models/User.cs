using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lindaniDS.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Please provide with valid E-mail!")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "ID Number")]
        public int IDNumber { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
  
        public bool EmailVerify { get; set; }

        [Display(Name = "Activation Code")]
        public bool ActivationCode { get; set; }
    }
}