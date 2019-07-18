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
using CarRental.Services.Interfaces;

namespace CarRental.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomePageServices _homePageServices;
        private readonly ISearchService _searchService;
        private readonly IBookServices _bookService;

        public HomeController(IHomePageServices homePageServices, ISearchService searchService,IBookServices bookServices)
        {
            _homePageServices = homePageServices;
            _searchService = searchService;
            _bookService = bookServices;

        }
        public IActionResult Index()
        {

            return View(_homePageServices.Reto());
        }


    }
}





    //   _bookService.AddBooking(1, bookCustomerDto);
            //SearchRequestDto _searchReq = new SearchRequestDto
            //{
            //    CarBrand = "AUDI",
            //    CarColor = "Lacivert",
            //    CarLocation="marş"
               
            //};
            //var opResult=_searchService.Search(_searchReq);
            //BookCustomerDto bookCustomerDto = new BookCustomerDto {
            //    CustomerAge = 25,
            //    CustomerEmail = "yunusyavuz@sabanciuniv.edu",
            //    CustomerLicenseAge = 7,
            //    CustomerName = "yunus",
            //    CustomerPhoneNumber = "05434730833",
            //    ReferenceNumber = 45362,
            //    RentStartDate = new DateTime(2019, 1, 1),
            //    RentEndDate = new DateTime(2019, 1, 10),
                
            //};
            //Car car = new Car
            //{
            //    CarBrand = "Renault",
            //    CarFuelTypes = 1,
            //    CarColor = "Mavi",
            //    CarKm = 35000,
            //    CarModel = "Clio",
            //    CarYear = 2015,
            //    IsManual = true,
            //    CarLocation = "Istanbul",
                
            //};