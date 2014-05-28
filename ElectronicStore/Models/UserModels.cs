using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ElectronicStore.Models
{

    public class login
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string password { get; set; }
    }

    public class register
    {
        [Required]
        public string Username { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password),
        Compare("Password", ErrorMessage = "Passwords do not match")]
        public string Confirmpassword { get; set; }
    }


  



   
}