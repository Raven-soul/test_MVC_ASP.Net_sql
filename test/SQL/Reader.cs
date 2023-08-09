using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.IO;

namespace test.SQL {
    public class Reader {
        string dbPathString = "";

        public Reader() {
            dbPathString = "Data Source=SQL/db_file.sqlite3";
        }

        public void Check() {
            using (SqliteConnection connection = new SqliteConnection(dbPathString)) {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    var selectCommand = connection.CreateCommand();
                    selectCommand.Transaction = transaction;
                    selectCommand.CommandText = "SELECT * FROM Book";

                    string[] mystrings = new string[3];
                    int k = 0;
                    using (var reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var message = reader.GetString(1);
                            Console.WriteLine(message);

                            mystrings[k] = reader.GetString(1);
                            k = k + 1;
                        }
                    }
                    System.IO.File.WriteAllLines("myfile.txt", mystrings);
                    transaction.Commit();
                }
            }
        }

        public Dictionary<int, string[]> DbGetAllBooks() {
            Dictionary<int, string[]> result = new Dictionary<int, string[]>();

            using (SqliteConnection connection = new SqliteConnection(dbPathString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    var selectCommand = connection.CreateCommand();
                    selectCommand.Transaction = transaction;
                    selectCommand.CommandText = "SELECT * FROM Book";

                    using (var reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string[] temp = new string[] { reader.GetString(1), reader.GetString(2) };
                            result.Add(int.Parse(reader.GetString(0)), temp);
                        }
                    }
                    transaction.Commit();
                }
            }
            return result;
        }

    }
}
