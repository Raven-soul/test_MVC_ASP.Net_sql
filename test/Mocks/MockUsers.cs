using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test.Interfaces;
using test.Models;

namespace test.Mocks {
    public class MockUsers : IUsers {
        public IEnumerable<User> AllUsers => throw new NotImplementedException();

        public IEnumerable<Book> getTakenBooks => throw new NotImplementedException();

        public IEnumerable<Book> getUnTakenBooks => throw new NotImplementedException();

        public bool delTakenBooks(int[] booksId)
        {
            throw new NotImplementedException();
        }

        public User getUser(int userId)
        {
            throw new NotImplementedException();
        }

        public bool setUnTakenBooks(int[] booksId)
        {
            throw new NotImplementedException();
        }
    }
}
