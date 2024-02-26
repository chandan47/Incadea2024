using System;
using System.Data;
using System.Transactions;
using System.Data.SqlClient;
using System.Xml.Linq;

class OnlineStore
{
    public static string connectionString = "Server=localhost\\SQLEXPRESS;Database=OnlineStore;Trusted_Connection=True;TrustServerCertificate=True;";


    public void SignUp()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            String Password;
            Console.WriteLine("Enter Your Name");
            string Name = Console.ReadLine();
            Console.WriteLine("Enter Your Email");
            string Email = Console.ReadLine();
            Console.WriteLine("Enter Your Phone Number");
            string Phone = Console.ReadLine();
            Console.WriteLine("Enter Your age");
            int Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Your Gender");
            string Gender = Console.ReadLine();
            Console.WriteLine("Enter Your Address");
            String Address = Console.ReadLine();
            Console.WriteLine("Enter Password :");
            string password = Console.ReadLine();
            //Console.WriteLine("Confirm Your Password");
            //String CNFpassword = Console.ReadLine();
            //if (password == CNFpassword)
            //{
            //    Password = password;
            //}
            //else
            //{
            //    Console.WriteLine("Passwords doesn't matches");
            //    Console.WriteLine("Please enter the details again");
            //    SignUp();
            //}

            using (SqlCommand cmd = new SqlCommand("CustomerLogin", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustName", Name);
                cmd.Parameters.AddWithValue("@CustEmail", Email);
                cmd.Parameters.AddWithValue("@CustPhone", Phone);
                cmd.Parameters.AddWithValue("@CustAge", Age);
                cmd.Parameters.AddWithValue("@CustGender", Gender);
                cmd.Parameters.AddWithValue("@CustAddress", Address);
                cmd.Parameters.AddWithValue("@CustPassword", password);
                cmd.ExecuteNonQuery();
            }
           
        }
    }
    public void Login()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            Console.WriteLine("Enter Your Phone Number");
            String phone = Console.ReadLine();
            Console.WriteLine("Enter Password");
            String Password = Console.ReadLine();
        }
    }


    public void Order()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            Console.WriteLine("*******************************************************");
            Console.WriteLine("Enter the ");
            int ans;
            do
            {
                Console.WriteLine("What would you like to order   ¯\\_(ツ)_/¯");
                Console.WriteLine("1.Milk \n2.Cheese \n3.Butter \n4.Ghee \n5.Paneer");
                int choice = Convert.ToInt32(Console.ReadLine());
                using (SqlCommand cmd = new SqlCommand("InventryManagement", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductId", choice);
                    cmd.ExecuteNonQuery();
                }

                using (SqlCommand cmd = new SqlCommand("OrderManagement", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductId", choice);
                    cmd.ExecuteNonQuery();
                }
                Console.WriteLine("Anything else...?");
                Console.WriteLine("1. Yes\n2. No");
                ans = int.Parse(Console.ReadLine());
            } while (ans == 1);
                Console.WriteLine("\n\nORDER PLACED....!!!!");

        }
    }


    static void Main(string[] args)
    {
        OnlineStore onlineStore = new OnlineStore();
        Console.WriteLine("!!------ Welcome to VEDANT AGRO STORE (●'◡'●) -------");
        Console.WriteLine("Enter 1 to SignUp");
        Console.WriteLine("Enter 2 to Login");
        int choice = Convert.ToInt32(Console.ReadLine());
        while (choice != 1 || choice != 2)
        {
            if (choice == 1)
            {
               onlineStore.SignUp();
                break;
            }
            else if (choice == 2)
            {
                onlineStore.Login();
            }
        }
        Console.WriteLine("Would You like to order");
        Console.WriteLine("1. Yes \n2.No");
        int ch = Convert.ToInt32(Console.ReadLine());
        if(ch == 1)
        {
            onlineStore.Order();
        }
        else
        {
            Console.WriteLine("Thanks for visit....!!!");
        }
    }
}