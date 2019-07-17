using CarRental.Data.Interfaces;
using CarRental.Services.Converters;
using CarRental.Services.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace CarRental.Services.Services
{
    public class SearchService : ISearchService
    {
   

        private readonly ICarRepository CarRep;
        public SearchService(ICarRepository carRep)
        {
            CarRep = carRep;
        }
        public IOperationResult<SearchResult<AdvertListDto>> Search(SearchRequestDto searchRequestDto)
        {
            var cars=CarRep.FindFilters(searchRequestDto.StartDate, searchRequestDto.EndDate, searchRequestDto.CarBrand, searchRequestDto.CarModel,
                searchRequestDto.CarColor, searchRequestDto.CarLocation, searchRequestDto.MaxPrice, searchRequestDto.MinPrice, searchRequestDto.MinKm, searchRequestDto.MaxKm, searchRequestDto.CarFuelTypes, searchRequestDto.IsManual);

            cars.Select(x => x.ToDetailedDto()).ToList();
           //SORRR List<AdvertDetailedDto> advList = cars;



            if (cars.Count== 0) 
                return new OperationResult<SearchResult<AdvertListDto>>(false, "Aradýðýnýz kriterde araç bulunamadý");

            return new OperationResult<SearchResult<AdvertListDto>>(new SearchResult<AdvertListDto> {
                //Documents = cars ;
                Take = 10,
                Page = cars.Count / 10 


            });
        }
    }
}