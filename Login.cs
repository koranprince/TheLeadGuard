using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace The_Lead_Guard.Models
{
    public class Login
    {
        [Key]
        public int Login_ID { get; set; }
        public string Login_FName { get; set; }
        public int Login_LName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
       
    }
}
