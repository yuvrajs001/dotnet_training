using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_01Test
{
    class ArrayMaxcs
    {
        public void MaXmin()
        {

            Console.Write("Enter the size of the array: ");
            int size = int.Parse(Console.ReadLine());
            int[] arr = new int[size];


            Console.WriteLine("Enter {size} integers:");
            for (int i = 0; i < size; ++i)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            int minElement = arr[0];
            int maxElement = arr[0];

            for (int i = 1; i < size; ++i)
            {
                minElement = Math.Min(minElement, arr[i]);
                maxElement = Math.Max(maxElement, arr[i]);
            }

            Console.WriteLine($"Minimum value in the array: {minElement}");
            Console.WriteLine($"Maximum value in the array: {maxElement}");

            int total = arr.Sum();
            double average = (double)total / size;

            Console.WriteLine("Total marks: {0}", total);
            Console.WriteLine("Average marks: {0}", average);


            Array.Sort(arr); // Sort in ascending order
            int[] descendingMarks = arr.Reverse().ToArray(); // Create a descending order array
            Console.WriteLine("Marks in ascending order: {0}", string.Join(", ", arr));
            Console.WriteLine("Marks in descending order: {0}", string.Join(", ", descendingMarks));





            Console.ReadKey();
        }
        }
    }
