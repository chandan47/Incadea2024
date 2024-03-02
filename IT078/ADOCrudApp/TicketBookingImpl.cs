//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ADOCrudApp
//{

//    internal class TicketBookingImpl: TicketBooking
//    {

//        static void ViewCustomers()
//        {
//            string cs = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=DB;Integrated Security=true;";
//            using (SqlConnection connection = new SqlConnection(cs))
//            {
//                string query = "SELECT * FROM Customer";
//                SqlCommand command = new SqlCommand(query, connection);

//                connection.Open();
//                SqlDataReader reader = command.ExecuteReader();

//                Console.WriteLine("Customers:");
//                while (reader.Read())
//                {
//                    Console.WriteLine($"{reader["CustomerId"]}. {reader["FirstName"]} {reader["LastName"]} - Email: {reader["Email"]}, Phone: {reader["Phone"]}");
//                }
//                reader.Close();
//            }
//        }


//        static void ViewTheaters()
//        {
//            string cs = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=DB;Integrated Security=true;";

//            using (SqlConnection connection = new SqlConnection(cs))
//            {
//                string query = "SELECT * FROM Theater";
//                SqlCommand command = new SqlCommand(query, connection);

//                connection.Open();
//                SqlDataReader reader = command.ExecuteReader();

//                Console.WriteLine("Theaters:");
//                while (reader.Read())
//                {
//                    Console.WriteLine($"{reader["TheaterId"]}. {reader["Name"]} - Address: {reader["Address"]}, City: {reader["City"]}, State: {reader["State"]}, Zipcode: {reader["Zipcode"]}");
//                }
//                reader.Close();
//            }
//        }
//        static void ViewPlays()
//        {
//            string cs = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=DB;Integrated Security=true;";

//            using (SqlConnection connection = new SqlConnection(cs))
//            {
//                string query = "SELECT * FROM Play";
//                SqlCommand command = new SqlCommand(query, connection);

//                connection.Open();
//                SqlDataReader reader = command.ExecuteReader();

//                Console.WriteLine("Plays:");
//                while (reader.Read())
//                {
//                    Console.WriteLine($"{reader["PlayId"]}. {reader["Title"]} - Playwright: {reader["Playwright"]}, Director: {reader["Director"]}, Genre: {reader["Genre"]}, Duration: {reader["DurationMinutes"]} minutes");
//                }
//                reader.Close();
//            }
//        }



//        static void ViewPerformances()
//        {
//            string cs = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=DB;Integrated Security=true;";

//            using (SqlConnection connection = new SqlConnection(cs))
//            {
//                string query = "SELECT p.PerformanceId, pl.Title AS play_title, t.Name AS Theater_name, p.StartDateTime FROM Performance p INNER JOIN Play pl ON p.PlayId = pl.PlayId INNER JOIN Theater t ON p.TheaterId = t.TheaterId";
//                SqlCommand command = new SqlCommand(query, connection);

//                connection.Open();
//                SqlDataReader reader = command.ExecuteReader();

//                Console.WriteLine("Performances:");
//                while (reader.Read())
//                {
//                    Console.WriteLine($"Performance ID: {reader["PerformanceId"]}, Play Title: {reader["play_title"]}, Theater: {reader["Theater_name"]}, Start Date/Time: {reader["StartDateTime"]}");
//                }
//                reader.Close();
//            }
//        }


//        static void MakeBooking()
//        {
//            Console.WriteLine("Making a Booking:");
//            Console.WriteLine("------------------");

//            // Step 1: Select a Performance
//            int performanceId = SelectPerformance();
//            if (performanceId == -1)
//                return; // User canceled

//            // Step 2: Enter Customer Details
//            int customerId = EnterCustomerDetails();
//            if (customerId == -1)
//                return; // User canceled

//            // Step 3: Enter Number of Tickets
//            int numTickets = EnterNumberOfTickets();
//            if (numTickets == -1)
//                return; // User canceled

//            // Step 4: Confirm Booking
//            ConfirmBooking(performanceId, customerId, numTickets);


//        }


//        static int SelectPerformance()
//        {
//            Console.WriteLine("Available Performances:");
//            string cs = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=DB;Integrated Security=true;";

//            using (SqlConnection connection = new SqlConnection(cs))
//            {
//                string query = "SELECT PerformanceId, StartDateTime FROM Performance";
//                SqlCommand command = new SqlCommand(query, connection);

//                connection.Open();
//                SqlDataReader reader = command.ExecuteReader();

//                int count = 0;
//                while (reader.Read())
//                {
//                    count++;
//                    Console.WriteLine($"{count}. Performance ID: {reader["PerformanceId"]}, Date/Time: {reader["StartDateTime"]}");
//                }

//                reader.Close();

//                if (count == 0)
//                {
//                    Console.WriteLine("No performances available.");
//                    return -1; // No performances available
//                }

//                Console.Write("Enter the number corresponding to the performance (or 0 to cancel): ");
//                int selection;
//                if (!int.TryParse(Console.ReadLine(), out selection) || selection < 0 || selection > count)
//                {
//                    Console.WriteLine("Invalid selection. Please try again.");
//                    return SelectPerformance(); // Retry selection
//                }

//                if (selection == 0)
//                {
//                    Console.WriteLine("Booking canceled.");
//                    return -1; // User canceled
//                }

//                query = "SELECT COUNT(*) FROM Performance";
//                command = new SqlCommand(query, connection);
//                int performanceId = -1;

//                using (SqlDataReader innerReader = command.ExecuteReader())
//                {
//                    if (innerReader.Read())
//                    {
//                        performanceId = (int)innerReader[0];
//                    }
//                }

//                return performanceId;
//            }
//        }

//        static int EnterCustomerDetails()
//        {
//            Console.WriteLine("Step 2: Enter Customer Details:");

//            Console.Write("Enter First Name: ");
//            string firstName = Console.ReadLine();

//            Console.Write("Enter Last Name: ");
//            string lastName = Console.ReadLine();

//            Console.Write("Enter Email: ");
//            string email = Console.ReadLine();

//            Console.Write("Enter Phone: ");
//            string phone = Console.ReadLine();

//            // Insert customer details into the database
//            int customerId = InsertValues(firstName, lastName, email, phone);

//            if (customerId == -1)
//            {
//                Console.WriteLine("Booking canceled.");
//                return -1; // User canceled
//            }

//            Console.WriteLine("Customer details saved.");
//            return customerId;
//        }

//        static int EnterNumberOfTickets()
//        {
//            Console.WriteLine("Step 3: Enter Number of Tickets:");

//            Console.Write("Enter the number of tickets: ");
//            string input = Console.ReadLine();

//            int numTickets;
//            if (!int.TryParse(input, out numTickets) || numTickets <= 0)
//            {
//                Console.WriteLine("Invalid input. Please enter a valid number of tickets.");
//                return -1; // Invalid input
//            }

//            return numTickets;
//        }


//        static void ConfirmBooking(int performanceId, int customerId, int numTickets)
//        {
//            Console.WriteLine("\nBooking Summary:");
//            Console.WriteLine("----------------");

//            // Fetch performance details
//            string performanceDetails = FetchPerformanceDetails(performanceId);
//            Console.WriteLine(performanceDetails);

//            // Fetch customer details
//            string customerDetails = FetchCustomerDetails(customerId);
//            Console.WriteLine(customerDetails);

//            // Calculate total price
//            decimal totalPrice = CalculateTotalPrice(performanceId, numTickets);
//            Console.WriteLine($"Total Price: {totalPrice:C}");

//            Console.Write("\nIs this information correct? (Y/N): ");
//            string input = Console.ReadLine().Trim();

//            if (input.Equals("Y", StringComparison.OrdinalIgnoreCase))
//            {
//                // Insert booking into the database
//                if (InsertBooking(performanceId, customerId, numTickets, totalPrice))
//                {
//                    Console.WriteLine("\nBooking confirmed! Thank you for your reservation.");
//                }
//                else
//                {
//                    Console.WriteLine("\nFailed to confirm booking. Please try again.");
//                }
//            }
//            else
//            {
//                Console.WriteLine("\nBooking canceled.");
//            }
//        }


//        static string FetchPerformanceDetails(int performanceId)
//        {
//            string cs = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=DB;Integrated Security=true;";

//            using (SqlConnection connection = new SqlConnection(cs))
//            {
//                string query = "SELECT p.StartDateTime, pl.Title AS play_title, t.Name AS theater_name FROM Performance p INNER JOIN Play pl ON p.PlayId = pl.PlayId INNER JOIN Theater t ON p.TheaterId = t.TheaterId WHERE p.PerformanceId = @PerformanceId";
//                SqlCommand command = new SqlCommand(query, connection);
//                command.Parameters.AddWithValue("@PerformanceId", performanceId);

//                connection.Open();
//                SqlDataReader reader = command.ExecuteReader();

//                if (reader.Read())
//                {
//                    DateTime startDateTime = (DateTime)reader["StartDateTime"];
//                    string playTitle = (string)reader["play_title"];
//                    string theaterName = (string)reader["theater_name"];

//                    return $"Performance Date/Time: {startDateTime}, Play Title: {playTitle}, Theater: {theaterName}";
//                }
//                else
//                {
//                    return "Performance details not found.";
//                }
//            }
//        }



//        static string FetchCustomerDetails(int customerId)
//        {
//            string cs = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=DB;Integrated Security=true;";

//            using (SqlConnection connection = new SqlConnection(cs))
//            {
//                string query = "SELECT FirstName, LastName, Email, Phone FROM Customer WHERE CustomerId = @CustomerId";
//                SqlCommand command = new SqlCommand(query, connection);
//                command.Parameters.AddWithValue("@CustomerId", customerId);

//                connection.Open();
//                SqlDataReader reader = command.ExecuteReader();

//                if (reader.Read())
//                {
//                    string firstName = (string)reader["FirstName"];
//                    string lastName = (string)reader["LastName"];
//                    string email = (string)reader["Email"];
//                    string phone = (string)reader["Phone"];

//                    return $"Customer Name: {firstName} {lastName}, Email: {email}, Phone: {phone}";
//                }
//                else
//                {
//                    return "Customer details not found.";
//                }
//            }
//        }

//        static decimal CalculateTotalPrice(int performanceId, int numTickets)
//        {

//            string cs = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=DB;Integrated Security=true;";

//            using (SqlConnection connection = new SqlConnection(cs))
//            {
//                string query = "SELECT Price FROM Ticket WHERE PerformanceId = @PerformanceId";
//                SqlCommand command = new SqlCommand(query, connection);
//                command.Parameters.AddWithValue("@PerformanceId", performanceId);

//                connection.Open();
//                SqlDataReader reader = command.ExecuteReader();

//                if (reader.Read())
//                {
//                    decimal ticketPrice = (decimal)reader["Price"];
//                    return ticketPrice * numTickets;
//                }
//                else
//                {
//                    return -1; // Unable to fetch ticket price
//                }
//            }
//        }


//        static bool InsertBooking(int performanceId, int customerId, int numTickets, decimal totalPrice)
//        {
//            string cs = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=DB;Integrated Security=true;";

//            using (SqlConnection connection = new SqlConnection(cs))
//            {
//                string query = "INSERT INTO Booking (PerformanceId, CustomerId, NumTickets, TotalPrice) VALUES (@PerformanceId, @CustomerId, @NumTickets, @TotalPrice)";
//                SqlCommand command = new SqlCommand(query, connection);
//                command.Parameters.AddWithValue("@PerformanceId", performanceId);
//                command.Parameters.AddWithValue("@CustomerId", customerId);
//                command.Parameters.AddWithValue("@NumTickets", numTickets);
//                command.Parameters.AddWithValue("@TotalPrice", totalPrice);

//                try
//                {
//                    connection.Open();
//                    int rowsAffected = command.ExecuteNonQuery();
//                    return rowsAffected > 0;
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine($"Error: {ex.Message}");
//                    return false;
//                }
//            }
//        }

//    }
//}
