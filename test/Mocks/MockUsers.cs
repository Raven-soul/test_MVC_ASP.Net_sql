using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Interfaces;
using test.Models;
using test.SQL;

namespace test.Mocks {
    public class MockUsers : IUsers {
        public IEnumerable<User> AllUsers {
            get {
                List<User> UserList = new List<User>();
                var db = new DataBase();
                var dict = db.userData.GetAll();
                foreach (var item in dict) {
                    UserList.Add(new User {
                        id = int.Parse(item["id"]),
                        userName = item["name"],
                        orders = db.userData.GetOrdersByOne(int.Parse(item["id"]))
                    });
                }
                return UserList;
            }
        }

        public User getUser(int userId) {
            var db = new DataBase();
            Dictionary<string, string> userItem = new Dictionary<string, string>();
            if ((userItem = db.userData.GetOne(userId)) != null) {
                User user = new User {
                    id = int.Parse(userItem["id"]),
                    userName = userItem["name"],
                    orders = db.userData.GetOrdersByOne(int.Parse(userItem["id"]))
                };

                return user;
            }
            else {
                return new User();
            }
        }

        public void delTakenBooks(int[] booksId, int userId) {
            var db = new DataBase();
            foreach (var bookid in booksId) {
                db.userData.DeleteBookOrderByOne(userId, bookid);
            }
        }

        public IEnumerable<Book> getTakenBooks(int userId) {
            var db = new DataBase();
            var bookList = db.userData.GetTakenBooksByOne(userId);
            List<Book> result = new List<Book>();
            foreach (var book in bookList) {
                result.Add(new Book {
                    id = int.Parse(book["id"]),
                    bookName = book["name"],
                    description = book["description"],
                    orders = db.bookData.GetOrdersByOne(int.Parse(book["id"]))
                });
            }
            return result;
        }

        public IEnumerable<Book> getUnTakenBooks(int userId) {
            var db = new DataBase();
            var bookList = db.userData.GetUntakenBooksByOne(userId);
            List<Book> result = new List<Book>();
            foreach (var book in bookList) {
                result.Add(new Book {
                    id = int.Parse(book["id"]),
                    bookName = book["name"],
                    description = book["description"],
                    orders = db.bookData.GetOrdersByOne(int.Parse(book["id"]))
                });
            }
            return result;
        }      

        public void setUnTakenBooks(int[] booksId, int userId) {
            var db = new DataBase();
            foreach (int bookId in booksId) {
                db.userData.DeleteBookOrderByOne(userId, bookId);
            }
        }
    }
}
