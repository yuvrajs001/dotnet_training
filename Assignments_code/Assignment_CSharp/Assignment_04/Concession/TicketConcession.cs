using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concession
{
    public class TicketConcession
    {

        private const int TotalFare = 500;

        public string Name { get; set; }
        public int Age { get; set; }

        public void CalConcession()
        {
            if (Age <= 5)
            {
                Console.WriteLine($"Hey Little buddy you have got Free Ticket | Name: {Name}, Age: {Age}");
            }
            else if (Age > 60)
            {
                double concessionAmount = 0.3 * TotalFare;
                double FareDiscount = TotalFare - concessionAmount;
                Console.WriteLine($"Senior Citizen | Name: {Name}, Age: {Age}, Fare: {FareDiscount:C}");
            }
            else
            {
                Console.WriteLine($"  Booking Information | Name: {Name}, Age: {Age},  Fare: {TotalFare:C}");
            }
        }




    }
}
