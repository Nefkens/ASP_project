using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace DAL.Data
{
    public class UserRepo : IUserRepo
    {
        private readonly string?  _connectionString;

        public UserRepo()
        {
            
            
        }

        public bool RegisterUser(string username, string hashedpassword)
        {
            string query = "INSERT INTO Users (Username, HashedPassword, Role) VALUES (@username, @Hashedpassword, 1)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@Hashedpassword", hashedpassword);

                        command.ExecuteNonQuery();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Er is een fout opgetreden: " + ex.Message);
                    return false;
                }
            }
        }

    }
}
