using CarRental.Data.Interfaces;
using CarRental.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRental.Data.Repositories
{
    public class LocationRepository:Repository<Location> ,ILocationRepository
    {
        public LocationRepository(RentACarContext context) : base(context)
        {
        }
        public bool IsLocationExist(string cityLocation)
        {
            if (DbSet.Where(x => x.CityLocation == cityLocation).FirstOrDefault() != null)
                return true;

            return false;
        }
        public Location GetLocationById(int locationId)
        {
            return DbSet.Where(x => x.Id == locationId).FirstOrDefault();
        }
        public int? GetLocationId(string cityLocation)
        {
            return DbSet.Where(t => t.CityLocation == cityLocation).Select(x => (int?)x.Id).FirstOrDefault(); // == id).Select(t => (int?)t.MemberId).FirstOrDefault();
        }
        public List<string> GetAllLocationNames()
        {
            return DbSet.Select(x => x.CityLocation).ToList<string>();
        }
        public List<Location> GetAllLocations()
        {
            return DbSet.ToList();
        }
    }
}
