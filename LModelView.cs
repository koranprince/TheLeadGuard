using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace The_Lead_Guard.Models
{
    public class LModelView
    {               
      
        //public int player_id { get; set; }
        //public List<Player> player { get; set; }
        //public Player_image Pimage { get; set; }
        //public Player_per_stats Pstats { get; set; }
        //public Player_Info PlayerInfo { get; set; }
        //public Player_Description PD { get; set; }
        //public string filename { get; set; }
        //public Team_Player_Position team_Player_Position { get; set; }
        public List<Team> team_ { get; set; }
        public List<Teamnames> teamsnames { get; set; }
        public List<MockDraft> MockDraft { get; set; }
        public List<Top100> Top100 { get; set; }
        public List<MockDraft2> MockDraft2 { get; set; }
        public List<DraftOrder> draftOrders { get; set; }
        public List<DraftOrder> draftOrdersTwo { get; set; }

        public List<Player> players { get; set; }
        //public string Teamname { get; set; }

        //public int TeamPosition { get; set; }


        //[NotMapped]
        //public IFormFile file { get; set; }

    }
}
