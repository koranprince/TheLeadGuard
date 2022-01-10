using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace The_Lead_Guard.Models
{
    public class Player
    {
        [Key]
        public int Player_ID { get; set; }
        public string F_Name { get; set; }
        public string L_Name { get; set; }
        public string DOB { get; set; }
        


    }
}
