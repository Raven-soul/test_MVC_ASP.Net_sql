using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Interfaces;

namespace test.Controllers {
    public class CustomIndexController : Controller {

        private readonly IBooks _allBooks;
        private readonly IUsers _allUsers;

        public CustomIndexController(IBooks iBooks, IUsers iUsers) {
            _allBooks = iBooks;
            _allUsers = iUsers;
        }

        public IActionResult Index() {
            var books = _allBooks.AllBooks;
            return View(books);
        }
    }
}
