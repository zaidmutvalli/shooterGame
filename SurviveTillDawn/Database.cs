using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using System.IO;

namespace SurviveTillDawn
{
    internal class Database
    {
        private static string dbPath = @"D:\ZaidPrograms\PrType2 - Copy\SurviveTillDawn\bin\Debug\Users.db";
        private static string connectionString = $"Data Source={dbPath};Version=3;";

        public static User GetUser(string username)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {

                conn.Open();
                string query = "SELECT * FROM userData WHERE Username = @username";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                Id = Convert.ToInt32(reader["ID"]),
                                Username = reader["Username"].ToString(),
                                Password = reader["Password"].ToString(),
                                HighScore = Convert.ToInt32(reader["HighScore"]) // ← brackets not needed in code
                            };
                        }
                    }
                }
            }

            return null;
        }

        public static void SetHighScore(string username, int newHighScore)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                // Get current high score from the "HighScore" column
                string selectQuery = "SELECT HighScore FROM userData WHERE Username = @username";
                using (var selectCmd = new SQLiteCommand(selectQuery, conn))
                {
                    selectCmd.Parameters.AddWithValue("@username", username);
                    var result = selectCmd.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int currentScore))
                    {
                        if (newHighScore > currentScore)
                        {
                            string updateQuery = "UPDATE userData SET HighScore = @score WHERE Username = @username";
                            using (var updateCmd = new SQLiteCommand(updateQuery, conn))
                            {
                                updateCmd.Parameters.AddWithValue("@score", newHighScore);
                                updateCmd.Parameters.AddWithValue("@username", username);
                                updateCmd.ExecuteNonQuery();
                            }
                        }
                    }
                    else
                    {
                        // No existing score, just insert/update directly
                        string updateQuery = "UPDATE userData SET HighScore = @score WHERE Username = @username";
                        using (var updateCmd = new SQLiteCommand(updateQuery, conn))
                        {
                            updateCmd.Parameters.AddWithValue("@score", newHighScore);
                            updateCmd.Parameters.AddWithValue("@username", username);
                            updateCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }



        public static void InsertUser(string username, string password)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO userData (Username, Password, [HighScore]) VALUES (@username, @password, 0)";


                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.ExecuteNonQuery();
                }
            }
        }


    }
}
