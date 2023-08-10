using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Interfaces;
using test.Models;
using test.SQL;

namespace test.Mocks {
    public class MockBooks : IBooks {
        public IEnumerable<Book> AllBooks {
            get {
                List<Book> BookList = null;
                var db = new DataBase();
                var dict = db.DbGetAllBooks();
                foreach (var item in dict) {
                    BookList.Add(new Book
                    {
                        id = item.Key,
                        bookName = item.Value[0],
                        description = item.Value[1],
                        orders = dbReader.DbGetBookOrders(item.Key)
                    });
                }
                return BookList;
            }
        }

        public void addBook(string bookName, string description)
        {
            var dbReader = new Reader();
            dbReader.DbAddBook(bookName, description);
        }

        public void editBook(int bookId, string description)
        {
            throw new NotImplementedException();
        }

        public Book getBook(int bookId)
        {
            throw new NotImplementedException();
        }
    }
}
