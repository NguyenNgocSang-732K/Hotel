using Microsoft.AspNetCore.Mvc;
using Center.Models.ModelView;
using System;
using Microsoft.AspNetCore.Authorization;
using Center.Models.Dao;

namespace Center.Controllers
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
    }
}