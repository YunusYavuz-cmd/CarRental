using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Services.Dto
{
    public class DeleteLocationPointDto
    {
        public string LocationPointName { get; set; }
        public int LocationPointId { get; set; }

        public string LocationName { get; set; }
        public int LocationId { get; set; }


        public string LocationIdString { get; set; }
        public string LocationPointIdString { get; set; }

    }
}
