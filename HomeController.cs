using Microsoft.AspNetCore.Mvc;
using System;

using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using The_Lead_Guard.Models;
using Microsoft.AspNetCore.Hosting;


namespace The_Lead_Guard.Controllers
{
    public class HomeController : Controller
    {
        private readonly Posting _db;
        private readonly IWebHostEnvironment web;
       
        public HomeController(Posting db,IWebHostEnvironment web)
        {
            _db = db;
            this.web = web;
        }
        public IActionResult Index()
        {
            LModelView lModel = new LModelView();
            List<DraftOrder> draftOrderss = new List<DraftOrder>();
            DirectoryInfo directory = new DirectoryInfo(web.WebRootPath + "/Images/TeamPics/");

            foreach (FileInfo file in directory.GetFiles())
            {
                file.Delete();
            }

            
            var Playerimages= _db.Images.Select(x=>x.File_Location +"\\"+ x.Graphic_Name).ToList();
            foreach (var playerimage in Playerimages)
            {
               string[] pnames= playerimage.Split("\\");

                System.IO.File.Copy(playerimage, web.WebRootPath + "/Images/TeamPics/"+pnames[5]);

            }
            ModelView mv = new ModelView();
            List<ModelView> Lp = new List<ModelView>();
            
            var test = _db.Player.Select(x => x).ToList();
            Player p = new Player();
            var TeamgraphicJoin = _db.Team.Join(_db.Images, x => x.Team_ID, z => z.Graphic_ID, (team, images) => new
            {

                Teams = images.Graphic_Name,
                TeamID = team.Team_ID
            });
            foreach (var Teamnames in TeamgraphicJoin)
            {


                Lp.Add(new ModelView() {filename = @"~/Images/TeamPics/" + Teamnames.Teams });



            }

            var dro = TeamgraphicJoin.Join(_db.MockDraft, x => x.TeamID, z => z.Team_ID, (TeamgraphicJoin, mocks) => new
            {
                Team_Graphic = @"~/Images/TeamPics/" + TeamgraphicJoin.Teams,
                Team_ID = TeamgraphicJoin.TeamID,
                Player_Id = mocks.Player_Id,
                //Player_Position = mocks.Player_position,
                TeamPosition = mocks.Team_Position






            

        }).Join(_db.Player, x=>x.Player_Id, y=>y.Player_ID, (TeamgraphicJoin, Player) => new
            {
                Team_Graphic = TeamgraphicJoin.Team_Graphic,
                Team_ID = TeamgraphicJoin.Team_ID,
                Player_Id = TeamgraphicJoin.Player_Id,
                //Player_Position = TeamgraphicJoin.Player_Position,
                TeamPosition = TeamgraphicJoin.TeamPosition,
                F_name=Player.F_Name,
                L_name=Player.L_Name







    }).Join(_db.Player_Info, x => x.Player_Id, y => y.Player_ID, (TeamgraphicJoin, Playerinfo) => new
            {
                Team_Graphic = TeamgraphicJoin.Team_Graphic,
                Team_ID = TeamgraphicJoin.Team_ID,
                Player_Id = TeamgraphicJoin.Player_Id,
               // Player_Position = TeamgraphicJoin.Player_Position,
                TeamPosition = TeamgraphicJoin.TeamPosition,
                F_name = TeamgraphicJoin.F_name,
                L_name = TeamgraphicJoin.L_name,
                Playerpos=Playerinfo.Position







}).OrderBy(x => x.TeamPosition).Take(14).ToList();



foreach (var name in dro)
{

    draftOrderss.Add(new DraftOrder
    {
        Player_Id = name.Player_Id,
        F_Name = name.F_name,
        Team_Graphic = name.Team_Graphic,
        L_Name = name.L_name,
        Team_ID = name.Team_ID,
        //Player_Position = name.Player_Position,
        TeamPosition = name.TeamPosition,
        Position = name.Playerpos



    });
}

lModel.draftOrders = draftOrderss;



return View(lModel);

        }
        public IActionResult Indexs()
        {
            LModelView lModel = new LModelView();
            List<DraftOrder> draftOrderss = new List<DraftOrder>();
            List<DraftOrder> draftOrderssT = new List<DraftOrder>();
            DirectoryInfo directory = new DirectoryInfo(web.WebRootPath + "/Images/TeamPics/");

            foreach (FileInfo file in directory.GetFiles())
            {
                file.Delete();
            }


            var Playerimages = _db.Images.Select(x => x.File_Location + "\\" + x.Graphic_Name).ToList();
            foreach (var playerimage in Playerimages)
            {
                string[] pnames = playerimage.Split("\\");

                System.IO.File.Copy(playerimage, web.WebRootPath + "/Images/TeamPics/" + pnames[5]);

            }
            ModelView mv = new ModelView();
            List<ModelView> Lp = new List<ModelView>();

            var test = _db.Player.Select(x => x).ToList();
            Player p = new Player();
            var TeamgraphicJoin = _db.Team.Join(_db.Images, x => x.Team_ID, z => z.Graphic_ID, (team, images) => new
            {

                Teams = images.Graphic_Name,
                TeamID = team.Team_ID
            });
            foreach (var Teamnames in TeamgraphicJoin)
            {


                Lp.Add(new ModelView() { filename = @"~/Images/TeamPics/" + Teamnames.Teams });



            }

            var dro = TeamgraphicJoin.Join(_db.MockDraft, x => x.TeamID, z => z.Team_ID, (TeamgraphicJoin, mocks) => new
            {
                Team_Graphic = @"~/Images/TeamPics/" + TeamgraphicJoin.Teams,
                Team_ID = TeamgraphicJoin.TeamID,
                Player_Id = mocks.Player_Id,
                
                TeamPosition = mocks.Team_Position








            }).Join(_db.Player, x => x.Player_Id, y => y.Player_ID, (TeamgraphicJoin, Player) => new
            {
                Team_Graphic = TeamgraphicJoin.Team_Graphic,
                Team_ID = TeamgraphicJoin.Team_ID,
                Player_Id = TeamgraphicJoin.Player_Id,
                //Player_Position = TeamgraphicJoin.Player_Position,
                TeamPosition = TeamgraphicJoin.TeamPosition,
                F_name = Player.F_Name,
                L_name = Player.L_Name







            }).Join(_db.Player_Info, x => x.Player_Id, y => y.Player_ID, (TeamgraphicJoin, Playerinfo) => new
            {
                Team_Graphic = TeamgraphicJoin.Team_Graphic,
                Team_ID = TeamgraphicJoin.Team_ID,
                Player_Id = TeamgraphicJoin.Player_Id,
                //Player_Position = TeamgraphicJoin.Player_Position,
                TeamPosition = TeamgraphicJoin.TeamPosition,
                F_name = TeamgraphicJoin.F_name,
                L_name = TeamgraphicJoin.L_name,
                Playerpos = Playerinfo.Position







            }).OrderBy(x => x.TeamPosition).Take(32).ToList();



            foreach (var name in dro)
            {

                draftOrderss.Add(new DraftOrder
                {
                    Player_Id = name.Player_Id,
                    F_Name = name.F_name,
                    Team_Graphic = name.Team_Graphic,
                    L_Name = name.L_name,
                    Team_ID = name.Team_ID,
                    //Player_Position = name.Player_Position,
                    TeamPosition = name.TeamPosition,
                    Position = name.Playerpos



                });
            }

            lModel.draftOrders = draftOrderss;


            //Round Two

            var drotwo = TeamgraphicJoin.Join(_db.MockDraft2, x => x.TeamID, z => z.Team_ID, (TeamgraphicJoin, mocks) => new
            {
                Team_Graphic = @"~/Images/TeamPics/" + TeamgraphicJoin.Teams,
                Team_ID = TeamgraphicJoin.TeamID,
                Player_Id = mocks.Player_Id,

                TeamPosition = mocks.Team_Position








            }).Join(_db.Player, x => x.Player_Id, y => y.Player_ID, (TeamgraphicJoin, Player) => new
            {
                Team_Graphic = TeamgraphicJoin.Team_Graphic,
                Team_ID = TeamgraphicJoin.Team_ID,
                Player_Id = TeamgraphicJoin.Player_Id,
                //Player_Position = TeamgraphicJoin.Player_Position,
                TeamPosition = TeamgraphicJoin.TeamPosition,
                F_name = Player.F_Name,
                L_name = Player.L_Name







            }).Join(_db.Player_Info, x => x.Player_Id, y => y.Player_ID, (TeamgraphicJoin, Playerinfo) => new
            {
                Team_Graphic = TeamgraphicJoin.Team_Graphic,
                Team_ID = TeamgraphicJoin.Team_ID,
                Player_Id = TeamgraphicJoin.Player_Id,
                //Player_Position = TeamgraphicJoin.Player_Position,
                TeamPosition = TeamgraphicJoin.TeamPosition,
                F_name = TeamgraphicJoin.F_name,
                L_name = TeamgraphicJoin.L_name,
                Playerpos = Playerinfo.Position







            }).OrderBy(x => x.TeamPosition).Take(32).ToList();



            foreach (var name in drotwo)
            {

                draftOrderssT.Add(new DraftOrder
                {
                    Player_Id = name.Player_Id,
                    F_Name = name.F_name,
                    Team_Graphic = name.Team_Graphic,
                    L_Name = name.L_name,
                    Team_ID = name.Team_ID,
                    //Player_Position = name.Player_Position,
                    TeamPosition = name.TeamPosition,
                    Position = name.Playerpos



                });
            }

            lModel.draftOrdersTwo = draftOrderssT;

            return View("index",lModel);

        }

        public IActionResult RoundTwo()
        {
            LModelView lModel = new LModelView();
            List<DraftOrder> draftOrderss = new List<DraftOrder>();
            DirectoryInfo directory = new DirectoryInfo(web.WebRootPath + "/Images/TeamPics/");

            foreach (FileInfo file in directory.GetFiles())
            {
                file.Delete();
            }


            var Playerimages = _db.Images.Select(x => x.File_Location + "\\" + x.Graphic_Name).ToList();
            foreach (var playerimage in Playerimages)
            {
                string[] pnames = playerimage.Split("\\");

                System.IO.File.Copy(playerimage, web.WebRootPath + "/Images/TeamPics/" + pnames[5]);

            }
            ModelView mv = new ModelView();
            List<ModelView> Lp = new List<ModelView>();

            var test = _db.Player.Select(x => x).ToList();
            Player p = new Player();
            var TeamgraphicJoin = _db.Team.Join(_db.Images, x => x.Team_ID, z => z.Graphic_ID, (team, images) => new
            {

                Teams = images.Graphic_Name,
                TeamID = team.Team_ID
            });
            foreach (var Teamnames in TeamgraphicJoin)
            {


                Lp.Add(new ModelView() { filename = @"~/Images/TeamPics/" + Teamnames.Teams });



            }

            var dro = TeamgraphicJoin.Join(_db.MockDraft, x => x.TeamID, z => z.Team_ID, (TeamgraphicJoin, mocks) => new
            {
                Team_Graphic = @"~/Images/TeamPics/" + TeamgraphicJoin.Teams,
                Team_ID = TeamgraphicJoin.TeamID,
                Player_Id = mocks.Player_Id,

                TeamPosition = mocks.Team_Position








            }).Join(_db.Player, x => x.Player_Id, y => y.Player_ID, (TeamgraphicJoin, Player) => new
            {
                Team_Graphic = TeamgraphicJoin.Team_Graphic,
                Team_ID = TeamgraphicJoin.Team_ID,
                Player_Id = TeamgraphicJoin.Player_Id,
                //Player_Position = TeamgraphicJoin.Player_Position,
                TeamPosition = TeamgraphicJoin.TeamPosition,
                F_name = Player.F_Name,
                L_name = Player.L_Name







            }).Join(_db.Player_Info, x => x.Player_Id, y => y.Player_ID, (TeamgraphicJoin, Playerinfo) => new
            {
                Team_Graphic = TeamgraphicJoin.Team_Graphic,
                Team_ID = TeamgraphicJoin.Team_ID,
                Player_Id = TeamgraphicJoin.Player_Id,
                //Player_Position = TeamgraphicJoin.Player_Position,
                TeamPosition = TeamgraphicJoin.TeamPosition,
                F_name = TeamgraphicJoin.F_name,
                L_name = TeamgraphicJoin.L_name,
                Playerpos = Playerinfo.Position







            }).OrderBy(x => x.TeamPosition).Take(30).ToList();



            foreach (var name in dro)
            {

                draftOrderss.Add(new DraftOrder
                {
                    Player_Id = name.Player_Id,
                    F_Name = name.F_name,
                    Team_Graphic = name.Team_Graphic,
                    L_Name = name.L_name,
                    Team_ID = name.Team_ID,
                    //Player_Position = name.Player_Position,
                    TeamPosition = name.TeamPosition,
                    Position = name.Playerpos



                });
            }

            lModel.draftOrders = draftOrderss;


            return View("index", lModel);

        }


    }
}
