using System.Data;
using System;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using System.ComponentModel.Design;

    string connectionString = "Server=localhost\\SQLEXPRESS;Database=QuickOrder;Trusted_Connection=True;TrustServerCertificate=True;";
    
        while (true)
        {
            Console.WriteLine("====================================");
            Console.WriteLine("1.Admin");
            Console.WriteLine("2.User");
            Console.WriteLine("3.Exit");
            Console.WriteLine("Choose one from above");
            Console.WriteLine("====================================");
            int ch = int.Parse(Console.ReadLine());
            switch (ch)
            {
                case 1:
                    Admin();
                    break;
                case 2:
                    User();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                defalut: Console.WriteLine("Invalid choice");
                    break;

            }
        }
    }
    static void Admin()
    {
        String user= "";
        Console.WriteLine("Enter the username");
        String username = Console.ReadLine();
        Console.WriteLine("Enter the password");
        String paswrd = "";
        String password = Console.ReadLine();

        using (SqlConnection connection = new SqlConnection(connectionString))

        {
            connection.Open();
            using (SqlCommand cmd1 = new SqlCommand("select username from Admin", connection))
            using (SqlCommand cmd2 = new SqlCommand("select password from Admin", connection))
            {
                user = Convert.ToString(cmd1.ExecuteScalar());
                paswrd = Convert.ToString(cmd2.ExecuteScalar());

                if (username.Equals(user) && password.Equals(paswrd))
                {
                    while (true)
                    {
                        Console.WriteLine("=========================================");
                        Console.WriteLine("1. Insert Item");
                        Console.WriteLine("2. Update Item");
                        Console.WriteLine("3. Delete Item");
                        Console.WriteLine("4. View All Items");
                        Console.WriteLine("5. UsersOrdered Items");
                        Console.WriteLine("6. DeleteOrdered Items");
                        Console.WriteLine("7. Exit");
                        Console.WriteLine("Choose one from above");
                        Console.WriteLine("=========================================");
                        int choice = int.Parse(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                InsertItem();
                                break;
                            case 2:
                                UpdateItem();
                                break;
                            case 3:
                                DeleteItem();
                                break;
                            case 4:
                                ViewAllItems();
                                break;
                                case 5:UsersOrderedItems();
                                break;
                            case 6:DeleteOrderedItems();
                                break;
                            case 7:
                                Main();
                                break;
                            default:
                                Console.WriteLine("Invalid choice. Please enter a valid option.");
                                break;
                        }
                    }
                }
                else
                    Console.WriteLine("Invalid admin details");
                }
            connection.Close();
        }
       
        }

    static void InsertItem()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            Console.Write("Enter Item ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter Item Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter ItemPrice: ");
            int Price = int.Parse(Console.ReadLine());
            using (SqlCommand cmd = new SqlCommand("InsertItem", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Price", Price);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Item inserted successfully!");
            }
            connection.Close();
        }
    }
    static void UpdateItem()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            Console.Write("Enter Item ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter Item Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter ItemPrice: ");
            string Price = Console.ReadLine();

            using (SqlCommand cmd = new SqlCommand("UpdateItem", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Price", Price);
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                    Console.WriteLine("Item updated successfully!");
                else
                    Console.WriteLine("Item not found with the given ID.");
            }
            connection.Close();
        }
    }
    static void DeleteItem()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            Console.Write("Enter Item Id to delete: ");
            int id = int.Parse(Console.ReadLine());

            using (SqlCommand cmd = new SqlCommand("DeleteOrderedItem", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                    Console.WriteLine("Item deleted successfully!");
                else
                    Console.WriteLine("Item not found with the given ID.");
            }
            connection.Close();
        }
    }
    static void ViewAllItems()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand cmd = new SqlCommand("SelectAllItems", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Console.WriteLine("\nItemList:");
                    while (reader.Read())
                    {
                        Console.WriteLine("-----------------------------------------");
                        Console.WriteLine($"ID: {reader["ItemId"]},| Name: {reader["ItemName"]},| Price: {reader["ItemPrice"]}|");
                        Console.WriteLine("-----------------------------------------");
                    }
                }
            }
            connection.Close();
        }
    }
    static void UsersOrderedItems()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand cmd = new SqlCommand("SelectOrderedItems", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Console.WriteLine("\nUser ordered OrderedItemList:");
                    while (reader.Read())
                    {
                        Console.WriteLine("========================================");
                        Console.WriteLine($"ID: {reader["ItemId"]},| Name: {reader["ItemName"]},| Price: {reader["ItemPrice"]}|");
                        Console.WriteLine("=========================================");
                    }
                }
            }
            connection.Close();
        }
    }
    static void DeleteOrderedItems()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            Console.Write("Enter Item Id to delete: ");
            int id = int.Parse(Console.ReadLine());

            using (SqlCommand cmd = new SqlCommand("DeleteItem", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                    Console.WriteLine("Item deleted successfully!");
                else
                    Console.WriteLine("Item not found with the given ID.");
            }
            connection.Close();
        }
    }
    static void User()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand cmd = new SqlCommand("SelectAllItems", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Console.WriteLine("\nItem List:");
                    while (reader.Read())
                    {
                        Console.WriteLine("-----------------------------------------");
                        Console.WriteLine($"ID: {reader["ItemId"]},| Name: {reader["ItemName"]},| Price: {reader["ItemPrice"]}|");
                        Console.WriteLine("-----------------------------------------");
                    }
                    
                }
                connection.Close();
            }
        }
        Console.WriteLine("Enter the Item Id,name and price to Order");
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            Console.Write("Enter Item ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter Item Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter ItemPrice: ");
            int Price = int.Parse(Console.ReadLine());
            using (SqlCommand cmd = new SqlCommand("InsertOrderedItem", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Price", Price);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Ordered successfully!");
            }
        }
    

