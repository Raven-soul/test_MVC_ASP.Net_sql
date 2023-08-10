using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using test.Models;

namespace test.SQL {
    public class UserDb {
        string dbPathString = "";

        public UserDb(string dbPath) {
            dbPathString = dbPath;
        }

        public List<Dictionary<string, string>> DbGetAllUsers()
        {
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();

            using (SqliteConnection connection = new SqliteConnection(dbPathString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    var selectCommand = connection.CreateCommand();
                    selectCommand.Transaction = transaction;
                    selectCommand.CommandText = "SELECT * FROM User";

                    using (var dataBaseReader = selectCommand.ExecuteReader())
                    {
                        while (dataBaseReader.Read())
                        {
                            Dictionary<string, string> temp = new Dictionary<string, string>();
                            temp.Add("id", dataBaseReader.GetString(0));
                            temp.Add("name", dataBaseReader.GetString(1));
                            result.Add(temp);
                        }
                    }
                    transaction.Commit();
                }
            }
            return result;
        }
    }
}
