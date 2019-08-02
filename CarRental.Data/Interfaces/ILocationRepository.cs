using CarRental.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Data.Interfaces
{
    public interface ILocationRepository: IRepository<Location>
    {
        bool IsLocationExist(string cityLocation);
        Location GetLocationById(int locationId);
        List<Location> GetAllLocations();
        List<string> GetAllLocationNames();
        int? GetLocationId(string cityLocation);

    }
}
