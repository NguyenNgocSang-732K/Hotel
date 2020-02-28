using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.Models.DTO;
using Client.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        [Route("~/")]
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            
            return View();
        }

        [Route("searchroom")]
        public IActionResult Searchroom()
        {

            return View();
        }
    }
}