using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace The_Lead_Guard.Models
{
    public class Player_Description
    {
        [Key]
        public int Player_ID { get; set; }
        public string Description { get; set; }
    }
}
