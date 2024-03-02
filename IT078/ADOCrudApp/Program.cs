


using System;
using System.Data.SqlClient;

namespace TicketBookingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            startLoop:
            Console.WriteLine("Press 1: Admin");
            Console.WriteLine("Press 2: User/Customer");
            int choice1 = Convert.ToInt32(Console.ReadLine());
            bool f = true;
            if (choice1 == 1)
            {
                while (true)
                {
                    Console.WriteLine("Welcome to the Theatre Booking System!");
                    Console.WriteLine("1. Show All Customers");
                    Console.WriteLine("2. Show Theaters Avaialable");
                    Console.WriteLine("3. Show All Plays");
                    Console.WriteLine("4. Add Customer");
                    Console.WriteLine("5. Insert Performances");
                    Console.WriteLine("6. Add Theater");
                    Console.WriteLine("7. Add Plays");
                    Console.WriteLine("8. View Performances");
                    //Console.WriteLine("5. Show Bookings");
                    Console.WriteLine("6. View Tickets");
                    //Console.WriteLine("7. Make Booking");
                    Console.WriteLine("9. Go Back");
                    Console.WriteLine("8. Exit");
                    Console.Write("Enter your choice: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            Program.ViewCustomers();
                            break;
                        case "2":
                            Program.ViewTheaters();
                            break;
                        case "3":
                            Program.ViewPlays();
                            break;
                        case "4":

                            //Program.ViewPerformances();
                            Console.WriteLine("Enter first name:");
                            string fname = Console.ReadLine();
                            Console.WriteLine("Enter first name:");
                            string lname = Console.ReadLine();
                            Console.WriteLine("Enter first name:");
                       
                            string email = Console.ReadLine();
                            Console.WriteLine("Enter first name:");
                            string phone = Console.ReadLine();
                            Program.InsertValues(fname, lname, email, phone);
                            break;
                        case "5":
                            // ViewBookings();
                            Program.InserValuesInPerformance();
                            break;
                        case "6":
                            Program.InsertValueInTheater();
                            break;
                        case "7":
                            //Program.MakeBooking();
                            Program.InsertValueInPlay();
                            break;
                        case "8":
                           // Program.ViewPerformances();
                            Program.ViewPerformances();
                            //Console.WriteLine("Thankyou");
                            break;
                        case "9":
                            goto startLoop;
                            //Console.WriteLine("Thankyou");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                    Console.WriteLine(); // Add a new line for better readability
                }
            }

            else if(choice1==2)
            {
                while (true)
                {


                    Console.WriteLine("Welcome to the Theatre Booking System!");
                    Console.WriteLine("1. Show All Customers");
                    Console.WriteLine("2. Show Theaters Avaialable");
                    Console.WriteLine("3. Show All Plays");
                    Console.WriteLine("4. View Performances");
                    Console.WriteLine("5. Show Bookings");
                    Console.WriteLine("6. View Tickets");
                    Console.WriteLine("7. Make Booking");
                    Console.WriteLine("8. Go Back");
                    Console.WriteLine("8. Exit");
                    Console.Write("Enter your choice: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            Program.ViewCustomers();
                            break;
                        case "2":
                            Program.ViewTheaters();
                            break;
                        case "3":
                            Program.ViewPlays();
                            break;
                        case "4":
                            Program.ViewPerformances();
                            break;
                        case "5":
                            // ViewBookings();
                            break;
                        case "6":
                            // ViewTickets();
                            break;
                        case "7":
                            Program.MakeBooking();
                            break;
                        case "8":
                            goto startLoop;
                            //Console.WriteLine("Thankyou");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                    Console.WriteLine(); // Add a new line for better readability
                }
            }

            // Connection string
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=DB;Integrated Security=true;";



            //Program.InsertValues();



            //Program.InserValuesInPerformance();

            //Program.InsertValueInTheater();



            //
        }

        static int InsertValues(string firstName, string lastName, string email, string phone)
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=DB;Integrated Security=true;";

            // Values to be inserted
            //string firstName = "Mozammil";
            //string lastName = "Hussain";
            //string email = "mozammil@gmail.com";
            //string phone = "1234567890";

            // SQL query to insert data into the Customer table
            string insertQuery = @"
                INSERT INTO [dbo].[Customer] ([FirstName], [LastName], [Email], [Phone])
                VALUES (@FirstName, @LastName, @Email, @Phone);";

            // Create a SqlConnection object
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create a SqlCommand object with the insert query and SqlConnection
                SqlCommand command = new SqlCommand(insertQuery, connection);

                // Add parameters for the values to be inserted
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Phone", phone);

                try
                {
                    // Open the connection
                    connection.Open();

                    // Execute the query
                    command.ExecuteNonQuery();

                    Console.WriteLine("Customer data inserted successfully.");
                    return 1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inserting customer data: {ex.Message}");
                    return -1;
                }
            }
            
           
        }
        static void ViewCustomers()
        {
            string cs = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=DB;Integrated Security=true;";
            using (SqlConnection connection = new SqlConnection(cs))
            {
                string query = "SELECT * FROM Customer";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                Console.WriteLine("Customers:"); 
                while (reader.Read())
                {   
                    Console.WriteLine($"{reader["CustomerId"]}. {reader["FirstName"]} {reader["LastName"]} - Email: {reader["Email"]}, Phone: {reader["Phone"]}");
                }
                reader.Close();
            }
        }

        static void ViewTheaters()
        {
            string cs = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=DB;Integrated Security=true;";

            using (SqlConnection connection = new SqlConnection(cs))
            {
                string query = "SELECT * FROM Theater";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                Console.WriteLine("Theaters:");
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["TheaterId"]}. {reader["Name"]} - Address: {reader["Address"]}, City: {reader["City"]}, State: {reader["State"]}, Zipcode: {reader["Zipcode"]}");
                }
                reader.Close();
            }
        }
        static void ViewPlays()
        {
            string cs = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=DB;Integrated Security=true;";

            using (SqlConnection connection = new SqlConnection(cs))
            {
                string query = "SELECT * FROM Play";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                Console.WriteLine("Plays:");
                while (reader.Read())
                {
                    Console.WriteLine($"{reader["PlayId"]}. {reader["Title"]} - Playwright: {reader["Playwright"]}, Director: {reader["Director"]}, Genre: {reader["Genre"]}, Duration: {reader["DurationMinutes"]} minutes");
                }
                reader.Close();
            }
        }



        static void ViewPerformances()
        {
            string cs = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=DB;Integrated Security=true;";

            using (SqlConnection connection = new SqlConnection(cs))
            {
                string query = "SELECT p.PerformanceId, pl.Title AS play_title, t.Name AS Theater_name, p.StartDateTime FROM Performance p INNER JOIN Play pl ON p.PlayId = pl.PlayId INNER JOIN Theater t ON p.TheaterId = t.TheaterId";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                Console.WriteLine("Performances:");
                while (reader.Read())
                {
                    Console.WriteLine($"Performance ID: {reader["PerformanceId"]}, Play Title: {reader["play_title"]}, Theater: {reader["Theater_name"]}, Start Date/Time: {reader["StartDateTime"]}");
                }
                reader.Close();
            }
        }


        static void InserValuesInPerformance()
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=DB;Integrated Security=true;";

            // Values to be inserted
            
            

            Console.WriteLine("Enter Play Id");
            int playId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Theater Id");
            int theaterId = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("Enter start date");
            DateTime startDateTime = DateTime.Now; // start date/time



            // SQL query to insert data into the Performance table
            string insertQuery = @"
                INSERT INTO [dbo].[Performance] ([PlayId], [TheaterId], [StartDateTime])
                VALUES (@PlayId, @TheaterId, @StartDateTime);";

            // create SqlConnection 
            using (SqlConnection connection= new SqlConnection(connectionString))
            {
                
                SqlCommand command = new SqlCommand(insertQuery, connection);

                
                command.Parameters.AddWithValue("@PlayId", playId);
                command.Parameters.AddWithValue("@TheaterId", theaterId);
                command.Parameters.AddWithValue("@StartDateTime", startDateTime);

                try
                {
                    // Open the connection
                    connection.Open();

                   
                    command.ExecuteNonQuery();

                    Console.WriteLine("Performance data inserted successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inserting performance data: {ex.Message}");
                }
            }


            
        }

        static void InsertValueInPlay()
        {
            // Connection string
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=DB;Integrated Security=true;";

            
            string title = Console.ReadLine();
            string playwright = Console.ReadLine();
            string director = Console.ReadLine();
            string genre = Console.ReadLine();
            int durationMinutes = Convert.ToInt32(Console.ReadLine());

            
            string insertQuery = @"
                INSERT INTO [dbo].[Play] ([Title], [Playwright], [Director], [Genre], [DurationMinutes])
                VALUES (@Title, @Playwright, @Director, @Genre, @DurationMinutes);";

            // Create a SqlConnection object
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Create a SqlCommand object with the insert query and SqlConnection
                SqlCommand command = new SqlCommand(insertQuery, connection);

                // Add parameters for the values to be inserted
                command.Parameters.AddWithValue("@Title", title);
                command.Parameters.AddWithValue("@Playwright", playwright);
                command.Parameters.AddWithValue("@Director", director);
                command.Parameters.AddWithValue("@Genre", genre);
                command.Parameters.AddWithValue("@DurationMinutes", durationMinutes);

                try
                {
                    //open the connection
                    connection.Open();

                    
                    command.ExecuteNonQuery();

                    Console.WriteLine("Play data inserted successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inserting play data: {ex.Message}");
                }
            }
        }

        static void InsertValueInTheater()
        {
            // connection string
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=DB;Integrated Security=true;";


            Console.WriteLine("Enter NAme Of Theater");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Address");
            string address = Console.ReadLine();
            Console.WriteLine("Enterc City");
            string city = Console.ReadLine();
            Console.WriteLine("Enter state");
            string state = Console.ReadLine();
            Console.WriteLine("Enter Zipcode");
            string zipcode = Console.ReadLine();

           
            string insertQuery = @"
                INSERT INTO [dbo].[Theater] ([Name], [Address], [City], [State], [Zipcode])
                VALUES (@Name, @Address, @City, @State, @Zipcode);";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
              
                SqlCommand command = new SqlCommand(insertQuery, connection);

                
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Address", address);
                command.Parameters.AddWithValue("@City", city);
                command.Parameters.AddWithValue("@State", state);
                command.Parameters.AddWithValue("@Zipcode", zipcode);

                try
                {
                    // Open the connection
                    connection.Open();

                    // Execute the query
                    command.ExecuteNonQuery();

                    Console.WriteLine("Theater data inserted successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inserting theater data: {ex.Message}");
                }
            }
        }

        static void InsertValueInPerformance()
        {
            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=DB;Integrated Security=true;";

            Console.WriteLine("Enter PerFormance ID");
            int playId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Theater ID");
            int theaterId = Convert.ToInt32(Console.ReadLine()); ; 
            DateTime startDateTime = DateTime.Now; 

           
            string insertQuery = @"
                INSERT INTO [dbo].[Performance] ([PlayId], [TheaterId], [StartDateTime])
                VALUES (@PlayId, @TheaterId, @StartDateTime);";

            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                SqlCommand command = new SqlCommand(insertQuery, connection);

                command.Parameters.AddWithValue("@PlayId", playId);
                command.Parameters.AddWithValue("@TheaterId", theaterId);
                command.Parameters.AddWithValue("@StartDateTime", startDateTime);

                try
                {
                    // Open the connection
                    connection.Open();

                    // Execute the query
                    command.ExecuteNonQuery();

                    Console.WriteLine("Performance data inserted successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error inserting performance data: {ex.Message}");
                }
            }
        }

        static void MakeBooking()
        {
            Console.WriteLine("Making a Booking:");
            Console.WriteLine("------------------");

            // step 1: Select a Performance
            int performanceId=SelectPerformance();
            if (performanceId== -1)
                return; // user canceled

            // step 2 Enter Customer Details
            int customerId=EnterCustomerDetails();
            if (customerId ==-1)
                return; // User canceled

            // step 3: Enter Number of Tickets
            int numTickets = EnterNumberOfTickets();
            if (numTickets == -1)
                return; // User canceled

            //step 4 confirm Booking
            ConfirmBooking(performanceId, customerId, numTickets);


        }


        static int SelectPerformance()
        {
            Console.WriteLine("Available Performances:");
            string cs = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=DB;Integrated Security=true;";

            using (SqlConnection connection = new SqlConnection(cs))
            {
                string query = "SELECT PerformanceId, StartDateTime FROM Performance";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                int count = 0;
                while (reader.Read())
                {
                    count++;
                    Console.WriteLine($"{count}. Performance ID: {reader["PerformanceId"]}, Date/Time: {reader["StartDateTime"]}");
                }

                reader.Close();

                if (count== 0)
                {
                    Console.WriteLine("No performances available.");
                    return -1; // no performances available
                }

                Console.Write("Enter the number corresponding to the performance (or 0 to cancel): ");
                int selection;
                if (!int.TryParse(Console.ReadLine(), out selection) || selection < 0 || selection > count)
                {
                    Console.WriteLine("Invalid selection. Please try again.");
                    return SelectPerformance(); // Retry selection
                }

                if (selection== 0)
                {
                    Console.WriteLine("Booking canceled.");
                    return -1; // User canceled
                }

                query = "SELECT COUNT(*) FROM Performance";
                command = new SqlCommand(query, connection);
                int performanceId= -1;

                using (SqlDataReader innerReader = command.ExecuteReader())
                {
                    if (innerReader.Read())
                    {
                        performanceId = (int)innerReader[0];
                    }
                }

                return performanceId;
            }
        }

        static int EnterCustomerDetails()
        {
            Console.WriteLine("Step 2: Enter Customer Details:");

            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter Phone: ");
            string phone = Console.ReadLine();

            // Insert customer details into the database
            int customerId = InsertValues(firstName,lastName,email,phone);

            if (customerId == -1)
            {
                Console.WriteLine("Booking canceled.");
                return -1; //user canceled
            }

            Console.WriteLine("Customer details saved.");
            return customerId;
        }

        static int EnterNumberOfTickets()
        {
            Console.WriteLine("Step 3: Enter Number of Tickets:");

            Console.Write("Enter the number of tickets: ");
            string input = Console.ReadLine();

            int numTickets;
            if (!int.TryParse(input, out numTickets) || numTickets <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a valid number of tickets.");
                return -1; // Invalid input
            }

            return numTickets;
        }


        static void ConfirmBooking(int performanceId, int customerId, int numTickets)
        {
            Console.WriteLine("\nBooking Summary:");
            Console.WriteLine("----------------");

            // fetch performance details
            string performanceDetails = FetchPerformanceDetails(performanceId);
            Console.WriteLine(performanceDetails);

            // fetch customer details
            string customerDetails = FetchCustomerDetails(customerId);
          //  Console.WriteLine(customerDetails);

            //calculate total price
            decimal totalPrice = CalculateTotalPrice(performanceId, numTickets);
            Console.WriteLine($"Total Price: {totalPrice:C}");

            Console.Write("\nIs this information correct? (Y/N): ");
            string input = Console.ReadLine().Trim();

            if (input.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                
                if (InsertBooking(performanceId, customerId, numTickets, totalPrice))
                {
                    Console.WriteLine("\nBooking confirmed! Thank you for your reservation.");
                }
                else
                {
                    Console.WriteLine("\nFailed to confirm booking. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("\nBooking canceled.");
            }
        }


        static string FetchPerformanceDetails(int performanceId)
        {
            string cs = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=DB;Integrated Security=true;";

            using (SqlConnection connection = new SqlConnection(cs))
            {
                string query = "SELECT p.StartDateTime, pl.Title AS play_title, t.Name AS theater_name FROM Performance p INNER JOIN Play pl ON p.PlayId = pl.PlayId INNER JOIN Theater t ON p.TheaterId = t.TheaterId WHERE p.PerformanceId = @PerformanceId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PerformanceId", performanceId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    DateTime startDateTime = (DateTime)reader["StartDateTime"];
                    string playTitle = (string)reader["play_title"];
                    string theaterName = (string)reader["theater_name"];

                    return $"Performance Date/Time: {startDateTime}, Play Title: {playTitle}, Theater: {theaterName}";
                }
                else
                {
                    return "Performance details not found.";
                }
            }
        }



        static string FetchCustomerDetails(int customerId)
        {
            string cs = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=DB;Integrated Security=true;";

            using (SqlConnection connection = new SqlConnection(cs))   
            {
                string query = "SELECT FirstName, LastName, Email, Phone FROM Customer WHERE CustomerId = @CustomerId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerId", customerId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string firstName = (string)reader["FirstName"];
                    string lastName = (string)reader["LastName"];
                    string email = (string)reader["Email"];
                    string phone = (string)reader["Phone"];

                    return $"Customer Name: {firstName} {lastName}, Email: {email}, Phone: {phone}";
                }
                else
                {
                    return "Customer details not found.";
                }
            }
        }

        static decimal CalculateTotalPrice(int performanceId, int numTickets)
        {

            string cs = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=DB;Integrated Security=true;";

            using (SqlConnection connection = new SqlConnection(cs))
            {
                string query = "SELECT Price FROM Ticket WHERE PerformanceId = @PerformanceId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PerformanceId", performanceId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    decimal ticketPrice = (decimal)reader["Price"];
                    return ticketPrice * numTickets;
                }
                else
                {
                    return -1; // not able to fetch ticket price
                }
            }
        }


        static bool InsertBooking(int performanceId, int customerId, int numTickets, decimal totalPrice)
        {
            string cs = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=DB;Integrated Security=true;";

            using (SqlConnection connection = new SqlConnection(cs))
            {
                string query = "INSERT INTO Booking (PerformanceId, CustomerId, NumTickets, TotalPrice) VALUES (@PerformanceId, @CustomerId, @NumTickets, @TotalPrice)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PerformanceId", performanceId);
                command.Parameters.AddWithValue("@CustomerId", customerId);
                command.Parameters.AddWithValue("@NumTickets", numTickets);
                command.Parameters.AddWithValue("@TotalPrice", totalPrice);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    return false;
                }
            }
        }
    }
}

