using Api.User.Auth.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Api.User.Auth.Dao
{
    public class AuthDao : IAuthDao
    {
        SqlConnection connection = new SqlConnection(@"Server=(localdb)\mssqllocaldb;initial catalog=UserDb;Trusted_Connection=true");
        public void Add(RegisterRequestModel model)
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand($"insert into Users (FirstName,LastName,Email,Password) values ('{model.FirstName}','{model.LastName}','{model.Email}','{model.Password}')", connection);

            command.ExecuteNonQuery();
            connection.Close();

        }

        public bool CheckUser(LoginRequestModel model)
        {
            
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            SqlCommand command = new SqlCommand("Select * from Users", connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (Convert.ToString(reader["Email"]) ==model.Email&& Convert.ToString(reader["Password"]) == model.Password)
                {
                    connection.Close();
                    return true;
                    

                }
            }
            connection.Close();
            return false;
        }
    }
}
