﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarRental.Models;
using CarRental.Data.Interfaces;
using CarRental.Domain;
using CarRental.Services.Services;

namespace CarRental.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly HomePageServices _homePageServices; 
        public HomeController(HomePageServices homePageServices)
        {
            
        }
        public IActionResult Index()
        {
            return View();
        }


    }
}
