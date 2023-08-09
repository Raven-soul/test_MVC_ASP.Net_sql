using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test.Models {
    public class User {
        public int id { get; set; }
        public string userName { get; set; }
        public List<Order> orders { get; set; }
    }
}
