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
            var locationList = _adminServices.GetLocationNamesList();
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
                var locationList = _adminServices.GetLocationNamesList();
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
            var locationList = _adminServices.GetLocationsDto();
            ViewBag.locations = locationList.Select(x =>
                                 new SelectListItem()
                                 {
                                     Text = x.LocationName,
                                     Value = x.LocationId.ToString()
                                 });
            return View(new AddLocationPointDto());
        }

        [HttpPost]
        public ActionResult AddLocationPoint(AddLocationPointDto addLocationPoint)
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
                return View(addLocationPoint);
            }
            addLocationPoint.LocationId = Convert.ToInt32(addLocationPoint.LocationIdString);
            _adminServices.AddLocationPoint(addLocationPoint);
            return Redirect("/Admin");
        }
        [HttpGet]
        public ActionResult DeleteLocationPoint()
        {
            var locationList = _adminServices.GetLocationsDto();
            ViewBag.locations = locationList.Select(x =>
                                 new SelectListItem()
                                 {
                                     Text = x.LocationName,
                                     Value = x.LocationId.ToString()
                                 });
            ViewBag.locationPoints = ViewBag.locations;
                              /*new SelectListItem()
                              {
                                  Text = "Select Location First",
                                  Value = null
                              };*/
            return View(new DeleteLocationPointDto());
        }
        [HttpPost]
        public ActionResult DeleteLocationPoint(string data)
        {
            var locationList = _adminServices.GetLocationsDto();
            ViewBag.locationPoint = null;
            return View();
        }
        //[HttpPost]
        //public ActionResult DeleteLocationPoint(AddLocationPointDto deleteLocationPoint)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        var locationList = _adminServices.GetLocationsDto();
        //        ViewBag.locations = locationList.Select(x =>
        //                             new SelectListItem()
        //                             {
        //                                 Text = x.LocationName,
        //                                 Value = x.LocationId.ToString()
        //                             });
        //    //    var locationPointList = _adminServices.GetLocationPointsList();
        //      //  ViewBag.locationPoints = 
        //        return View(deleteLocationPoint);
        //    }
        //    deleteLocationPoint.LocationId = Convert.ToInt32(deleteLocationPoint.LocationIdString);
        //    _adminServices.AddLocationPoint(deleteLocationPoint);
        //    return Redirect("/Admin");
        //}
    }
}