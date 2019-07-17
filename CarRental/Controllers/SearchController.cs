using CarRental.Services.Dto;
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
        public IActionResult Index(SearchRequestDto searchRequestDto) //
        {
            var result = _searchService.Search(searchRequestDto);
            return View(result);
        }
    }
}