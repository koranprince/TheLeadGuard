using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;
using The_Lead_Guard.Models;


namespace The_Lead_Guard.Controllers
{
    public class Top100Controller: Controller
    {

        private readonly Posting _db;

        public Top100Controller(Posting db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var mv = new LModelView();

            List<DraftOrder> test = new List<DraftOrder>();

            //List<ModelView> tps = new List<ModelView>();






            mv.players = _db.Player.Select(x => x).ToList();
            //var Draftposition = _db.Team_Player_Position.Join().Select(x => x).ToList();


            var draftposition = _db.Top100.Join(_db.Player, x => x.Player_Id, z => z.Player_ID, (Top100, Player) => new
            {

                Player_FName = Player.F_Name,
                Player_LName = Player.L_Name,
                Player_ID = Player.Player_ID,
                PlayerPosition = Top100.Player_position
            }).Join(_db.Player_Info,x=>x.Player_ID,z=>z.Player_ID,(Top100, Playerinfo) => new
            {

                Player_FName = Top100.Player_FName,
                Player_LName = Top100.Player_LName,
                Player_ID = Top100.Player_ID,
                PlayerPosition = Top100.PlayerPosition,
                Playerinfo.Position
            }).OrderBy(x => x.PlayerPosition).ToList();



            foreach (var name in draftposition)
            {

                test.Add(new DraftOrder { Player_Id = name.Player_ID, F_Name = name.Player_FName, L_Name = name.Player_LName, Player_Position = name.PlayerPosition,Position=name.Position });
            }
            mv.draftOrders = test;





            return View(mv);

        }
        public IActionResult Top()
        {

            var mv = new LModelView();

            List<DraftOrder> test = new List<DraftOrder>();

            //List<ModelView> tps = new List<ModelView>();






            mv.players = _db.Player.Select(x => x).ToList();
            //var Draftposition = _db.Team_Player_Position.Join().Select(x => x).ToList();


            var draftposition = _db.Top100.Join(_db.Player, x => x.Player_Id, z => z.Player_ID, (Top100, Player) => new
            {

                Player_FName = Player.F_Name,
                Player_LName = Player.L_Name,
                Player_ID = Player.Player_ID,
                PlayerPosition= Top100.Player_position
            }).OrderBy(x=>x.PlayerPosition).ToList();



            foreach (var name in draftposition)
            {

                test.Add(new DraftOrder { Player_Id = name.Player_ID, F_Name = name.Player_FName,L_Name=name.Player_LName,Player_Position=name.PlayerPosition });
            }
            mv.draftOrders = test;
            




            return View(mv);

        }
        public IActionResult PlayerPositionUpdate(int player, int Draftposition, int round)
        {

            LModelView mv = new LModelView();
            List<Teamnames> test = new List<Teamnames>();
            Top100 p = new Top100();

            mv.team_ = _db.Team.Select(x => x).ToList();
            //p.Team_Position = Draftposition;
            //p.Graphic_Id = "Test";
          // int Team_Positions =0;
           

            p.Player_Id = player;

            p.Player_position = Draftposition;
            var confirm = _db.Top100.AsNoTracking().Select(x => x).Where(x => x.Player_position == Draftposition || x.Player_Id == player).ToList();
            //var confirms = _db.Top100.Select(x => x).Max(x=>x.Team_Position) + 1;


           // p.Team_ID = confirm.Select(x => x.Team_ID).FirstOrDefault();

            if (confirm.Count() == 0)
            {
                //p.Team_Position = confirms;
                _db.Top100.Add(p);

            }
            else if (confirm.Count() > 0)
            {
               // p.Team_Position = confirm.Select(x=>x.Team_Position).First();
                //_db.Entry(p).CurrentValues.SetValues(p);
                _db.Top100.Update(p);
                //.Entry(group).CurrentValues.SetValues(model.Group)
            }


            _db.SaveChanges();
            LModelView lModel = new LModelView();
            

            List<DraftOrder> lModels = new List<DraftOrder>();


            var draftposition = _db.Top100.Join(_db.Player, x => x.Player_Id, z => z.Player_ID, (Top100, Player) => new
            {

                Player_FName = Player.F_Name,
                Player_LName = Player.L_Name,
                Player_ID = Player.Player_ID,
                PlayerPosition = Top100.Player_position
            }).OrderBy(x => x.PlayerPosition).ToList();



            foreach (var name in draftposition)
            {

                lModels.Add(new DraftOrder { Player_Id = name.Player_ID, F_Name = name.Player_FName, L_Name = name.Player_LName, Player_Position = name.PlayerPosition });
            }
            mv.draftOrders = lModels;



            lModel.draftOrders = mv.draftOrders;
            lModel.players = _db.Player.Select(x => x).ToList();
            lModel.teamsnames = test;








            return View("Top", lModel);


        }

    }
}
