using CarRental.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Data.Interfaces
{
    public interface ILocationPointRepository : IRepository<LocationPoint>
    {
        bool IsLocationExist(string locationPoint);
        List<string> GetAllLocationPointNames();


    }
}
