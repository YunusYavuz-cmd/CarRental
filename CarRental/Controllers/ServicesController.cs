using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarRental.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Web.Controllers
{
    public class ServicesController : Controller
    {
        IBookServices _bookServices;
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string referanceNum)
        {
            if (referanceNum == null)
            {
                return View(referanceNum);
            }
            var a = _bookServices.GetBookInfo(referanceNum);

            return Redirect("/services/bookinfo/"+id);
        }
        [HttpGet]
        public ActionResult Rez-Bilgi(int id)
        {
            return View();
        }

    }
}