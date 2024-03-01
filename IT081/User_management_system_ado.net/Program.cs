using System.Data.SqlClient;
using System.Data;
//using System.Threading.Channels;
//using System.Net;
//using System.Reflection;
//using System.Xml.Linq;


namespace UserManagementSystem
{
    class Program
    {
        static string connectionString = "Server=INCIN-X291-G01\\SQLEXPRESS; Database=ado_database;Trusted_Connection=True;TrustServerCertificate=True;";

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("User's Details Management System");
                Console.WriteLine("1. Add User");
                Console.WriteLine("2. Update User");
                Console.WriteLine("3. View Database");
                Console.WriteLine("4. Delete User");
                Console.WriteLine("5. Quit");
                Console.WriteLine("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddUser();
                        break;
                    case 2:
                        UpdateUser();
                        break;
                    case 3:
                        ViewDatabase();
                        break;
                    case 4:
                        DeleteUser();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Wrong Choice");
                        break;



                }
            }
        }
        static void AddUser()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                Console.WriteLine("Enter the id:");
                int userId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the name: ");
                string userName = Console.ReadLine();
                Console.WriteLine("Enter the gender: ");
                string userGender = Console.ReadLine();
                Console.WriteLine("Enter the age ");
                int userAge = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the salary: ");
                int userSalary = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the city");
                string userCity = Console.ReadLine();

                try
                {
                    using (SqlCommand cmd = new SqlCommand("AddUserProcedure", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.Parameters.AddWithValue("@userName", userName);
                        cmd.Parameters.AddWithValue("@userGender", userGender);
                        cmd.Parameters.AddWithValue("@userAge", userAge);
                        cmd.Parameters.AddWithValue("@userSalary", userSalary);
                        cmd.Parameters.AddWithValue("@userCity", userCity);

                        cmd.ExecuteNonQuery();

                        Console.WriteLine("Data inserted successfully");

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("An exception occurred" + e);

                }

            }
        }


        static void UpdateUser()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                Console.WriteLine("Enter the id of the user you want to update:");
                int userId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the new name: ");
                string userName = Console.ReadLine();
                Console.WriteLine("Enter the new gender: ");
                string userGender = Console.ReadLine();
                Console.WriteLine("Enter the new age ");
                int userAge = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the new salary: ");
                int userSalary = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the new city");
                string userCity = Console.ReadLine();

                try
                {
                    using (SqlCommand cmd = new SqlCommand("UpdateUserProcedure", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.Parameters.AddWithValue("@userName", userName);
                        cmd.Parameters.AddWithValue("@userGender", userGender);
                        cmd.Parameters.AddWithValue("@userAge", userAge);
                        cmd.Parameters.AddWithValue("@userSalary", userSalary);
                        cmd.Parameters.AddWithValue("@userCity", userCity);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                            Console.WriteLine("User updated successfully");
                        else
                            Console.WriteLine("No user found with the given ID");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("An exception occurred" + e);
                }
            }
        }

        static void DeleteUser()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                Console.WriteLine("Enter the id of the user you want to delete:");
                int userId = Convert.ToInt32(Console.ReadLine());

                try
                {
                    using (SqlCommand cmd = new SqlCommand("DeleteUserProcedure", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@userId", userId);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                            Console.WriteLine("User deleted successfully");
                        else
                            Console.WriteLine("No user found with the given ID");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("An exception occurred" + e);
                }
            }
        }

        static void ViewDatabase()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                try
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Users", con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                Console.WriteLine("UserId\tName\tGender\tAge\tSalary\tCity");
                                while (reader.Read())
                                {
                                    Console.WriteLine("\n---------------------------------------------------------------------------");
                                    Console.WriteLine($"{reader["UserId"]}\t{reader["UserName"]}\t{reader["UserGender"]}\t{reader["UserAge"]}\t{reader["UserSalary"]}\t{reader["UserCity"]}");
                                }
                                Console.WriteLine("\n---------------------------------------------------------------------------");
                            }
                            else
                            {
                                Console.WriteLine("No users found in the database.");
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("An exception occurred" + e);
                }
            }
        }




    }
}