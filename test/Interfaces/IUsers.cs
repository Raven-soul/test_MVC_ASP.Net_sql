using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Models;

namespace test.Interfaces {
    public interface IUsers {
        IEnumerable<User> AllUsers { get; }
        User getUser(int userId);
        IEnumerable<Book> getTakenBooks(int userId);
        void delTakenBooks(int userId, int[] booksId);
        void setUnTakenBooks(int userId, int[] booksId);
        void addUser(string name);
    }
}
