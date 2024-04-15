using MiniProjectAdo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjetsAdo
{
    class Program
    {
        static MiniProjectEntities db = new MiniProjectEntities();
        static train Trains = new train();
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Train Booking Project Created by Yuvraj");
            Console.WriteLine("\n1. Press 1 to Login as User");
            Console.WriteLine("\n2. Press 2 to Login as Admin");
            Console.WriteLine("\n3. Press 3 to Exit");

            Console.Write("\nEnter your choice: ");
            string LoginType = Console.ReadLine();


            switch (LoginType)
            {
                case "1":
                    // UserLogin();
                    UserControl();
                    break;
                case "2":
                    //AdminLogin();
                    AdminControl();
                    break;
                case "3":
                    Console.WriteLine("\nExiting From the train tickit booking app...");
                    break;
                default:
                    Console.WriteLine(" \nPlease enter a valid option.");
                    break;
            }
            Console.ReadKey();

        }

        // admin login functionality 
        static void AdminLogin()
        {
            Console.WriteLine("\nYou have Selected Admin Login Please enter valid  credential"); //for user username=admin,pass=1234

            Console.Write("\nEnter username: ");
            string username = Console.ReadLine();

            Console.Write("\nEnter password: ");
            string password = Console.ReadLine();


            var CheckUser = db.Admins.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (CheckUser != null)
            {
                Console.WriteLine("\nYou have Login successfully");
                // method to display  the admin controls 
                AdminControl();
            }
            else
            {
                Console.WriteLine("\nUser login failed: try again...");
            }

        }

        static void AdminControl()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("\nAdmin Menu:");
                    Console.WriteLine("\nEnter 1. Add Train");
                    Console.WriteLine("\nEnter 2. Modify Train");
                    Console.WriteLine("\nEnter 3. Soft Delete Train");
                    Console.WriteLine("\nEnter 4. Toggle between Train Status");
                    Console.WriteLine("\nEnter 5. View All train");
                    Console.WriteLine("\nEnter 6. Exit");

                    Console.Write("\nEnter your choice: ");

                    string AdminInput = Console.ReadLine();
                    switch (AdminInput)
                    {
                        case "1":
                            AddTrain();
                            break;
                        case "2":
                            ModifyTrain();
                            break;
                        case "3":
                            SoftDeleteTrain();
                            break;
                        case "4":
                            ChangeTrainStatusActiveInactive();
                            break;
                        case "5":
                            ShowAlltrain();
                            break;
                        case "6":
                            Console.WriteLine("Exiting...");
                            return; // Exit the method and stop the while loop
                        default:
                            Console.WriteLine("Please enter a valid option.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }


        //calling a procedur to add a train
        static void AddTrain()
        {

            try
            {
                Console.WriteLine("\nEnter Train Number");
                Trains.trainID = int.Parse(Console.ReadLine());

                Console.Write("\nEnter Train Name: ");
                Trains.trainName = Console.ReadLine();

                Console.Write("\nEnter Source: ");
                Trains.Source = Console.ReadLine();

                Console.Write("\nEnter Destination: ");
                Trains.Destination = Console.ReadLine();
                Trains.Status = "Y";

                // Call the stored procedure to add a new train
                db.trains.Add(Trains);
                db.SaveChanges();

                Console.WriteLine("Train added successfully.");
                // AddTrainBerthInfo();

                //Define berth classes and their seats
                var berthClasses = new List<string> { "AC", "3A", "General" };

                foreach (var berthClass in berthClasses)
                {
                    Console.WriteLine($"\nEnter Total Seats for {berthClass} for :{Trains.trainID} ");
                    int totalSeats = int.Parse(Console.ReadLine());

                    Console.WriteLine($"\nEnter Available Seats for {berthClass} for :{Trains.trainID} ");
                    int availableSeats = int.Parse(Console.ReadLine());

                    Console.WriteLine($"\nEnter Price for {berthClass} for :{Trains.trainID} ");
                    decimal price = decimal.Parse(Console.ReadLine());

                    // call the stored procedure to add train berth information
                    db.AddTrainBerthInfo(Trains.trainID, berthClass, totalSeats, availableSeats, price);
                    db.SaveChanges();

                }
                Console.WriteLine("Train Berth Information added successfully.");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: { ex.Message}");
            }
        }

 

 

        static void ModifyTrain()
        {
            try
            {
                Console.Write("Enter Train ID to update: ");
                int trainID = int.Parse(Console.ReadLine());

                Console.Write("Enter Train Name: ");
                string trainName = Console.ReadLine();

                Console.Write("Enter Source: ");
                string Source = Console.ReadLine();

                Console.Write("Enter Destination: ");
                string Destination = Console.ReadLine();

                // Call the stored procedure to update an existing train
                db.ModifyTrain(trainID, trainName, Source, Destination);
                Console.WriteLine("Train Updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: { ex.Message}");
            }
        }

        static void SoftDeleteTrain()
        {

            Console.Write("Enter Train ID to soft delete: ");
            int trainID = int.Parse(Console.ReadLine());

            // Call the stored procedure  to delete train to make its status inactive

            //soft delete train mark the status of that train is inactive
            db.SoftDeleteTrain(trainID);
            db.SaveChanges();

            Console.WriteLine("Train soft deleted successfully.");

        }



        static void ChangeTrainStatusActiveInactive()
        {
            Console.WriteLine("\n if status is y(active)/N(Inactive) it will make it Inactive(N)/Active(Y)");
            Console.Write("\nEnter Train ID to change  status: ");
            int trainID = int.Parse(Console.ReadLine());

            // Call the stored procedure to toggle train status between active and inactive
            db.ChangeTrainStatus(trainID);


            db.ViewTrainStatus(trainID);
            db.SaveChanges();

            Console.WriteLine("Train status changed  successfully.");

            var train = db.ViewTrain(trainID).FirstOrDefault();
            Console.WriteLine($"TrainID : {train.trainID} train Name : {train.trainName} trainstatus  : {train.Status}");

        }

        static void ViewTrain()
        {
            //thta procedure is called only to see that particuler activity done on that train
            //it  is called with db.ViewTrain(@TrainID)
            //Console.Write("Enter Train ID to toggle status: ");
            //int trainID = int.Parse(Console.ReadLine());
            //db.ViewTrainStatus(trainID);
            //var train = db.ViewTrain(trainID).FirstOrDefault();
            //Console.WriteLine($"TrainID: {train.trainID} train Name:{train.trainName} trainstatus:{train.Status}");
        }
        static void ShowAlltrain()
        {
            var trains = db.ShowAllTrain().ToList();
            Console.WriteLine("\nTrains:");
            foreach (var train in trains)
            {
                Console.WriteLine("------------------------------------------------------------------------------------------------------");
                Console.WriteLine($"TrainID: {train.trainID}, TrainName: {train.trainName}, Source: {train.Source}, Destination: {train.Destination}, Status: {train.Status}");
                Console.WriteLine("-------------------------------------------------------------------------------------------------------");

            }
        }




        static void UserLogin()
        {
            Console.WriteLine("\nYou have Selected User Login Please enter valid  credential"); //for user username=admin,pass=1234

            Console.Write("\nEnter username: ");
            string username = Console.ReadLine();

            Console.Write("\nEnter password: ");
            string password = Console.ReadLine();


            var CheckUser = db.UserPers.FirstOrDefault(u => u.UserName == username && u.Password == password);
            if (CheckUser != null)
            {
                Console.WriteLine("\nYou have Login successfully");
                // method to display  the user controls 
                UserControl();
            }
            else
            {
                Console.WriteLine("\nUser login failed: try again...");
            }
        }

  
        /// -------------------------------------------------------------------------------------------------------------------------------------------------------
       
        static void UserControl()
        {

            while (true)
            {
                try
                {
                    Console.WriteLine("\nUser  Menu:");
                    Console.WriteLine("\nEnter 1. Show All Trains");
                    Console.WriteLine("\nEnter 2. BookTickit");
                    Console.WriteLine("\nEnter 3. Print Ticket Information");
                    Console.WriteLine("\nEnter 4. Cancel Ticket");
                    Console.WriteLine("\nEnter 6. Exit");

                    Console.Write("\nEnter your choice: ");

                    string AdminInput = Console.ReadLine();
                    switch (AdminInput)
                    {
                        case "1":
                            ShowAlltrain();
                            break;
                        case "2":
                            BookTicket();
                            break;
                        case "3":
                            PrintTicket();
                            break;
                        case "4":
                            Cancelticket();
                            break; 
                        case "5":
                            Console.WriteLine("Exiting...");
                            return; // Exit the method and stop the while loop
                        default:
                            Console.WriteLine("Please enter a valid option.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
          


        }
        
        public static void BookTicket()
        {
            ActiveTrainInfo();
            BirthInformation();

            try
            {
                Console.WriteLine("\nEnter details to Book TICKET");
                Console.WriteLine("\nEnter Your Name :");
                string userName = Console.ReadLine();
                Console.WriteLine("\nEnter Train Number :");
                int trainID = int.Parse(Console.ReadLine());
                Console.WriteLine("\nEnter Berth Class in which you want to travel:");
                string birthClass = Console.ReadLine();

                Console.WriteLine("\nHow Many Tickets You Want TO book:");
                int totalTickets = int.Parse(Console.ReadLine());

                db.BookTrainTicket(userName, trainID, birthClass, totalTickets);


                var lastBookingID = db.GetLastBookingID().FirstOrDefault();//gives me last booking id because it sets as identity(1,1) so it will give me always max(booking id created last time)

                
                 Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                Console.WriteLine("-------------------------------------------------------------------------------------------------------");

                Console.WriteLine($"Your ticket Booked Successfully, your booking ID is: {lastBookingID.Value}");
                Console.WriteLine("-------------------------------------------------------------------------------------------------------");
                Console.WriteLine("----------------------------------------------------note always remember your booking id---------------------------------------------------");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        public static void ActiveTrainInfo()
        {
            try
            {
                var activeTrains = db.GetActiveTrains().ToList();
                foreach (var train in activeTrains)
                {
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine($"TrainID: {train.trainID}, TrainName: {train.trainName}, Source: {train.Source}, Destination: {train.Destination}, Status: Active Running Trains ");
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        public static void BirthInformation()
        {
            Console.Write("\nEnter Train ID to see Birth details for You want to book ticket : ");
            int trainID = int.Parse(Console.ReadLine());

            var TrainbirthInfos = db.GetBirthDetal(trainID).ToList();

            if (TrainbirthInfos.Count > 0)
            {
                foreach (var train in TrainbirthInfos)
                {
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine($"Train : {train.TrainID} / Birth Class  : {train.BerthClass} / Available Seats : {train.AvailableSeats} / Total Seats :{train.TotalSeats}");
                    Console.WriteLine($"Price  :{train.price}");
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("Error: Data is not available for the specified Train ID.");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------");
                Environment.Exit(0); 
            }

        }
        public static void PrintTicket()
        {
            Console.WriteLine("Enter Your Booking ID");
            int bookingId = int.Parse(Console.ReadLine());
            var ticket = db.Printticket(bookingId).FirstOrDefault();
            if (ticket != null)
            {

                Console.WriteLine("-------------------------------------");
                Console.WriteLine("            TICKET DETAILS           ");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine($"Booking ID: {ticket.BookingID}");
                Console.WriteLine($"Train ID: {ticket.TrainID}");
                Console.WriteLine($"User Name: {ticket.UserName}");
                Console.WriteLine($"Berth Class: {ticket.berthType}");
                Console.WriteLine($"Total Tickets: {ticket.Totaltickets}");
                Console.WriteLine($"Booking Status: {(ticket.BookingStatus == "Y" ? "Active" : "Inactive")}");
                Console.WriteLine($"Payment Amount: ${ticket.payment_amount}");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("               Thnaks                ");
                Console.WriteLine("-------------------------------------");
            }
            else
            {
                Console.WriteLine("Booking not found.");
            }

        }
        public static void Cancelticket()
        {
            Console.WriteLine("Enter Your Booking ID");
            int bookingId = int.Parse(Console.ReadLine());
            db.CancelTicketData(bookingId);

            Console.WriteLine("Ticket cancelled successfully.");
        }
    }

}