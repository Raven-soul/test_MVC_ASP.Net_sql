using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using test.Models;

namespace test.SQL {
    public class DataBase {
        string dbPathString = "";
        public DbBook bookData;
        public DbUser userData;

        public DataBase() {
            dbPathString = "Data Source=SQL/db_file.sqlite3";
            bookData = new DbBook(dbPathString);
            userData = new DbUser(dbPathString);
        }       
    }
}
