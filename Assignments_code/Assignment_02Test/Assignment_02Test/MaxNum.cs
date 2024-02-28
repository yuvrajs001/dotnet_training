using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_02Test
{

    //3. Write a C# Sharp program to check the largest number among three given integers.

////    Sample Input:
////1,2,3
////1,3,2
////1,1,1
////1,2,2
////Expected Output:
////3
////3
////1
////2
    class MaxNum
    { 
      public void MAXNUM()
        {
            Console.Write("Enter the size of the array: ");
            int size = int.Parse(Console.ReadLine());
            int[] arr = new int[size];

            Console.WriteLine("Enter  integers:");
            for (int i = 0; i < size; ++i)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            int maxElement = arr[0];

            for (int i = 1; i < size; ++i)
            {
                maxElement = Math.Max(maxElement, arr[i]);
            }
            
            Console.WriteLine($"Maximum value in the array: {maxElement}");


        }
    }
}
