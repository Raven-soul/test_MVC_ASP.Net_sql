using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Interfaces;
using test.ViewModels;
using Newtonsoft.Json;

namespace test.Controllers {
    public class AjaxController : Controller {

        private readonly IBooks _allBooks;
        private readonly IUsers _allUsers;

        public AjaxController(IBooks iBooks, IUsers iUsers) {
            _allBooks = iBooks;
            _allUsers = iUsers;
        }

        //функция добавляет пользователю список выданных книг
        [HttpPost]
        public void UserAddBook(int userId, string booksId) {
            string[] words = booksId.Split(',');
            int[] listId = new int[words.Length];

            for (int i = 0; i < words.Length; i++) {
                listId[i] = int.Parse(words[i]);
            }
            _allUsers.setUnTakenBooks(userId, listId);
        }

        //функция убирает у пользователя список выданных книг
        [HttpPost]
        public void UserDeleteBook(int userId, string booksId) {
            string[] words = booksId.Split(',');
            int[] listId = new int[words.Length];

            for (int i = 0; i < words.Length; i++) {
                listId[i] = int.Parse(words[i]);
            }
            _allUsers.delTakenBooks(userId, listId);
        }

        //функция изменяет описание книги
        [HttpPost]
        public void BookEditBook(int bookId, string description) {
            _allBooks.editBook(bookId, description);
        }
    }
}
