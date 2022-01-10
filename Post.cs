using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.VisualBasic;
using Microsoft.Data.SqlClient;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace The_Lead_Guard.Models
{
    public class Posting:DbContext
    {
    public DbSet<Login> Jobs { get; set; }
    public DbSet<Images> Images { get; set; }
    public DbSet<Login> Login { get; set; }
    public DbSet<Player> Player { get; set; }
    public DbSet<Player_Description> Player_Description { get; set; }
    public DbSet<ModelView> ModelViews { get; set; }

     public DbSet<Player_image> Player_image { get; set; }
     public DbSet<Player_Info> Player_Info { get; set; }
     public DbSet<Player_per_stats> Player_per_stats { get; set; }
     public DbSet<Player_Total_Stats> Player_Total_Stats { get; set; }
     public DbSet<Subscriber_Table> Subscriber_Table { get; set; }
     public DbSet<Team> Team { get; set; }
     public DbSet<Team_Player_Position> Team_Player_Position { get; set; }
     public DbSet<Team_Player_Position> Team_Player_Positionupdate { get; set; }
     public DbSet<PlayerProfile> PlayerProfile { get; set; }
     public DbSet<MockDraft> MockDraft { get; set; }
     public DbSet<MockDraft2> MockDraft2 { get; set; }
    public DbSet<Top100> Top100 { get; set; }




        public Posting(DbContextOptions<Posting> option )
    : base(option)
        {
         
                     
           }





        public List<PlayerProfile> PlayerInfo(string Id)
        {
            List<string> Lnames = new List<string>();

            var names = Id;
            var underwriterParam = new SqlParameter("@PlayerID", names);
            var fnames = PlayerProfile.FromSqlRaw("Execute PlayerProfile @PlayerID", underwriterParam).ToList();

          

            return fnames;

        }

    }
   
}
