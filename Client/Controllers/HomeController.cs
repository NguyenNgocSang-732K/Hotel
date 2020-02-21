﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.Models.DTO;
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
            var acc = AccountDTO.LoginAsync("nguyenngocsang0868@gmail.com", "123");
            return View();
        }
    }
}