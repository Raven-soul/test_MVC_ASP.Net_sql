using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Models;

namespace test.ViewModels {
    public class UserViewModel {
        public IEnumerable<User> allUsers { get; set; }
        public User getUser { get; set; }
        public IEnumerable<Book> takenBooks { get; set; }
        public IEnumerable<Book> unTakenBooks { get; set; }
    }
}
