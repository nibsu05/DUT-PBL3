using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User
    {
        public int user_id { get; set; };
        public string full_name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string password_hash { get; set; }
        public string created_at { get; set; }
    }
}
