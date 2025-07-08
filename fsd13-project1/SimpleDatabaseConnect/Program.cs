using Microsoft.Data.SqlClient;

namespace SimpleDatabaseConnect
{
    class Program
    {
        const string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\db\FSD-test.mdf;Integrated Security=True;Connect Timeout=30";

        void Main(String[] args)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    Random random = new Random();
                    //insertion
                    {
                        using (SqlCommand command = new SqlCommand("INSERT INTO people(Name, Age, Telephone) VALUES (@Name, @Age, @Tel)", sqlConnection))
                        {
                            command.Parameters.AddWithValue("@Name", "JAC");
                            command.Parameters.AddWithValue("@Age", random.Next(5, 90));
                            command.Parameters.AddWithValue("@Tel", random.Next(5000, 8000));
                            command.ExecuteNonQuery();
                        }
                    }

                    //select
                    {
                        using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM People", sqlConnection))
                        {
                            using (SqlDataReader reader = sqlCommand.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int id = reader.GetInt32(reader.GetOrdinal("id"));
                                    string name = reader.GetString(reader.GetOrdinal("name"));
                                    int age = reader.GetInt32(reader.GetOrdinal("age"));
                                    string tel = reader.GetString(reader.GetOrdinal("Telephone"));
                                    Console.WriteLine($"id {id} : name : {name}, age : {age} tel : {tel}");
                                }
                            }
                        }

                    }

                    //specific record
                    {
                        int fetchedId = 4;
                        using (SqlCommand sqlCommand = new SqlCommand("SELECT * FROM People WHERE Id=@Id", sqlConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("@Id", fetchedId);

                            using (SqlDataReader reader = sqlCommand.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    int id = reader.GetInt32(reader.GetOrdinal("id"));
                                    string name = reader.GetString(reader.GetOrdinal("name"));
                                    int age = reader.GetInt32(reader.GetOrdinal("age"));
                                    string tel = reader.GetString(reader.GetOrdinal("Telephone"));
                                    
                                    
                                    Console.WriteLine($" The fetched data is => id {id} : name : {name}, age : {age} tel : {tel}");
                                }
                            }
                        }
                    }



                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}