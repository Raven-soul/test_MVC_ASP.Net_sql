using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Models;

namespace test.ViewModels {
    public class BookViewModel {
        public IEnumerable<Book> allBooks { get; set; }
        public Book getBook { get; set; }
    }
}
