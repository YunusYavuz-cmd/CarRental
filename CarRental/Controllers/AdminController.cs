using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CarRental.Services.Dto;
using CarRental.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CarRental.Web.Controllers
{
    public class AdminController : Controller
    {
        IAdminServices _adminServices;
        public AdminController(IAdminServices adminServices)
        {
            _adminServices = adminServices;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddCar()
        {
            var locationList = _adminServices.GetLocationsList();
            ViewBag.locations = locationList.Select(x =>
                                 new SelectListItem()
                                 {
                                     Text = x
                                 });
            return View(new AddCarDto());
        }
        [HttpPost]
        public ActionResult AddCar(AddCarDto addCarDto)
        {
            if (!ModelState.IsValid)
            {
                var locationList = _adminServices.GetLocationsList();
                ViewBag.locations = locationList.Select(x =>
                                     new SelectListItem()
                                     {
                                         Text = x
                                     });
                return View(addCarDto);
            }
           var a= _adminServices.AddCar(addCarDto);

            return Redirect("/Admin");
        }
        [HttpGet]
        public ActionResult AddLocation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddLocation( string cityLocation)
        {
            if(cityLocation==null)
            {
                return View(cityLocation);
            }
           var a= _adminServices.AddLocation(cityLocation);
            
            return Redirect("/admin/addlocation");
        }

        [HttpGet]
        public ActionResult DeleteLocation()
        {
            var locationList = _adminServices.GetLocationsDto();
            ViewBag.locations = locationList.Select(x =>
                                 new SelectListItem()
                                 {
                                     Text = x.LocationName,
                                     Value= x.LocationId.ToString()
                                 });
            return View(new DeleteLocationDto());
        }

        [HttpPost]
        public ActionResult DeleteLocation(DeleteLocationDto deleteLocation)
        {
            if (!ModelState.IsValid)
            {
                var locationList = _adminServices.GetLocationsDto();
                ViewBag.locations = locationList.Select(x =>
                                     new SelectListItem()
                                     {
                                         Text = x.LocationName,
                                         Value = x.LocationId.ToString()
                                     });
                return View(deleteLocation);
            }
            deleteLocation.LocationId = Convert.ToInt32(deleteLocation.LocationName);
            _adminServices.DeleteLocation(deleteLocation);  
            return Redirect("/Admin");
        }

        [HttpGet]
        public ActionResult AddLocationPoint()
        {
            var locationList = _adminServices.GetLocationsList();
            ViewBag.locations = locationList.Select(x =>
                                 new SelectListItem()
                                 {
                                     Text = x
                                 });
            return View(new AddDeleteLocationPointDto());
        }

        [HttpPost]
        public ActionResult AddLocationPoint(AddDeleteLocationPointDto addLocationPoint)
        {
            if (!ModelState.IsValid)
            {
                var locationList = _adminServices.GetLocationsList();
                ViewBag.locations = locationList.Select(x =>
                                     new SelectListItem()
                                     {
                                         Text = x
                                     });
                return View(addLocationPoint);
            }
            _adminServices.AddLocationPoint(addLocationPoint);
            return Redirect("/Admin");
        }
    }
}