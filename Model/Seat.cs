using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Seat
    {
        public string seat_id { get; set; }
        public string seat_class { get; set; }
        public bool is_available { get; set; }
        public int price { get; set; }
    }
}
