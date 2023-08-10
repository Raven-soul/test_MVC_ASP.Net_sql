using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using test.Models;

namespace test.SQL {
    public class DataBase {
        string dbPathString = "";
        public BookDb bookData;
        public UserDb userData;

        public DataBase() {
            dbPathString = "Data Source=SQL/db_file.sqlite3";
            bookData = new BookDb(dbPathString);
            userData = new UserDb(dbPathString);
        }       
    }
}
