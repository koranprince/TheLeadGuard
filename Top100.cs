using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace The_Lead_Guard.Models
{
    public class Top100
    {
        [Key]
        public int Player_position { get; set; }
       
        public int Player_Id { get; set; }
    }
}
