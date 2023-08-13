using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Models;

namespace test.ViewModels {
    public class BookListViewModel {
        public IEnumerable<Book> allBooks { get; set; }
    }
}
