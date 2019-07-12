using CarRental.Services.Dto;

namespace CarRental.Services.Services
{
    public class SearchService : ISearchService
    {
        public IOperationResult<SearchResult<CarListDto>> Search(string keywords)
        {
            return new OperationResult<SearchResult<CarListDto>>(new SearchResult<CarListDto>());
        }
    }
}