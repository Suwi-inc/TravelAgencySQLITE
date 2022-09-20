using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencylabTwo
{
    internal class Tour
    {
        public string name { get; set; }
        public DateOnly tourStart { get; set; }
        public DateOnly tourEnd { get; set; }
        public string city { get; set; }
        public Tour(string name, DateOnly tourStart, DateOnly tourEnd, string city)
        {
            this.name = name;
            this.tourStart = tourStart;
            this.tourEnd = tourEnd;
            this.city = city;
        }
        override
            public string ToString()
        {
            return ("Tour Name :" + this.name
               + "\n" + "Tour Start :" + this.tourStart
               + "\n" + "Tour End :" + this.tourEnd
               + "\n" + "Tour City :" + this.city
               + "\n");
        }
    }
}
