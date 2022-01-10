using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using The_Lead_Guard.Models;


namespace The_Lead_Guard.Controllers
{
    public class MockController : Controller
    {
        private readonly Posting _db;

        public MockController(Posting db)
        {
            _db = db;
        }
        public IActionResult LoginSelection()
        {









            return View();

        }
        public IActionResult MockUpdate()
        {
            var mv = new LModelView();

            List<Teamnames> test = new List<Teamnames>();

            //List<ModelView> tps = new List<ModelView>();






            mv.team_ = _db.Team.Select(x => x).ToList();
            //var Draftposition = _db.Team_Player_Position.Join().Select(x => x).ToList();


            var draftposition= _db.MockDraft.Join(_db.Team, x => x.Team_ID, z => z.Team_ID, (MockDraft, Team) => new
            {

                Teams = MockDraft.Team_Position,
                TeamName = Team.Name
            });



            foreach (var name in draftposition)
            {

                test.Add(new Teamnames {Teams = name.TeamName, TeamName = name.Teams} );
            }
            mv.teamsnames = test;
            

            //foreach (var name in Teamnameid)
            //{

            //    mv.player.Add(new Player { Player_ID = name.Player_ID});
            //}

            //foreach (var name in Draftposition)
            //{

            //    tps.Add(new ModelView { team_Player_Position = name });
            //}









            return View(mv);

        }

        public IActionResult MockUpdateRound2()
        {
            var mv = new LModelView();

            List<Teamnames> test = new List<Teamnames>();

            //List<ModelView> tps = new List<ModelView>();






            mv.team_ = _db.Team.Select(x => x).ToList();
            //var Draftposition = _db.Team_Player_Position.Join().Select(x => x).ToList();


            var draftposition = _db.MockDraft2.Join(_db.Team, x => x.Team_ID, z => z.Team_ID, (MockDraft2, Team) => new
            {

                Teams = MockDraft2.Team_Position,
                TeamName = Team.Name
            });



            foreach (var name in draftposition)
            {

                test.Add(new Teamnames { Teams = name.TeamName, TeamName = name.Teams });
            }
            mv.teamsnames = test;


            //foreach (var name in Teamnameid)
            //{

            //    mv.player.Add(new Player { Player_ID = name.Player_ID});
            //}

            //foreach (var name in Draftposition)
            //{

            //    tps.Add(new ModelView { team_Player_Position = name });
            //}









            return View(mv);

        }

        public IActionResult Updatemock(int team,int Draftposition,int round)
        
        {
            LModelView mv = new LModelView();
            List<Teamnames> test = new List<Teamnames>();
            MockDraft p = new MockDraft();

            mv.team_ = _db.Team.Select(x => x).ToList();
            //p.Team_Position = Draftposition;
            p.Team_ID = team;
            p.Team_Position = Draftposition;
            p.Player_Id = 0;
            //p.Graphic_Id = "Test";
            //p.Player_position = 3;
            var confirm =_db.MockDraft.AsNoTracking().Select(x => x).Where(x=>x.Team_Position==Draftposition).ToList();
            var confirms = _db.MockDraft.Select(x => x).Where(x => x.Team_Position == Draftposition && x.Team_ID == team).ToList();
            
            

            if (confirm.Count() == 0)
            {
                _db.MockDraft.Add(p);

            }
            else if (confirm.Count() == 1)
            {
              
                p.Player_Id = confirm.Select(x => x.Player_Id).FirstOrDefault();
                //_db.Entry(p).CurrentValues.SetValues(p);
                _db.MockDraft.Update(p);
                //.Entry(group).CurrentValues.SetValues(model.Group)
            }


            _db.SaveChanges();
            //mv.team_Player_Position = _db.Team_Player_Position.Select(x => x).ToList();
            mv.MockDraft = _db.MockDraft.ToList();
            var draftposition = _db.MockDraft.Join(_db.Team, x => x.Team_ID, z => z.Team_ID, (MockDraft, Team) => new
            {

                Teams = MockDraft.Team_Position,
                TeamName = Team.Name
            });



            foreach (var name in draftposition)
            {

                test.Add(new Teamnames { Teams = name.TeamName, TeamName = name.Teams });
            }
            mv.teamsnames = test;
            return View("MockUpdate",mv);
        }



        public IActionResult Deletemock2()

        {
            Team_Player_Position p = new Team_Player_Position();
            var Delete = _db.Team_Player_Position.Remove(p);

            return View("MockUpdate");
        }

        public IActionResult UpdatemockRtwo(int team, int Draftposition, int round)

        {
            LModelView mv = new LModelView();
            List<Teamnames> test = new List<Teamnames>();
            MockDraft2 p = new MockDraft2();

            mv.team_ = _db.Team.Select(x => x).ToList();
            //p.Team_Position = Draftposition;
            p.Team_ID = team;
            p.Team_Position = Draftposition;
            p.Player_Id = 0;
            //p.Graphic_Id = "Test";
            //p.Player_position = 3;
            var confirm = _db.MockDraft2.AsNoTracking().Select(x => x).Where(x => x.Team_Position == Draftposition).ToList();
            var confirms = _db.MockDraft2.Select(x => x).Where(x => x.Team_Position == Draftposition && x.Team_ID == team).ToList();



            if (confirm.Count() == 0)
            {
                _db.MockDraft2.Add(p);

            }
            else if (confirm.Count() == 1)
            {

                p.Player_Id = confirm.Select(x => x.Player_Id).FirstOrDefault();
                //_db.Entry(p).CurrentValues.SetValues(p);
                _db.MockDraft2.Update(p);
                //.Entry(group).CurrentValues.SetValues(model.Group)
            }


            _db.SaveChanges();
            //mv.team_Player_Position = _db.Team_Player_Position.Select(x => x).ToList();
            mv.MockDraft2 = _db.MockDraft2.ToList();
            var draftposition = _db.MockDraft2.Join(_db.Team, x => x.Team_ID, z => z.Team_ID, (MockDraft2, Team) => new
            {

                Teams = MockDraft2.Team_Position,
                TeamName = Team.Name
            });



            foreach (var name in draftposition)
            {

                test.Add(new Teamnames { Teams = name.TeamName, TeamName = name.Teams });
            }
            mv.teamsnames = test;
            return View("MockUpdateRound2", mv);
        }

        public IActionResult Deletemock()

        {
            Team_Player_Position p = new Team_Player_Position();
            var Delete = _db.Team_Player_Position.Remove(p);

            return View("MockUpdate");
        }

        public IActionResult PlayerUpdate()
        {

            //Team information
            var mv = new LModelView();

            List<Teamnames> test = new List<Teamnames>();

            //List<ModelView> tps = new List<ModelView>();






            mv.team_ = _db.Team.Select(x => x).ToList();
            //var Draftposition = _db.Team_Player_Position.Join().Select(x => x).ToList();


            var draftposition = _db.MockDraft.Join(_db.Team, x => x.Team_ID, z => z.Team_ID, (MockDraft, Team) => new
            {

                Teams = MockDraft.Team_Position,
                TeamName = Team.Name
            });



            foreach (var name in draftposition)
            {

                test.Add(new Teamnames { Teams = name.TeamName, TeamName = name.Teams });
            }
            


            //Player information

            LModelView lModel = new LModelView();
            List<DraftOrder> draftOrderss = new List<DraftOrder>();
        

            
            
            List<ModelView> Lp = new List<ModelView>();

           
            var TeamgraphicJoin = _db.Team.Join(_db.Images, x => x.Team_ID, z => z.Graphic_ID, (team, images) => new
            {

                Teams = images.Graphic_Name,
                TeamID = team.Team_ID
            });
            foreach (var Teamnames in TeamgraphicJoin)
            {


                Lp.Add(new ModelView() { filename = @"~/Images/TeamPics/" + Teamnames.Teams });



            }

            var dro = TeamgraphicJoin.Join(_db.MockDraft, x => x.TeamID, z => z.Team_ID, (TeamgraphicJoin, MockDraft) => new
            {
                Team_Graphic = @"~/Images/TeamPics/" + TeamgraphicJoin.Teams,
                Team_ID = TeamgraphicJoin.TeamID,
                Player_Id = MockDraft.Player_Id,
                //Player_Position = Team_Player_Position.Player_position,
                TeamPosition = MockDraft.Team_Position








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
               // Player_Position = TeamgraphicJoin.Player_Position,
                TeamPosition = TeamgraphicJoin.TeamPosition,
                F_name = TeamgraphicJoin.F_name,
                L_name = TeamgraphicJoin.L_name,
                Playerpos = Playerinfo.Position







            }).OrderBy(x => x.TeamPosition).ToList();



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
            lModel.players = _db.Player.Select(x => x).Where(x=> x.Player_ID != 2 && x.Player_ID != 3).ToList();
            lModel.teamsnames =test ;







            return View(lModel);

        }

        public IActionResult PlayerUpdateRoundTwo()
        {

            //Team information
            var mv = new LModelView();

            List<Teamnames> test = new List<Teamnames>();

            //List<ModelView> tps = new List<ModelView>();






            mv.team_ = _db.Team.Select(x => x).ToList();
            //var Draftposition = _db.Team_Player_Position.Join().Select(x => x).ToList();


            var draftposition = _db.MockDraft2.Join(_db.Team, x => x.Team_ID, z => z.Team_ID, (MockDraft2, Team) => new
            {

                Teams = MockDraft2.Team_Position,
                TeamName = Team.Name
            });



            foreach (var name in draftposition)
            {

                test.Add(new Teamnames { Teams = name.TeamName, TeamName = name.Teams });
            }



            //Player information

            LModelView lModel = new LModelView();
            List<DraftOrder> draftOrderss = new List<DraftOrder>();




            List<ModelView> Lp = new List<ModelView>();


            var TeamgraphicJoin = _db.Team.Join(_db.Images, x => x.Team_ID, z => z.Graphic_ID, (team, images) => new
            {

                Teams = images.Graphic_Name,
                TeamID = team.Team_ID
            });
            foreach (var Teamnames in TeamgraphicJoin)
            {


                Lp.Add(new ModelView() { filename = @"~/Images/TeamPics/" + Teamnames.Teams });



            }

            var dro = TeamgraphicJoin.Join(_db.MockDraft2, x => x.TeamID, z => z.Team_ID, (TeamgraphicJoin, MockDraft2) => new
            {
                Team_Graphic = @"~/Images/TeamPics/" + TeamgraphicJoin.Teams,
                Team_ID = TeamgraphicJoin.TeamID,
                Player_Id = MockDraft2.Player_Id,
                //Player_Position = Team_Player_Position.Player_position,
                TeamPosition = MockDraft2.Team_Position








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
                // Player_Position = TeamgraphicJoin.Player_Position,
                TeamPosition = TeamgraphicJoin.TeamPosition,
                F_name = TeamgraphicJoin.F_name,
                L_name = TeamgraphicJoin.L_name,
                Playerpos = Playerinfo.Position







            }).OrderBy(x => x.TeamPosition).ToList();



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
            lModel.players = _db.Player.Select(x => x).Where(x => x.Player_ID != 2 && x.Player_ID != 3).ToList();
            lModel.teamsnames = test;







            return View(lModel);

        }

        public IActionResult PlayerMockUpdate(int player, int Draftposition, int round)

        {
            LModelView mv = new LModelView();
            List<Teamnames> test = new List<Teamnames>();
            MockDraft p = new MockDraft();

            mv.team_ = _db.Team.Select(x => x).ToList();
            //p.Team_Position = Draftposition;
           // p.Graphic_Id = "Test";
            p.Team_Position = Draftposition;
            p.Player_Id = player;
           
            //p.Player_position = 3;
            var confirm = _db.MockDraft.AsNoTracking().Select(x => x).Where(x => x.Team_Position == Draftposition).ToList();

            //var confirmplayerpositionexists = _db.MockDraft.AsNoTracking().Select(x => x).Where(x => x.Player_Id==player).ToList();
            //var TPosition = _db.MockDraft.AsNoTracking().Select(x => x).Where(x => x.Team_Position == Draftposition).ToList();
            //var confirms = _db.Team_Player_Position.Select(x => x).Where(x => x.Team_Position == Draftposition && x.Team_ID == team).ToList();

            p.Team_ID = confirm.Select(x => x.Team_ID).FirstOrDefault();

            if (confirm.Count() == 0)
            {
                _db.MockDraft.Add(p);

            }
            else if (confirm.Count() > 0)
            {

                //p.Player_position = confirmplayerpositionexists.Select(x => x.Player_position).FirstOrDefault();
                //_db.Entry(p).CurrentValues.SetValues(p);
                
                _db.MockDraft.Update(p);
                //.Entry(group).CurrentValues.SetValues(model.Group)
            }


            _db.SaveChanges();
            LModelView lModel = new LModelView();
            List<DraftOrder> draftOrderss = new List<DraftOrder>();




            List<ModelView> Lp = new List<ModelView>();


            var TeamgraphicJoin = _db.Team.Join(_db.Images, x => x.Team_ID, z => z.Graphic_ID, (team, images) => new
            {

                Teams = images.Graphic_Name,
                TeamID = team.Team_ID
            });
            foreach (var Teamnames in TeamgraphicJoin)
            {


                Lp.Add(new ModelView() { filename = @"~/Images/TeamPics/" + Teamnames.Teams });



            }

            var dro = TeamgraphicJoin.Join(_db.MockDraft, x => x.TeamID, z => z.Team_ID, (TeamgraphicJoin, MockDraft) => new
            {
                Team_Graphic = @"~/Images/TeamPics/" + TeamgraphicJoin.Teams,
                Team_ID = TeamgraphicJoin.TeamID,
                Player_Id = MockDraft.Player_Id,
                //Player_Position = Team_Player_Position.Player_position,
                TeamPosition = MockDraft.Team_Position








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







            }).OrderBy(x => x.TeamPosition).ToList();



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
            lModel.players = _db.Player.Select(x => x).ToList();
            lModel.teamsnames = test;

            






            return View("PlayerUpdate", lModel);
        }

        public IActionResult PlayerMockUpdateRoundTwo(int player, int Draftposition, int round)

        {
            LModelView mv = new LModelView();
            List<Teamnames> test = new List<Teamnames>();
            MockDraft2 p = new MockDraft2();

            mv.team_ = _db.Team.Select(x => x).ToList();
            //p.Team_Position = Draftposition;
            // p.Graphic_Id = "Test";
            p.Team_Position = Draftposition;
            p.Player_Id = player;

            //p.Player_position = 3;
            var confirm = _db.MockDraft2.AsNoTracking().Select(x => x).Where(x => x.Team_Position == Draftposition).ToList();

            //var confirmplayerpositionexists = _db.MockDraft.AsNoTracking().Select(x => x).Where(x => x.Player_Id==player).ToList();
            //var TPosition = _db.MockDraft.AsNoTracking().Select(x => x).Where(x => x.Team_Position == Draftposition).ToList();
            //var confirms = _db.Team_Player_Position.Select(x => x).Where(x => x.Team_Position == Draftposition && x.Team_ID == team).ToList();

            p.Team_ID = confirm.Select(x => x.Team_ID).FirstOrDefault();

            if (confirm.Count() == 0)
            {
                _db.MockDraft2.Add(p);

            }
            else if (confirm.Count() > 0)
            {

                //p.Player_position = confirmplayerpositionexists.Select(x => x.Player_position).FirstOrDefault();
                //_db.Entry(p).CurrentValues.SetValues(p);

                _db.MockDraft2.Update(p);
                //.Entry(group).CurrentValues.SetValues(model.Group)
            }


            _db.SaveChanges();
            LModelView lModel = new LModelView();
            List<DraftOrder> draftOrderss = new List<DraftOrder>();




            List<ModelView> Lp = new List<ModelView>();


            var TeamgraphicJoin = _db.Team.Join(_db.Images, x => x.Team_ID, z => z.Graphic_ID, (team, images) => new
            {

                Teams = images.Graphic_Name,
                TeamID = team.Team_ID
            });
            foreach (var Teamnames in TeamgraphicJoin)
            {


                Lp.Add(new ModelView() { filename = @"~/Images/TeamPics/" + Teamnames.Teams });



            }

            var dro = TeamgraphicJoin.Join(_db.MockDraft2, x => x.TeamID, z => z.Team_ID, (TeamgraphicJoin, MockDraft2) => new
            {
                Team_Graphic = @"~/Images/TeamPics/" + TeamgraphicJoin.Teams,
                Team_ID = TeamgraphicJoin.TeamID,
                Player_Id = MockDraft2.Player_Id,
                //Player_Position = Team_Player_Position.Player_position,
                TeamPosition = MockDraft2.Team_Position








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







            }).OrderBy(x => x.TeamPosition).ToList();



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
            lModel.players = _db.Player.Select(x => x).ToList();
            lModel.teamsnames = test;








            return View("PlayerUpdateRoundTwo", lModel);
        }

    }
}
