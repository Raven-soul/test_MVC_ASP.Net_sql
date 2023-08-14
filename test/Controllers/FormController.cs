using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Interfaces;
using test.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace test.Controllers {
    public class FormController : Controller {

        private readonly IBooks _allBooks;
        private readonly IUsers _allUsers;

        public FormController(IBooks iBooks, IUsers iUsers) {
            _allBooks = iBooks;
            _allUsers = iUsers;
        }

        //функция обробатывет и выводит форму для добавления новой книги
        public IActionResult AddBook() {
            ViewBag.Title = "Добавление книги";
            ViewBag.BookButton = "choosen";
            ViewBag.UserButton = "";

            return View();
        }

        //функция обробатывет и выводит форму для добавления нового пользователя
        public IActionResult AddUser() {
            ViewBag.Title = "Добавление пользователя";
            ViewBag.BookButton = "";
            ViewBag.UserButton = "choosen";

            return View();
        }
    }
}
