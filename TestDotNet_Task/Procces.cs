using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace TestDotNet_Task
{
    class Procces
    {
        ISmtpSender _sender;
        string _connectionString;
        public Procces()
        {
            _sender = new MailSender();
            _connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=usersdb;Integrated Security=True";
        }

        public void AddCategory(string categoryTitle)
        {
            SqlParameter ct = new SqlParameter("@Category", categoryTitle);
            string sqlExpression = "SELECT id FROM Category WHERE Title = @Category";
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        Console.WriteLine("Error! That {0} category exists in database", categoryTitle);
                        return;
                    }

                    sqlExpression = "INSERT INTO Category (Title, Enabled) VALUES ('@Category', 1)";
                    command = new SqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();

                    if (number > 0)
                    {
                        _sender.SendMail("Added new category is " + categoryTitle);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured when try to add new category Info: {0}", ex);
            }
        }

        public void AddPost(string PostTitle, int userId, int CategoryId, string body)
        {
            SqlParameter[] myparams = new SqlParameter[4];
            myparams[0] = new SqlParameter ("@PostTitle", PostTitle);
            myparams[1] = new SqlParameter ("@userId", userId);
            myparams[2] = new SqlParameter ("@CategoryId", CategoryId);
            myparams[3] = new SqlParameter ("@body", body);

            string sqlExpression = "INSERT INTO Posts (Title, Body, UserId) OUTPUT INSERTED.ID VALUES ('@PostTitle', '@body', @userId)";
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    Int32 newId = (Int32)command.ExecuteScalar();

                    if (newId > 0)
                    {
                        SqlParameter id = new SqlParameter("@postId", newId);
                        sqlExpression = "INSERT INTO Category_to_Post (CategoryId, PostId) VALUES (@CategoryId, @postId)";
                        command = new SqlCommand(sqlExpression, connection);
                        int number = command.ExecuteNonQuery();

                        if (number > 0)
                        {
                            _sender.SendMail("Added new post is " + PostTitle);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured when try to add new category Info: {0}", ex);
            }
        
          
        }

    }

    
}
