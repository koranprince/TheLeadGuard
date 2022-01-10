using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using The_Lead_Guard.Models;


namespace The_Lead_Guard.Controllers
{
    public class PodcastController : Controller
    {
        public IActionResult Index()
        {

            return View();

        }

    }
}
