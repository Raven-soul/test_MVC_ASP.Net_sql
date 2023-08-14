﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Interfaces;
using test.ViewModels;

namespace test.Controllers {
    public class HomeController : Controller {

        private readonly IBooks _allBooks;
        private readonly IUsers _allUsers;

        public HomeController(IBooks iBooks, IUsers iUsers) {
            _allBooks = iBooks;
            _allUsers = iUsers;
        }

        //функция обробатывет и выводит список произведений
        public IActionResult ListBook() {
            ViewBag.Title = "Список Книг";
            ViewBag.BookButton = "choosen";
            ViewBag.UserButton = "";

            BookViewModel data = new BookViewModel();
            data.allBooks = _allBooks.AllBooks;
            return View(data);
        }

        //функция обробатывет и выводит список пользователей
        public IActionResult ListUser() {
            ViewBag.Title = "Список пользователей";
            ViewBag.BookButton = "";
            ViewBag.UserButton = "choosen";

            UserViewModel data = new UserViewModel();
            data.allUsers = _allUsers.AllUsers;
            return View(data);
        }

        //функция выводит данные о конкретном произведении
        public IActionResult EditBook(int id) {
            ViewBag.Title = "Данные о книге";
            ViewBag.BookButton = "choosen";
            ViewBag.UserButton = "";

            BookViewModel data = new BookViewModel();
            data.getBook = _allBooks.getBook(id);
            return View(data);
        }

        //функция выводит данные о конкретном пользователе
        public IActionResult EditUser(int id) {
            ViewBag.Title = "Данные пользователя";
            ViewBag.BookButton = "";
            ViewBag.UserButton = "choosen";

            UserViewModel data = new UserViewModel();
            data.getUser = _allUsers.getUser(id);
            data.takenBooks = _allUsers.getTakenBooks(id);
            data.unTakenBooks = _allUsers.getUnTakenBooks(id);
            return View(data);
        }
    }
}
