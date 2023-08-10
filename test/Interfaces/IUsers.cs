using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Models;

namespace test.Interfaces {
    interface IUsers {
        IEnumerable<User> AllUsers { get; }
        User getUser(int userId);
        IEnumerable<Book> getTakenBooks(int userId);
        IEnumerable<Book> getUnTakenBooks(int userId);
        void delTakenBooks(int[] booksId, int userId);
        void setUnTakenBooks(int[] booksId, int userId);
    }
}
