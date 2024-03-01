using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



// this program is according to ++ binary operator and using conditional statement to calculate travel distance
namespace dotnet_day7
{   

        class Travel
        {
            public int Dist { get; set; } // to get the value of distance tr1 and tr2
            public DateTime Traveldate { get; set; }

            // Overload the '+' operator to add two distances
            public static Travel operator +(Travel tr1, Travel tr2)
            {
                Travel temp = new Travel();
                temp.Dist = tr1.Dist + tr2.Dist;
                return temp;
            }

            // Overload the '++' operator to increment the distance
            public static Travel operator ++(Travel tr)
            {
                tr.Dist++; // for increment the distace by1
                return tr;
            }
        }

        class Operator_Overload
        {
            public static void Main()
            {
                Travel t1 = new Travel();
                Travel t2 = new Travel();
                t1.Dist = 14;
                t2.Dist = 5;

                // Add distances using the '+' operator
                Travel t3 = t1 + t2;
                Console.WriteLine("The total Distance To Travel is: " + t3.Dist);

                // Increment the distance using the '++' operator
                t3++;
                Console.WriteLine("After incrementing, the new Distance To Travel is: " + t3.Dist);

                // Example of using if-else condition
                if (t3.Dist > 50)
                    Console.WriteLine("You have travel more than 50 km today wowwwwwww");
                else
                    Console.WriteLine(" you didn't travel your daily travel limit so keep going");

                Console.Read();
            }
        }
    }

    
    

