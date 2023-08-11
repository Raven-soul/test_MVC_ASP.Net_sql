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
                List<Book> BookList = new List<Book>();
                var db = new DataBase();
                var dict = db.bookData.GetAll();
                foreach (var item in dict) {
                    BookList.Add(new Book
                    {
                        id = int.Parse(item["id"]),
                        bookName = item["name"],
                        description = item["description"]
                    });
                }
                return BookList;
            }
        }

        public void addBook(string bookName, string description) {
            var db = new DataBase();
            db.bookData.SetOne(bookName, description);
        }

        public void editBook(int bookId, string description) {
            var db = new DataBase();
            db.bookData.EditOne(bookId, description);
        }

        public Book getBook(int bookId) {
            var db = new DataBase();
            Dictionary<string, string> bookItem = new Dictionary<string, string>();
            if ((bookItem = db.bookData.GetOne(bookId)) != null) {
                Book book = new Book
                {
                    id = int.Parse(bookItem["id"]),
                    bookName = bookItem["name"],
                    description = bookItem["description"]
                };

                return book;
            }
            else { 
                return new Book();
            }
        }
    }
}
