using CarRental.Data.Interfaces;
using CarRental.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRental.Data.Repositories
{
    public class LocationPointRepository: Repository<LocationPoint> , ILocationPointRepository
    {
        public LocationPointRepository(RentACarContext context):base(context)
        { }

        public bool IsLocationExist(string locationPoint)
        {
            return DbSet.Any(x => x.LocationPointName == locationPoint);
        }
        public List<string> GetAllLocationPointNames()
        {
            return DbSet.Select(x => x.LocationPointName).ToList();
        }
    }
}
