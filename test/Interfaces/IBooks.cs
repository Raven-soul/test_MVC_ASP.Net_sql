using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Models;

namespace test.Interfaces {
    interface IBooks {
        IEnumerable<Book> AllBooks { get; }
        Book getBook(int bookId);
        void editBook(int bookId, string description);
        void addBook(string bookName, string description);
    }
}
