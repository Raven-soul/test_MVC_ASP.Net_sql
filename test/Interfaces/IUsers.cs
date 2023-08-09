using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Models;

namespace test.Interfaces {
    interface IUsers {
        IEnumerable<User> AllUsers { get; }
        User getUser(int userId);
        IEnumerable<Book> getTakenBooks { get; }
        bool delTakenBooks(int [] booksId);
        IEnumerable<Book> getUnTakenBooks { get; }
        bool setUnTakenBooks(int[] booksId);
    }
}
