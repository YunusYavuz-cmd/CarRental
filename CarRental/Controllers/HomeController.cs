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
using System.Text.RegularExpressions;

namespace CarRental.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomePageServices _homePageServices;
        private readonly ISearchService _searchService;
        private readonly IBookServices _bookService;
        public static string FeaturesApplicationDictionaryKey(string feature, string appType) => $"ApplicationKey_{feature}_{appType}";


        public HomeController(IHomePageServices homePageServices, ISearchService searchService,IBookServices bookServices)
        {
            _homePageServices = homePageServices;
            _searchService = searchService;
            _bookService = bookServices;
            
        }
        [HttpGet]
        public IActionResult Index()
        {
            var a = new HomePageModel
            {
                DeliveryLocations = _homePageServices.GetLocationNamesList(),
                LocationPoints= _homePageServices.GetLocationPointsList()
            };
       //     addBooking(); populate database
            return View(a);
        }

        public void addBooking()
        {

            BookRequestDto bookCustomerDto = new BookRequestDto
            {
                CustomerAge = 22,
                CustomerEmail = "s@sabanciuniv.edu",
                CustomerLicenseAge = 7,
                CustomerName = "yasin",
                CustomerPhoneNumber = "05434730833",
                RentStartDate = new DateTime(2017, 1, 15),
                RentEndDate = new DateTime(2017, 1, 18),
                carId = 1

            }; _bookService.AddBooking(bookCustomerDto);

            bookCustomerDto = new BookRequestDto
            {
                CustomerAge = 22,
                CustomerEmail = "selin@sabanciuniv.edu",
                CustomerLicenseAge = 7,
                CustomerName = "selin",
                CustomerPhoneNumber = "05434730833",
                RentStartDate = new DateTime(2019, 1, 5),
                RentEndDate = new DateTime(2019, 1, 8),
                carId = 2

            }; _bookService.AddBooking(bookCustomerDto);

            bookCustomerDto = new BookRequestDto
            {
                CustomerAge = 22,
                CustomerEmail = "cem@sabanciuniv.edu",
                CustomerLicenseAge = 7,
                CustomerName = "cem",
                CustomerPhoneNumber = "05434730833",
                RentStartDate = new DateTime(2018, 12, 15),
                RentEndDate = new DateTime(2019, 1, 30),
                carId = 1
            };
            _bookService.AddBooking(bookCustomerDto);


        }
    }
}




