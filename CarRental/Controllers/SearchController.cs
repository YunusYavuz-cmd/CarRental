using CarRental.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;  
        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }
        public IActionResult Index(string keywords)
        {
            var result = _searchService.Search(keywords);
            return View(result);
        }
    }
}