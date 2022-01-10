using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using The_Lead_Guard.Models;
using System.IO;

namespace The_Lead_Guard.Controllers
{
    public class PlayerInfoController : Controller
    {
        private readonly Posting _db;

        public PlayerInfoController(Posting db)
        {
            _db = db;

            }
        public IActionResult PlayerInfo(string test)
        {

            DirectoryInfo directory = new DirectoryInfo(@"C:\inetpub\wwwroot\TheLeadGuard\wwwroot\Images\PlayerPics\");
        //C:\Users\koran\source\repos\The Lead Guard\The Lead Guard\wwwroot\Images\PlayerPics\
        //C:\inetpub\wwwroot\TheLeadGuard\wwwroot\Images\PlayerPics\

            foreach (FileInfo file in directory.GetFiles())
            {
                file.Delete();
            }
            
            var playerInfo= _db.PlayerInfo(test).FirstOrDefault();
           
            

            string NewPl = playerInfo.Player_ImageLocation.Replace(@"C:\Users\koran\Pictures\PlayerPhotos\", @"C:\inetpub\wwwroot\TheLeadGuard\wwwroot\Images\PlayerPics\");
            


                System.IO.File.Copy(playerInfo.Player_ImageLocation, NewPl);

            
            

            playerInfo.Player_ImageLocation = playerInfo.Player_ImageLocation.Replace(@"C:\Users\koran\Pictures\PlayerPhotos\", @"~/Images/PlayerPics/");
            // string playerstring =playerInfo.Height.ToString();

            //playerInfo.Height=Convert.ToDouble(playerstring.Replace(".", "'"));
            // string playerstrings = playerInfo.Weight.ToString();

            // playerInfo.Weight = Convert.ToDouble(playerstrings.Replace(".", "'"));
            // string playerstringss = playerInfo.Wingspan.ToString();

            // playerInfo.Weight = Convert.ToDouble(playerstringss.Replace(".", "'"));
            playerInfo.SitePlayerPic = "http://www.theleadguard.com" + playerInfo.Player_ImageLocation.Replace(@"~/Images/PlayerPics/", @"/Images/PlayerPics/");

            playerInfo.Wingspan = Math.Round(playerInfo.Wingspan,2);
            playerInfo.Assist = Math.Round(playerInfo.Assist, 2);
            playerInfo.Blocks = Math.Round(playerInfo.Blocks, 2);
            playerInfo.DRebounds = Math.Round(playerInfo.DRebounds, 2);
            playerInfo.FG = Math.Round(playerInfo.FG, 2);
            playerInfo.FGA = Math.Round(playerInfo.FGA, 2);
            playerInfo.FGP = Math.Round(playerInfo.FGP, 2);
            playerInfo.FTA = Math.Round(playerInfo.FTA, 2);
            playerInfo.FTM = Math.Round(playerInfo.FTM, 2);
            playerInfo.FTP = Math.Round(playerInfo.FTP, 2);
            
            playerInfo.Height = Math.Round(playerInfo.Height, 2);
            playerInfo.MP = Math.Round(playerInfo.MP, 2);
            playerInfo.ORebounds = Math.Round(playerInfo.ORebounds, 2);
            playerInfo.PFS = Math.Round(playerInfo.PFS, 2);
            playerInfo.Points = Math.Round(playerInfo.Points, 2);
            playerInfo.Rebounds = Math.Round(playerInfo.Rebounds, 2);
            playerInfo.Steals = Math.Round(playerInfo.Steals, 2);
            playerInfo.THPA = Math.Round(playerInfo.THPA, 2);

            playerInfo.THPM = Math.Round(playerInfo.THPM, 2);
            playerInfo.THPP = Math.Round(playerInfo.THPP, 2);
            playerInfo.TOS = Math.Round(playerInfo.TOS, 2);
            playerInfo.TPA = Math.Round(playerInfo.TPA, 2);
            playerInfo.TPM = Math.Round(playerInfo.TPM, 2);
            playerInfo.TPP = Math.Round(playerInfo.TPP, 2);
            playerInfo.TRebounds = Math.Round(playerInfo.TRebounds, 2);
            playerInfo.Weight = Math.Round(playerInfo.Weight, 2);

            playerInfo.Wingspan = Math.Round(playerInfo.Wingspan, 2);
            //int year = playerInfo.Season.Year;
            


            return View("PlayerProfile", playerInfo);

        }

    }
}
