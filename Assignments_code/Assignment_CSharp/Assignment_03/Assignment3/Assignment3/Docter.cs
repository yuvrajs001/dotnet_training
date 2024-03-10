using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{

    // -----------------Answer5---------------
        class Doctor
        {
            private string RegNo;
            private string Name;
            private double Fees;

            public void SetValues(string RegNo, string Name, double Fees)
            {
                this.RegNo = RegNo;
                this.Name = Name;
                this.Fees = Fees;
            }

            public void DisplayInfo()
            {
                Console.WriteLine($"Sir,  Your Registration Number: {RegNo}");
                Console.WriteLine($"Doctor's Name: {Name}");
                Console.WriteLine($"Fees Charged: {Fees}"); // C format specifier for currency
            }

            public static Doctor GetUserInput()
            {
               Doctor newDoctor = new Doctor();

              // USER INPUT
                Console.Write("Enter Registration Number: ");
                string regnNoInput = Console.ReadLine();

                Console.Write("Enter Doctor's Name: ");
                string nameInput = Console.ReadLine();

                Console.Write("Enter Fees Charged: ");
                double FeesInput = Convert.ToInt32(Console.ReadLine());



                newDoctor.SetValues(regnNoInput, nameInput, FeesInput);

                return newDoctor;
            }
        }

        class DocterProg
        {
            static void Main()
            {
                Doctor doctorN = Doctor.GetUserInput();

                // Displaying the information
                doctorN.DisplayInfo();
                Console.ReadKey();
            }
        }
    }

