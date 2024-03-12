using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    //-------------Answer2---------------

    // using interface because it has flexibility to have more derived class.

    public interface IBox
    {
        double Length { get; }
        double Breadth { get; }
    }

    public class Box : IBox
    {
        public double Length { get; set; }
        public double Breadth { get; set; }

        public Box(double length, double breadth)
        {
            Length = length;
            Breadth = breadth;
        }

        // method for displaying the message
        public void Display()
        {
            Console.WriteLine($" The combined box  Length: {Length}, Breadth: {Breadth} ");
        }

        public  static Box GetUserInput()
        {
            //getting user input
            Console.Write("Enter the length of the box: ");
            double.TryParse(Console.ReadLine(), out double length);

            Console.Write("Enter the breadth of the box: ");
            double.TryParse(Console.ReadLine(), out double breadth);

            return new Box(length, breadth);
        }
    }

    //creating a function to ADD2Box
    public static class  AddBoxFun
    {

        public static IBox CombineBox(IBox box1, IBox box2)
        {
            return new Box(box1.Length + box2.Length, box1.Breadth + box2.Breadth);
        }
    }


    public class Test
    {
        public static void Main()
        {
           

            // Get user input for both boxes
            Console.WriteLine("Enter details for Box1:");
            Box box1 = Box.GetUserInput();

            Console.WriteLine("Enter details for Box2:");
            Box box2 = Box.GetUserInput();

            // Combine the boxes 
            IBox FinalBoxOutput = AddBoxFun.CombineBox(box1, box2);

            
            Console.WriteLine("\nResultant Box (Box 1 + Box 2):");

            ((Box)FinalBoxOutput).Display();
            Console.Read();
        }
    }

}
