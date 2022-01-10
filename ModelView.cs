using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace The_Lead_Guard.Models
{
    public class ModelView
    {               
      [Key]
        public int player_id { get; set; }
        public Player player { get; set; }
        public Player_image Pimage { get; set; }
        public Player_per_stats Pstats { get; set; }
        public Player_Info PlayerInfo { get; set; }
        public Player_Description PD { get; set; }
        public string filename { get; set; }
        public Team_Player_Position team_Player_Position { get; set; }
        public Team team_ { get; set; }

        

        public string Teamname { get; set; }

        public int TeamPosition { get; set; }


        [NotMapped]
        public IFormFile file { get; set; }

    }
}
