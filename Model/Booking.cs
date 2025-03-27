using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Booking
    {
        public string booking_id { get; set; }
        public string user_id { get; set; }
        public string flight_id { get; set; }
        public string seat_id { get; set; }
        public string status { get; set; }
    }
}
