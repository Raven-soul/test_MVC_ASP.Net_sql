using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using test.Models;

namespace test.SQL {
    public class BookDb {
        string dbPathString = "";

        public BookDb(string dbPath) {
            dbPathString = dbPath;
        }

        // Получить список всех элементов базы данных книг
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
                    selectCommand.CommandText = "SELECT * FROM Book";

                    using (var dataBaseReader = selectCommand.ExecuteReader())
                    {
                        while (dataBaseReader.Read())
                        {
                            Dictionary<string, string> temp = new Dictionary<string, string>();
                            temp.Add("id", dataBaseReader.GetString(0));
                            temp.Add("name", dataBaseReader.GetString(1));
                            temp.Add("description", dataBaseReader.GetString(2));
                            result.Add(temp);
                        }
                    }
                    transaction.Commit();
                }
            }
            return result;
        }

        // Получить один элемент из базы данных книг
        public Dictionary<string, string> GetOne(int bookId)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            using (SqliteConnection connection = new SqliteConnection(dbPathString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    var selectCommand = connection.CreateCommand();
                    selectCommand.Transaction = transaction;
                    selectCommand.CommandText = "SELECT * FROM Book WHERE id = '$bookId’";
                    selectCommand.Parameters.AddWithValue("$bookId", bookId);

                    using (var dataBaseReader = selectCommand.ExecuteReader())
                    {
                        while (dataBaseReader.Read())
                        {
                            result.Add("id", dataBaseReader.GetString(0));
                            result.Add("name", dataBaseReader.GetString(1));
                            result.Add("description", dataBaseReader.GetString(2));
                        }
                    }
                    transaction.Commit();
                }
            }
            return result;
        }

        // Получить все записи на выдачу данной книги
        public List<Order> GetOrdersByOne(int bookId)
        {
            List<Dictionary<string, string>> searchResult = new List<Dictionary<string, string>>();
            Dictionary<string, string> dict = new Dictionary<string, string>();

            using (SqliteConnection connection = new SqliteConnection(dbPathString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    var selectCommand = connection.CreateCommand();
                    selectCommand.Transaction = transaction;
                    selectCommand.CommandText = "SELECT * FROM Order WHERE bookid = $bookId";
                    selectCommand.Parameters.AddWithValue("$bookId", bookId);

                    using (var dataBaseReader = selectCommand.ExecuteReader())
                    {
                        while (dataBaseReader.Read())
                        {
                            dict.Add("id", dataBaseReader.GetString(0));
                            dict.Add("bookId", dataBaseReader.GetString(1));
                            dict.Add("userId", dataBaseReader.GetString(2));
                            searchResult.Add(dict);
                        }
                    }
                    transaction.Commit();
                }
            }
            List<Order> result = new List<Order>();
            foreach (var dictItem in searchResult)
            {
                result.Add(new Order
                {
                    id = int.Parse(dictItem["id"]),
                    bookId = int.Parse(dictItem["bookId"]),
                    userId = int.Parse(dictItem["userId"])
                });
            }

            return result;
        }

        // Добавить в базу новую книгу
        public void SetOne(string bookName, string description)
        {
            using (SqliteConnection connection = new SqliteConnection(dbPathString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    var insertCommand = connection.CreateCommand();
                    insertCommand.Transaction = transaction;
                    insertCommand.CommandText = "INSERT INTO Book (name, description)  VALUES ( $bookName, $description )";
                    insertCommand.Parameters.AddWithValue("$bookName", bookName);
                    insertCommand.Parameters.AddWithValue("$description", description);
                    insertCommand.ExecuteNonQuery();
                    transaction.Commit();
                }
            }
        }

        // Внести изменения в запись базы данных
        public void EditOne (int bookId, string description)
        {
            using (SqliteConnection connection = new SqliteConnection(dbPathString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    var updateCommand = connection.CreateCommand();
                    updateCommand.Transaction = transaction;
                    updateCommand.CommandText = "UPDATE Book SET description = $description WHERE id = $bookId";
                    updateCommand.Parameters.AddWithValue("$bookId", bookId);
                    updateCommand.Parameters.AddWithValue("$description", description);
                    updateCommand.ExecuteNonQuery();
                    transaction.Commit();
                }
            }
        }
    }
}

