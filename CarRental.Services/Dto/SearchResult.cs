using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CarRental.Services.Dto
{
    public class SearchResult<T>
    {
        public T Documents { get; set; } // changed it since it 
        public int Take
        {
            get => _take > 0 ? _take : 10;
            set => _take = value;
        }   
        public int Page
        {
            get => _page > 0 ? _page : 1;
            set => _page = value;
        }
        public int TotalPage => Total > 0 ? (int) Math.Round((decimal) (Total / _take ), MidpointRounding.AwayFromZero) : 0;
        public int Total { get; set; }   
        private int _take { get; set; }
        private int _page { get; set; }
    }
}