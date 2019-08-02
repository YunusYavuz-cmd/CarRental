using CarRental.Data.Interfaces;
using CarRental.Services.Dto;

namespace CarRental.Services.Services
{
    public interface ISearchService
    {
        OperationResult<SearchResult<AdvertListDto>> Search(SearchRequestDto searchRequestDto);
    }
}