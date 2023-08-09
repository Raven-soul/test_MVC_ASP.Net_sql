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
                List<Book> Books = null;
                var dbReader = new Reader();
                var list = dbReader.DbGetAllBooks();
                for (int i = 0; i < list.GetLength(0); i++) { 
                    Books.Add(new Book{
                        id = int.Parse(list[i, 0]),
                        bookName = list[i, 1],
                        description = list[i, 1],
                    })
                }
                return 
            }
        }

        public Book getBook => throw new NotImplementedException();

        public Book editBook { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
