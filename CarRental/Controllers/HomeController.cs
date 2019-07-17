using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarRental.Models;
using CarRental.Data.Interfaces;
using CarRental.Domain;
using CarRental.Services.Services;
using CarRental.Services.Dto;

namespace CarRental.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomePageServices _homePageServices;
        private readonly ISearchService _searchService;

        public HomeController(IHomePageServices homePageServices, ISearchService searchService)
        {
            _homePageServices = homePageServices;
            _searchService = searchService;
        }
        public IActionResult Index()
        {
            SearchRequestDto _searchReq = new SearchRequestDto
            {
                CarBrand = "AUDI",
                CarColor = "Lacivert",
                CarLocation="marş"
               
            };
            var opResult=_searchService.Search(_searchReq);
            return View(_homePageServices.Reto());
        }


    }
}
