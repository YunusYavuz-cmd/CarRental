using CarRental.Data.Interfaces;
using CarRental.Domain;
using CarRental.Services.Converters;
using CarRental.Services.Dto;
using CarRental.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace CarRental.Services.Services
{
    public class AdminServices: IAdminServices
    {
        private readonly ILocationPointRepository LocationPointRepository;
        private readonly ILocationRepository LocationRepository;
        private readonly ICarRepository CarRepository;

        public AdminServices (ILocationRepository locationRepository,ICarRepository carRepository,ILocationPointRepository locationPointRepository)
        {
            LocationRepository = locationRepository;
            CarRepository = carRepository;
            LocationPointRepository = locationPointRepository;
        }

        public OperationResult AddLocation(string cityLocation) //operation result . if data is null then not avaible. book oluşturulduğunda ekrana info sayfasını vercek
        {
            cityLocation=ToLowerCaseString(cityLocation);

            if (LocationRepository.IsLocationExist(cityLocation))
            {
                return new OperationResult(false, "Lokasyon zaten mevcut", (int)HttpStatusCode.NotFound);
            }
            else
            {
                var location = new Location
                {
                     CityLocation= cityLocation
                };
                LocationRepository.AddAndSave(location);

                return new OperationResult(true, "Yeni şehir eklendi.", (int)HttpStatusCode.OK);
            }
        }
        public OperationResult DeleteLocation(DeleteLocationDto deleteLocationDto)
        {
            var location = LocationRepository.GetById(deleteLocationDto.LocationId);
            if (location == null)
                return new OperationResult(false, "Şehir Bulunamadı.", (int)HttpStatusCode.NotFound);
            LocationRepository.DeleteAndSave(location);
            return new OperationResult(true, "Şehir Silindi", (int)HttpStatusCode.OK);
        }
        public OperationResult AddLocationPoint(AddLocationPointDto addLocationPointDto) 
        {
            if(addLocationPointDto.LocationId == null)
                return new OperationResult(false, "Şehir bulunamadı", (int)HttpStatusCode.NotFound);
            if (LocationPointRepository.IsLocationExist(addLocationPointDto.LocationPointName))
                return new OperationResult(false, "Teslim noktası zaten mevcut", (int)HttpStatusCode.NotFound);
           
            var locationPoint = CreateLocationPoint(addLocationPointDto);
            LocationPointRepository.AddAndSave(locationPoint);

            return new OperationResult(true, "Teslim Noktası eklendi.", (int)HttpStatusCode.OK);
        }
        public OperationResult DeleteLocationPoint(AddLocationPointDto addDeleteLocationPointDto)
        {
            //  if(addDeleteLocationPointDto.LocationPointId==null)
            //    return new OperationResult(false, " Şehir Id si Atanmamış.", (int)HttpStatusCode.NotFound);
            var locationPoint = LocationPointRepository.GetById((int)3);//addDeleteLocationPointDto.LocationPointId);
            if (locationPoint == null) 
                return new OperationResult(false, "Teslim Noktası Bulunamadı.", (int)HttpStatusCode.NotFound);
            LocationPointRepository.DeleteAndSave(locationPoint);
            return new OperationResult(true, "Teslim noktası silindi.", (int)HttpStatusCode.OK);
        }
        public OperationResult AddCar(AddCarDto addCarDto)
        {
            addCarDto.CarLocation = ToLowerCaseString(addCarDto.CarLocation);
            addCarDto.LocationId = LocationRepository.GetLocationId(addCarDto.CarLocation);
            if (addCarDto.LocationId == null)
                return new OperationResult(false, "Şehir Bulunamadı",(int) HttpStatusCode.NotFound);

            var car = CreateCar(addCarDto);
            CarRepository.AddAndSave(car);
            return new OperationResult(true, "Araç Eklendi id=" + car.Id, (int)HttpStatusCode.OK);
        }
        


        public List<string> GetLocationNamesList()
        {
            return LocationRepository.GetAllLocationNames();
        }
        public List<string> GetLocationPointsList()
        {
            return LocationPointRepository.GetAllLocationPointNames();
        }
        public List<DeleteLocationDto> GetLocationsDto()
        {
            return LocationRepository.GetAllLocations().Select(x => x.toDto()).ToList();
        }














        //public OperationResult DeleteCar(int carId)
        //{
        //    if (CarRep.İsExist(carid))
        //delete(carId)
        //
        //
        //return new OperationResult(true,"Araç Silindi",HttpStatusCode.OK);
        //else
        //return new OperationResult(false,"ID BULUNAMADI",HttpStatusCode.NotFound)
        //}
        //
        //
        public LocationPoint CreateLocationPoint(AddLocationPointDto addLocationPointDto)
        {
            return new LocationPoint
            {
                LocationId = (int) addLocationPointDto.LocationId,
                LocationPointName = addLocationPointDto.LocationPointName
            };
        }
        public Car CreateCar(AddCarDto addCarDto)
        {
            return new Car
            {
                CarBrand = addCarDto.CarBrand,
                CarModel = addCarDto.CarModel,
                CarColor = addCarDto.CarColor,
                CarFuelTypes = addCarDto.CarFuelTypes,
                CarKm = addCarDto.CarKm,
                CarLocation = addCarDto.CarLocation,
                CarStyle = (CarRental.Domain.Car.CarStyles)addCarDto.CarStyle,
                CarYear = addCarDto.CarYear,
                IsManual = addCarDto.IsManual,
                LocationId = (int)addCarDto.LocationId
                //add price table info
            };
        }
        private string ToLowerCaseString(string str)
        {
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }
    }
}
