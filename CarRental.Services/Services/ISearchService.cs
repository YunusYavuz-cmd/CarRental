using CarRental.Services.Dto;

namespace CarRental.Services.Services
{
    public interface ISearchService
    {
        IOperationResult<SearchResult<CarListDto>> Search(string keywords);
    }
}