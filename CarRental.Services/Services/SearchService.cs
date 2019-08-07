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
        private readonly ICarRepository CarRepository;
        public SearchService(ICarRepository carRepository)
        {
            CarRepository = carRepository;
        }
        public OperationResult<SearchResult<AdvertListDto>> Search(SearchRequestDto searchRequestDto)
        {
            var cars=CarRepository.FindFilters(searchRequestDto.StartDate, searchRequestDto.EndDate, searchRequestDto.CarBrand, searchRequestDto.CarModel,
                searchRequestDto.CarColor, searchRequestDto.CarLocation, searchRequestDto.MaxPrice, searchRequestDto.MinPrice, searchRequestDto.MinKm, searchRequestDto.MaxKm, searchRequestDto.CarFuelTypes, searchRequestDto.IsManual,searchRequestDto.CarStyle);
            if (cars.Count== 0) 
                return new OperationResult<SearchResult<AdvertListDto>>(false, "Aradýðýnýz kriterde araç bulunamadý");

            return new OperationResult<SearchResult<AdvertListDto>>(true,"",(int) HttpStatusCode.OK, new SearchResult<AdvertListDto> {
                Documents = new AdvertListDto {
                    AdvertList = cars.Select(x => x.ToDetailedDto()).ToList(),
                },
                Total = cars.Count,
                Take = 12
            });
        }
        public OperationResult<AdvertDetailedDto> GetAdvertById(int advertId)
        {
            var advertCar = CarRepository.GetById(advertId);
            if (advertCar == null)
                return new OperationResult<AdvertDetailedDto>(false, "Aradýðýnýz araç bulunamadý");

            return new OperationResult<AdvertDetailedDto>(true, "", (int)HttpStatusCode.OK, advertCar.ToDetailedDto());
        }
    }
}