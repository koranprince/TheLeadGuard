using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace The_Lead_Guard.Models
{
    public class Player_per_stats
    {
        [Key]
        public int Player_ID { get; set; }
        public float Points { get; set; }
        public int Player_TeamID { get; set; }
        public float Rebounds { get; set; }
        public float Assist { get; set; }
        public string Season { get; set; }
        public int Team_ID { get; set; }

        public int GP { get; set; }
        public float MP { get; set; }
        public float FG { get; set; }
        public float FGA { get; set; }
        public float FGP { get; set; }
        public float TPM { get; set; }
        public float TPA { get; set; }
        public float TPP { get; set; }
        public float THPM { get; set; }
        public float THPA { get; set; }
        public float THPP { get; set; }
        public float FTM { get; set; }
        public float FTA { get; set; }
        public float FTP { get; set; }
        public float ORebounds { get; set; }
        public float DRebounds { get; set; }
        public float TRebounds { get; set; }
        public float Steals { get; set; }
        public float Blocks { get; set; }
        public float TOS { get; set; }
        public float PFS { get; set; }

    }
}
