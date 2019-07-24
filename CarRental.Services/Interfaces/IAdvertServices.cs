using CarRental.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Services.Interfaces
{
    public interface IAdvertServices
    {
      
       AdvertDetailedDto GetAdvertById(int advertId);
    }
}
