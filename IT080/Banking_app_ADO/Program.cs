// See https://aka.ms/new-console-template for more information
using System.Data;
using System;
using System.Data.SqlClient;


class program
{
    static string connectionString = "Server=localhost\\SQLEXPRESS;Database=Banking;Trusted_Connection=True;TrustServerCertificate=True;";

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("1. Add Customer");
            Console.WriteLine("2. Update Customer Data");
            Console.WriteLine("3. Delete Customer Data");
            Console.WriteLine("4. View All Details of Customer");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    InsertCustomerData();
                    break;
                case 2:
                    UpdateCustomerData();
                    break;
                case 3:
                    DeleteCustomerData();
                    break;
                case 4:
                    ViewAllCustomerData();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
    }
    static void InsertCustomerData()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();


            Console.Write("Enter Customer Account Number: ");
            int Account_number= int.Parse(Console.ReadLine());

            Console.Write("Enter Customer name: ");
            string Name = Console.ReadLine();

            Console.Write("Enter Date of Birth (YYYY-MM-DD): ");
            DateTime DOB = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter your Age:");
            int Age = int.Parse(Console.ReadLine());

            Console.Write("Enter your Mobile Number: ");
            string Phone_no = Console.ReadLine();

            Console.Write("Enter Branch name: ");
            string Branch = (Console.ReadLine());

            Console.Write("Enter your Accoun_type : ");
            string Account_type = Console.ReadLine();

            

            using (SqlCommand cmd = new SqlCommand("InsertCustomer", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                
                cmd.Parameters.AddWithValue("@Account_number", Account_number);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@DOB", DOB);
                cmd.Parameters.AddWithValue("@Age", Age);
                cmd.Parameters.AddWithValue("@Phone_no", Phone_no);
                cmd.Parameters.AddWithValue("@Branch", Branch);
                cmd.Parameters.AddWithValue("@Account_type",Account_type);

                
                cmd.ExecuteNonQuery();

                Console.WriteLine("Customer Data inserted successfully!");
            }
        }

    }

    static void UpdateCustomerData()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            
            Console.Write("Enter Customer Account Number to update: ");
            int Account_number = int.Parse(Console.ReadLine());

            Console.Write("Enter New Customer Name: ");
            string Name = Console.ReadLine();

            Console.Write("Enter New Date of Birth (YYYY-MM-DD): ");
            DateTime DOB = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter the customer new age");
            int Age= int.Parse(Console.ReadLine());

            Console.Write("Enter New Mobile Number: ");
            string Phone_no = Console.ReadLine();

            Console.Write("Enter New Branch Nmae ");
            string Branch = (Console.ReadLine());

            Console.Write("Enter New Account_type ");
            string Account_type = Console.ReadLine();

            
            using (SqlCommand cmd = new SqlCommand("UpdateCustomer", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                
                cmd.Parameters.AddWithValue("@Account_number", Account_number);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@DOB", DOB);
                cmd.Parameters.AddWithValue("@Age", Age);
                cmd.Parameters.AddWithValue("@Phone_no", Phone_no);
                cmd.Parameters.AddWithValue("@Branch", Branch);
                cmd.Parameters.AddWithValue("@Account_type", Account_type);

                
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                    Console.WriteLine("Customer Data updated successfully!");
                else
                    Console.WriteLine("Account_number not found");
            }
        }
    }

    static void DeleteCustomerData()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            
            Console.Write("Enter Account Number to delete: ");
            int Account_number = int.Parse(Console.ReadLine());

           
            using (SqlCommand cmd = new SqlCommand("DeleteCustomer", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

               
                cmd.Parameters.AddWithValue("@Account_number", Account_number);

              int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                    Console.WriteLine("Customer Data deleted successfully!");
                else
                    Console.WriteLine("Account number not found");
            }
        }
    }

    static void ViewAllCustomerData()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            
            using (SqlCommand cmd = new SqlCommand("SelectAllCustomer", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Console.WriteLine("\nCustomer Data:");

                    while (reader.Read())
                    {
                        Console.WriteLine($"Account_number: {reader["Account_number"]}, Name: {reader["Name"]}, DOB: {reader["DOB"]}, " +
                                          $"Age: {reader["Age"]}, Phone_no: {reader["Phone_no"]},Branch: {reader["Branch"]}, " +
                                          $"Account_type: {reader["Account_type"]}");
                    }
                }
            }
        }
    }
}

