using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace The_Lead_Guard.Models
{
    public class DraftOrder
    {
        
        public int Player_Id { get; set; }
        public string F_Name { get; set; }
        public string L_Name { get; set; }
        public string Team_Graphic { get; set; }

        public int Team_ID { get; set; }
        public int Player_Position { get; set; }
        public int TeamPosition { get; set; }
        public string Position { get; set; }



    }
}
