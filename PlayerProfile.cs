using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace The_Lead_Guard.Models
{
    public class PlayerProfile
    {
        [Key]


        public string F_Name { get; set; }
        public string L_Name { get; set; }
        public string DOB { get; set; }
        public string Arc_Type { get; set; }
        public string College { get; set; }
        public string Description { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public double Wingspan { get; set; }
        public string Position { get; set; }
        public string Player_ImageLocation { get; set; }
        public string SitePlayerPic { get; set; }


        //Stats

        public double Points { get; set; }

        public double Rebounds { get; set; }
        public double Assist { get; set; }
       public DateTime Season { get; set; }
       
        public int GP { get; set; }
        public double MP { get; set; }
        public double FG { get; set; }
        public double FGA { get; set; }
        public double FGP { get; set; }
        public double TPM { get; set; }
        public double TPA { get; set; }
        public double TPP { get; set; }
        public double THPM { get; set; }
        public double THPA { get; set; }
        public double THPP { get; set; }
        public double FTM { get; set; }
        public double FTA { get; set; }
        public double FTP { get; set; }
        public double ORebounds { get; set; }
        public double DRebounds { get; set; }
        public double TRebounds { get; set; }
        public double Steals { get; set; }
        public double Blocks { get; set; }
        public double TOS { get; set; }
        public double PFS { get; set; }

    }
}
