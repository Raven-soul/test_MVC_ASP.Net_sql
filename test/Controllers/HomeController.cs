using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index() {
            ViewBag.Title = "Список Книг";
            ViewBag.BookButton = "choosen";
            ViewBag.UserButton = "";

            BookListViewModel data = new BookListViewModel();
            data.allBooks = _allBooks.AllBooks;
            return View(data);
        }

        public IActionResult Users() {
            ViewBag.Title = "Список пользователей";
            ViewBag.BookButton = "";
            ViewBag.UserButton = "choosen";

            UserViewModel data = new UserViewModel();
            data.allUsers = _allUsers.AllUsers;
            return View(data);
        }

        public IActionResult UserEdit(int id) {
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
