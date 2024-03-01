using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_day6
{
    class Program
    {
        public static void Swap(int num1,int num2)
        {
            num1 = num1 + num2;
            num2 = num1 - num2;
            num1 = num1 - num2;
            Console.WriteLine("swapping of 2 integer num1:{0} and the num2:{1}",num1 ,num2);
        }
        public static void Swap(char char1,char char2)//in same class 
        {
            char temp = char1;
            char1 = char2;
            char2 = temp;
            Console.WriteLine("swap of two character,char 1:{0} and char 2:  {1}",char1,char2);
        }
        static void Main(string[] args)
        {
            Swap(5, 10);//go to line 12 //this is early binding
            Swap('z', 'a');

            Console.ReadKey();

        }
    }
}
