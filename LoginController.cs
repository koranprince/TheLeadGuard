using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using The_Lead_Guard.Models;
using static System.Net.Mime.MediaTypeNames;

namespace The_Lead_Guard.Controllers
{
    public class LoginController: Controller
    {

        private readonly Posting _db;
        private readonly IWebHostEnvironment _webHost;

        public LoginController(Posting db,IWebHostEnvironment webHost )
        {
            _db = db;
            this._webHost = webHost;
        }



        public IActionResult Login()
        {

            return View();

        }

        public IActionResult PLogin()
        {

            return View();

        }
        [HttpPost]
        public IActionResult PlayerInput(ModelView modelView)
        {
            //foreach (var name in modelView)
            //{


            //}
            bool ifplayerex = _db.Player.Where(p=>p.Player_ID==0).Any();
            
            int playerid = _db.Player.OrderByDescending(n=> n.Player_ID).Select(n=> n.Player_ID).Max() + 1;
            //if (playerid is null)
            //{


            //}
            //Player Table
            modelView.player.Player_ID = playerid;
           
                 

            modelView.PlayerInfo.Player_ID = playerid;

            modelView.Pstats.Team_ID = 0;
            modelView.Pstats.Player_ID = playerid;
            
            modelView.PlayerInfo.Player_TeamID = 0;

            //Player stats added
              

            Player_image PI = new Player_image();


            //Save Image to Players Image folder

            string wwwRootPaths = _webHost.WebRootPath;
            string wwwRootPath = @"C:\Users\koran\Pictures\PlayerPhotos";
            string fileName = Path.GetFileNameWithoutExtension(modelView.file.FileName);
            string extension = Path.GetExtension(modelView.file.FileName);
            fileName = fileName + DateTime.Now.ToString("yyddd") + extension;

       //C:\inetpub\wwwroot\TheLeadGuard\wwwroot\Images\PlayerPics 


            string paths = Path.Combine(wwwRootPath + "/Playerimages/", fileName);
            string path = Path.Combine(wwwRootPath, fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                modelView.file.CopyTo(fileStream);

            }

            //Inserting player information into database
            modelView.PlayerInfo.Player_ID = playerid;
            modelView.PD.Player_ID = playerid;

            PI.Player_ImageLocation = path;
            PI.Player_ID = playerid;
            _db.Player.Add(modelView.player);
            _db.SaveChanges();
            _db.Player_Description.Add(modelView.PD);
            _db.Player_Info.Add(modelView.PlayerInfo);
            _db.Player_per_stats.Add(modelView.Pstats);
            _db.Player_image.Add(PI);

            _db.SaveChanges();

            return View("PLogin");

        }


        public IActionResult LoginSelection()
        {

            return View();

        }
    }
}
