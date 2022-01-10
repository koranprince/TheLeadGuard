using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace The_Lead_Guard.Models
{
    public class Team_Player_Position
    {
        [Key]
        public int Team_Position { get; set; }
        public int Player_ID { get; set; }
        public string Graphic_Id { get; set; }
        public int Team_ID { get; set; }
        
        public int Player_position { get; set; }
     

    }
}
