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

        public IActionResult addBooks() {
            bool isAjax = HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
            if (isAjax)
                return PartialView("_AjaxTestPartial");
            return View();

            //string[][] jsonArray = JsonConvert.DeserializeObject<string[][]>(data);
            //int[] bookids = new int[jsonArray[0].Length];
            //for (int i=0; i<jsonArray[0].Length; i++) {
            //    bookids[i] = int.Parse(jsonArray[0][i]);
            //}
            //_allUsers.setUnTakenBooks(userId, bookids);
            //return View();
        }
    }

}
