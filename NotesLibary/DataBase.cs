using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NotesLibary
{
    public class DataBase
    {
        public SQLiteConnection Connection { get; private set; }

        #region Data Base Constructor

        public DataBase()
        {
            Connection = new SQLiteConnection("Data Source=database.db");
            if (!System.IO.File.Exists("database.db"))
            {
                SQLiteConnection.CreateFile("database.db");

                using (var connection = new SQLiteConnection("Data Source=database.db"))
                {
                    connection.Open();

                    string createUsersTable = @"
                    CREATE TABLE Users (
                        UserID INTEGER PRIMARY KEY AUTOINCREMENT,
                        Username TEXT NOT NULL,
                        Password TEXT NOT NULL
                    );";

                    string createCategoriesTable = @"
                    CREATE TABLE Categories (
                        CategoryID INTEGER PRIMARY KEY AUTOINCREMENT,
                        CategoryName TEXT NOT NULL,
                        UserID INTEGER,
                        FOREIGN KEY (UserID) REFERENCES Users(UserID)
                    );";

                    string createNotesTable = @"
                    CREATE TABLE Notes (
                        NoteID INTEGER PRIMARY KEY AUTOINCREMENT,
                        UserID INTEGER,
                        CategoryID INTEGER,
                        Title TEXT NOT NULL,
                        Content TEXT NOT NULL,
                        FOREIGN KEY (UserID) REFERENCES Users(UserID),
                        FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
                    );";

                    using (var command = new SQLiteCommand(connection))
                    {
                        command.CommandText = createUsersTable;
                        command.ExecuteNonQuery();

                        command.CommandText = createCategoriesTable;
                        command.ExecuteNonQuery();

                        command.CommandText = createNotesTable;
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        #endregion

        #region Add Data

        public void AddNoteToCategory(int userID, int categoryID, string title, string content)
        {
            using (var connection = new SQLiteConnection("Data Source=database.db"))
            {
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "INSERT INTO Notes (UserID, CategoryID, Title, Content) VALUES (@UserID, @CategoryID, @Title, @Content);";
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Parameters.AddWithValue("@CategoryID", categoryID);
                    command.Parameters.AddWithValue("@Title", title);
                    command.Parameters.AddWithValue("@Content", content);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void AddCategory(int userID, string categoryName)
        {
            using (var connection = new SQLiteConnection("Data Source=database.db"))
            {
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "INSERT INTO Categories (UserID, CategoryName) VALUES (@UserID, @CategoryName);";
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Parameters.AddWithValue("@CategoryName", categoryName);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void AddUser(string username, string password)
        {
            using (var connection = new SQLiteConnection($"Data Source=database.db"))
            {
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "INSERT INTO Users (Username, Password) VALUES (@Username, @Password);";
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    command.ExecuteNonQuery();
                }
            }
        }

        #endregion

        #region Update Data

        public void UpdateNoteTitle(int noteID, string title)
        {
            using (var connection = new SQLiteConnection("Data Source=database.db"))
            {
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "UPDATE Notes SET Title = @Title WHERE NoteID = @NoteID;";
                    command.Parameters.AddWithValue("@Title", title);
                    command.Parameters.AddWithValue("@NoteID", noteID);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateNoteContent(int noteID, string content)
        {
            using (var connection = new SQLiteConnection("Data Source=database.db"))
            {
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "UPDATE Notes SET Content = @Content WHERE NoteID = @NoteID;";
                    command.Parameters.AddWithValue("@Content", content);
                    command.Parameters.AddWithValue("@NoteID", noteID);
                    command.ExecuteNonQuery();
                }
            }
        }


        public void UpdateCategoryName(int categoryID, string categoryName)
        {
            using (var connection = new SQLiteConnection("Data Source=database.db"))
            {
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "UPDATE Categories SET CategoryName = @CategoryName WHERE CategoryID = @CategoryID;";
                    command.Parameters.AddWithValue("@CategoryName", categoryName);
                    command.Parameters.AddWithValue("@CategoryID", categoryID);
                    command.ExecuteNonQuery();
                }
            }
        }

        #endregion

        #region Get Data

        public int GetNoteIdByTitleAndUserID(string title, int userID)
        {
            int noteId = -1; // значение по умолчанию, если пользователь не найден

            using (var connection = new SQLiteConnection("Data Source=database.db"))
            {
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "SELECT NoteID FROM Notes WHERE Title = @Title AND UserID = @UserID;";
                    command.Parameters.AddWithValue("@Title", title);
                    command.Parameters.AddWithValue("@UserID", userID);

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        noteId = Convert.ToInt32(result);
                    }
                }
            }

            return noteId;
        }

        public string GetNoteContentByNoteID(int noteID)
        {
            string content = string.Empty;

            using (var connection = new SQLiteConnection("Data Source=database.db"))
            {
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "SELECT Content FROM Notes WHERE NoteID = @NoteID;";
                    command.Parameters.AddWithValue("@NoteID", noteID);

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        content = result.ToString();
                    }
                }
            }

            return content;
        }


        public int GetUserIdByUsername(string username)
        {
            int userId = -1; // значение по умолчанию, если пользователь не найден

            using (var connection = new SQLiteConnection("Data Source=database.db"))
            {
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "SELECT UserID FROM Users WHERE Username = @Username;";
                    command.Parameters.AddWithValue("@Username", username);

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        userId = Convert.ToInt32(result);
                    }
                }
            }

            return userId;
        }

        public int GetCategoryIdByCategoryNameAndUserID(string categoryName, int userID)
        {
            int categoryId = -1; // значение по умолчанию, если категория не найдена

            using (var connection = new SQLiteConnection("Data Source=database.db"))
            {
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "SELECT CategoryID FROM Categories WHERE CategoryName = @CategoryName AND UserID = @UserID;";
                    command.Parameters.AddWithValue("@CategoryName", categoryName);
                    command.Parameters.AddWithValue("@UserID", userID);

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        categoryId = Convert.ToInt32(result);
                    }
                }
            }

            return categoryId;
        }

        #endregion

        #region Delete Data

        public void DeleteNoteByTitleAndUserID(string title, int userID)
        {
            int noteID = GetNoteIdByTitleAndUserID(title, userID);

            using (var connection = new SQLiteConnection("Data Source=database.db"))
            {
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "DELETE FROM Notes WHERE NoteID = @NoteID;";
                    command.Parameters.AddWithValue("@NoteID", noteID);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteAllNotesByCategoryIDAndUserID(int categoryID, int userID)
        {
            using (var connection = new SQLiteConnection("Data Source=database.db"))
            {
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "DELETE FROM Notes WHERE CategoryID = @CategoryID AND UserID = @UserID;";
                    command.Parameters.AddWithValue("@CategoryID", categoryID);
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteCategoryByCategoryNameAndUserID(string categoryName, int userID)
        {
            int categoryID = GetCategoryIdByCategoryNameAndUserID(categoryName, userID);
            DeleteAllNotesByCategoryIDAndUserID(categoryID, userID);

            using (var connection = new SQLiteConnection("Data Source=database.db"))
            {
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "DELETE FROM Categories WHERE CategoryID = @CategoryID;";
                    command.Parameters.AddWithValue("@CategoryID", categoryID);
                    command.ExecuteNonQuery();
                }
            }
        }

        #endregion

        #region Data Existence Check

        public bool DoesACategoryWithThisNameExistForThisUserID(int userID, string categoryName)
        {
            bool result = false;

            using (var connection = new SQLiteConnection("Data Source=database.db"))
            {
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    // Создаем запрос для проверки имени пользователя и пароля
                    command.CommandText = "SELECT COUNT(*) FROM Categories WHERE UserID = @UserID AND CategoryName = @CategoryName;";
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Parameters.AddWithValue("@CategoryName", categoryName);

                    // Выполняем запрос и получаем количество пользователей с указанными учетными данными
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    // Если количество больше 0, то пользователь существует и введенный пароль совпадает
                    result = count > 0;
                }
            }
            return result;
        }

        public bool DoesANoteWithThisNameExistForThisUserID(int userID, string title)
        {
            bool result = false;

            using (var connection = new SQLiteConnection("Data Source=database.db"))
            {
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    // Создаем запрос для проверки имени пользователя и пароля
                    command.CommandText = "SELECT COUNT(*) FROM Notes WHERE UserID = @UserID AND Title = @Title;";
                    command.Parameters.AddWithValue("@UserID", userID);
                    command.Parameters.AddWithValue("@Title", title);

                    // Выполняем запрос и получаем количество пользователей с указанными учетными данными
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    // Если количество больше 0, то пользователь существует и введенный пароль совпадает
                    result = count > 0;
                }
            }
            return result;
        }

        public bool IsUsernameExists(string username)
        {
            bool result = false;

            using (var connection = new SQLiteConnection("Data Source=database.db"))
            {
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "SELECT COUNT(*) FROM Users WHERE Username = @Username;";
                    command.Parameters.AddWithValue("@Username", username);

                    // Выполняем запрос и получаем количество пользователей с таким именем
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    // Если количество больше 0, значит пользователь существует
                    result = count > 0;
                }
            }

            return result;
        }

        public bool IsUserCredentialsValid(string username, string password)
        {
            bool result = false;

            using (var connection = new SQLiteConnection("Data Source=database.db"))
            {
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    // Создаем запрос для проверки имени пользователя и пароля
                    command.CommandText = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password;";
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    // Выполняем запрос и получаем количество пользователей с указанными учетными данными
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    // Если количество больше 0, то пользователь существует и введенный пароль совпадает
                    result = count > 0;
                }
            }

            return result;
        }

        #endregion

        #region Data Lists

        public List<string> GetNotesByCategoryID(int categoryID)
        {
            List<string> notes = new List<string>();

            using (var connection = new SQLiteConnection("Data Source=database.db"))
            {
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "SELECT Title FROM Notes WHERE CategoryID = @CategoryID;";
                    command.Parameters.AddWithValue("@CategoryID", categoryID);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string noteTitle = reader["Title"].ToString();
                            notes.Add(noteTitle);
                        }
                    }
                }
            }

            return notes;
        }

        public List<string> GetAllCategoriesByUserID(int userID)
        {
            List<string> categoryNames = new List<string>();

            using (var connection = new SQLiteConnection("Data Source=database.db"))
            {
                connection.Open();

                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "SELECT CategoryName FROM Categories WHERE UserID = @UserID;";
                    command.Parameters.AddWithValue("@UserID", userID);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string categoryName = reader["CategoryName"].ToString();
                            categoryNames.Add(categoryName);
                        }
                    }
                }
            }

            return categoryNames;
        }
        #endregion
    }
}
