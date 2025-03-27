using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Flight
    {
        public string flight_id { get; set; }
        public string airplane_id { get; set; }
        public string departure_airport_code { get; set; }
        public string arrival_airport_code { get; set; }
        public string departure_date { get; set; }
        public string status { get; set; }
    }
}
