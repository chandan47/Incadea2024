using System.Data;
using System;
using System.Data.SqlClient;
using System.Net;
using System.Reflection;
using System.Xml.Linq;

namespace InventoryManagementSystem
{
    class Program
    {
            static string connectionString = "Server=localhost\\SQLEXPRESS;Database=Inventory_Management;Trusted_Connection=True;TrustServerCertificate=True;";

        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Inventory Management System");
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. Update Quantity");
                Console.WriteLine("3. View Inventory");
                Console.WriteLine("4. Delete Item");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddItem();
                        break;
                    case 2:
                        UpdateQuantity();
                        break;
                    case 3:
                        ViewInventory();
                        break;
                    case 4:
                        DeleteQuantity();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        static void AddItem()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Console.Write("Enter item name: ");
                string itemName = Console.ReadLine();
                Console.Write("Enter quantity: ");
                string squantity = Console.ReadLine();
                int quantity = int.Parse(squantity);

                try
                {

                    using (SqlCommand cmd = new SqlCommand("AddItemProcedure", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@ItemName", itemName);
                        cmd.Parameters.AddWithValue("@Quantity", quantity);

                        cmd.ExecuteNonQuery();

                        Console.WriteLine("Item information inserted successfully!\n");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("An exception occurred " + e);
                }
            }
        }

        static void UpdateQuantity()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                
                Console.Write("Enter item ID: ");
                int itemId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter new quantity: ");
                int newQuantity = Convert.ToInt32(Console.ReadLine());

                string query = "UPDATE Inventory SET Quantity = @NewQuantity WHERE ItemID = @ItemID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NewQuantity", newQuantity);
                command.Parameters.AddWithValue("@ItemID", itemId);

                using (SqlCommand cmd = new SqlCommand("UpdateQuantityProcedure", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    cmd.Parameters.AddWithValue("@ItemId", itemId);
                    cmd.Parameters.AddWithValue("@NewQuantity", newQuantity);
                    
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                        Console.WriteLine("Item information updated successfully!\n");
                    else
                        Console.WriteLine("Item not found with the given ID.\n");
                }
            }
        }

        // Writing delete code
        static void DeleteQuantity()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                Console.Write("Enter Item ID to delete: ");
                int ItemID = int.Parse(Console.ReadLine());

                string query = "DELETE from Inventory WHERE ItemID = @ItemID";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlCommand cmd = new SqlCommand("DeleteItem", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Id", ItemID);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0) 
                        Console.WriteLine("Item information deleted successfully!\n");
                    else
                        Console.WriteLine("Item not found with the given ID.\n");
                }
            }
        }

        static void ViewInventory()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Inventory";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                Console.WriteLine("Inventory:");
                Console.WriteLine("ItemID\tItemName\tQuantity");
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["ItemID"]}\t{reader["ItemName"]}\t\t{reader["Quantity"]}\n");
                }
                reader.Close();
            }
        }
    }
}