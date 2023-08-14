using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using test.Models;

namespace test.SQL {
    public class DbUser {
        string dbPathString = "";

        public DbUser(string dbPath) {
            dbPathString = dbPath;
        }

        // Получить список всех элементов базы данных пользователей
        public List<Dictionary<string, string>> GetAll()
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

        // Получить один элемент из базы данных пользователей
        public Dictionary<string, string> GetOne(int userId)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            using (SqliteConnection connection = new SqliteConnection(dbPathString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    var selectCommand = connection.CreateCommand();
                    selectCommand.Transaction = transaction;
                    selectCommand.CommandText = "SELECT * FROM User WHERE id = $userId";
                    selectCommand.Parameters.AddWithValue("$userId", userId);

                    using (var dataBaseReader = selectCommand.ExecuteReader())
                    {
                        while (dataBaseReader.Read())
                        {
                            result.Add("id", dataBaseReader.GetString(0));
                            result.Add("name", dataBaseReader.GetString(1));
                        }
                    }
                    transaction.Commit();
                }
            }
            return result;
        }

        // Добавить новую запись в базу пользователей
        public void SetOne(string userName)
        {
            using (SqliteConnection connection = new SqliteConnection(dbPathString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    var insertCommand = connection.CreateCommand();
                    insertCommand.Transaction = transaction;
                    insertCommand.CommandText = "INSERT INTO User (name)  VALUES ( $name )";
                    insertCommand.Parameters.AddWithValue("$name", userName);
                    insertCommand.ExecuteNonQuery();
                    transaction.Commit();
                }
            }
        }

        // Получить все записи выданных книг данному пользователю
        public List<Dictionary<string, string>> GetTakenBooksByOne(int userId)
        {
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();

            using (SqliteConnection connection = new SqliteConnection(dbPathString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    var selectCommand = connection.CreateCommand();
                    selectCommand.Transaction = transaction;
                    selectCommand.CommandText = "SELECT Book.id, Book.name, Book.description FROM OrderData INNER JOIN Book ON OrderData.bookid = Book.id AND OrderData.userid = $userId";
                    selectCommand.Parameters.AddWithValue("$userId", userId);

                    using (var dataBaseReader = selectCommand.ExecuteReader())
                    {
                        while (dataBaseReader.Read())
                        {
                            Dictionary<string, string> dict = new Dictionary<string, string>();
                            dict.Add("id", dataBaseReader.GetString(0));
                            dict.Add("name", dataBaseReader.GetString(1));
                            dict.Add("description", dataBaseReader.GetString(2));
                            result.Add(dict);
                        }
                    }
                    transaction.Commit();
                }
            }
            
            return result;
        }

        // Получить все записи на выдачу книг данному пользователю
        public List<Dictionary<string, string>> GetUntakenBooksByOne(int userId)
        {
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();

            using (SqliteConnection connection = new SqliteConnection(dbPathString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    var selectCommand = connection.CreateCommand();
                    selectCommand.Transaction = transaction;
                    selectCommand.CommandText = "SELECT DISTINCT Book.id, Book.name, Book.description FROM OrderData INNER JOIN Book ON OrderData.bookid != Book.id AND OrderData.userid != $userId";
                    selectCommand.Parameters.AddWithValue("$userId", userId);

                    using (var dataBaseReader = selectCommand.ExecuteReader())
                    {
                        while (dataBaseReader.Read())
                        {
                            Dictionary<string, string> dict = new Dictionary<string, string>();
                            dict.Add("id", dataBaseReader.GetString(0));
                            dict.Add("name", dataBaseReader.GetString(1));
                            dict.Add("description", dataBaseReader.GetString(2));
                            result.Add(dict);
                        }
                    }
                    transaction.Commit();
                }
            }

            return result;
        }

        // Убрать запись о выданной книге
        public void DeleteBookOrderByOne(int userId, int bookId)
        {
            using (SqliteConnection connection = new SqliteConnection(dbPathString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    var deleteCommand = connection.CreateCommand();
                    deleteCommand.Transaction = transaction;
                    deleteCommand.CommandText = "DELTE * FROM Order WHERE userid = '$userId’ AND bookid = '$bookId'";
                    deleteCommand.Parameters.AddWithValue("$userId", userId);
                    deleteCommand.Parameters.AddWithValue("$bookid", bookId);
                    deleteCommand.ExecuteNonQuery();
                    transaction.Commit();
                }
            }
        }

        // Добавить запись о выдаче книги
        public void AddBookOnTakenListByOne(int userId, int bookId)
        {
            using (SqliteConnection connection = new SqliteConnection(dbPathString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    var insertCommand = connection.CreateCommand();
                    insertCommand.Transaction = transaction;
                    insertCommand.CommandText = "INSERT INTO Order (bookid, userid)  VALUES ( $bookid, $userId )";
                    insertCommand.Parameters.AddWithValue("$userId", userId);
                    insertCommand.Parameters.AddWithValue("$bookid", bookId);
                    insertCommand.ExecuteNonQuery();
                    transaction.Commit();
                }
            }
        }
    }
}
