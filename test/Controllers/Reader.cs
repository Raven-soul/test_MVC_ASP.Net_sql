using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.IO;

namespace test.Controllers
{
    public class Reader
    {
        public Reader()
        {
            using (SqliteConnection connection = new SqliteConnection("Data Source=db_file.sqlite3"))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    //    //var insertCommand = connection.CreateCommand();
                    //    //insertCommand.Transaction = transaction;
                    //    //insertCommand.CommandText = "INSERT INTO message ( text ) VALUES ( $text )";
                    //    //insertCommand.Parameters.AddWithValue("$text", "Hello, World!");
                    //    //insertCommand.ExecuteNonQuery();

                    var selectCommand = connection.CreateCommand();
                    selectCommand.Transaction = transaction;
                    selectCommand.CommandText = "SELECT * FROM Books";

                    string[] mystrings = new string[3];
                    int k = 0;

                    using (var reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var message = reader.GetString(0);
                            Console.WriteLine(message);

                            mystrings[k] = reader.GetString(0);
                            k = k + 1;
                        }
                    }
                    System.IO.File.WriteAllLines("myfile.txt", mystrings);
                    transaction.Commit();
                }
            }
        }
    }
}
