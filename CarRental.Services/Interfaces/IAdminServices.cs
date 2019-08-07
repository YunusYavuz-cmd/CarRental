using CarRental.Services.Dto;
using CarRental.Services.Services;
using System.Collections.Generic;

namespace CarRental.Services.Interfaces
{
    public interface IAdminServices
    {
        OperationResult AddLocation(string cityLocation); //operation result . if data is null then not avaible. book oluşturulduğunda ekrana info sayfasını vercek
        OperationResult AddCar(AddCarDto addCarDto);
        List<string> GetLocationNamesList();
        OperationResult DeleteLocation(DeleteLocationDto deleteLocationDto);
        List<DeleteLocationDto> GetLocationsDto();


        OperationResult AddLocationPoint(AddLocationPointDto addLocationPointDto);

    }
}
