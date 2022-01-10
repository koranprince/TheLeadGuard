using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace The_Lead_Guard.Models
{
    public class Player_Info
    {
        [Key]
        public int Player_ID { get; set; }
        public string Position { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public float Wingspan { get; set; }
        public int Player_TeamID { get; set; }
        public string College { get; set; }
        public string Arc_Type { get; set; }

    }
   
}
