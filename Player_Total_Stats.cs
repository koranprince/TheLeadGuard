using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace The_Lead_Guard.Models
{
    public class Player_Total_Stats
    {
        [Key]
        public int Player_ID { get; set; }
        public int Points { get; set; }
        public int Player_TeamID { get; set; }
        public int Rebounds { get; set; }
        public int Assist { get; set; }
        public string Season { get; set; }
        public int Team_ID { get; set; }
    }
}
