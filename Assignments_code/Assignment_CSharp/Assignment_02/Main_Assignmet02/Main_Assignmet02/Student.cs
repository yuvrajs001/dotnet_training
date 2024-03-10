using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Main_Assignmet02
{
    class Student
    {
        // Answer 2
        public int RollNo { get; set; }
        public string Name { get; set; }
        public string StudentClass { get; set; }
        public string Semester { get; set; }
        public string Branch { get; set; }
        public int[] Marks { get; set; }

        // initialize of constructer for object with the provided value
        public Student(int rollNo, string name, string studentClass, string semester, string branch)
        {
            RollNo = rollNo;
            Name = name;
            StudentClass = studentClass;
            Semester = semester;
            Branch = branch;
        }

        // Method to input marks for subjects
        public void InputMarks()
        {
            Console.WriteLine($"Enter marks for {Name} (Roll No: {RollNo}):");

            Console.Write("Enter the number of subjects: ");
            int numSubjects = int.Parse(Console.ReadLine());

            Marks = new int[numSubjects];

            for (int i = 0; i < numSubjects; i++)
            {
                Console.Write($"Enter marks for Subject {i + 1}: ");
                Marks[i] = int.Parse(Console.ReadLine());
            }
        }

        // Method to calculate average marks and display result
        public void DisplayStudentResult()
        {
            
            
                int totalMarks = 0;
                foreach (var mark in Marks)
                {
                    totalMarks += mark;
                    if (mark < 35)
                    {
                        Console.WriteLine("Result: Failed (Marks in one or more subjects are less than 35)");
                        return;
                    }
                }

                double average = totalMarks / 5.0;

                if (average < 50)
                {
                    Console.WriteLine("Result: Failed (Average marks are less than 50)");
                }
                else
                {
                    Console.WriteLine("Result: Passed");
                }
            }

            // Method to display all data members
            public void DisplayData()
        {
            Console.WriteLine("\nStudent Details:");
            Console.WriteLine($"Roll No: {RollNo}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Class: {StudentClass}");
            Console.WriteLine($"Semester: {Semester}");
            Console.WriteLine($"Branch: {Branch}");
            Console.WriteLine($"Marks: {string.Join(", ", Marks)}");
        }

        // Method to input details for a student
        public static Student GetStudentDetails(int studentNumber)
        {
            Console.WriteLine($"\n--- Student {studentNumber} ---");
            Console.Write("Enter Roll No: ");
            int rollNo = int.Parse(Console.ReadLine());

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Class: ");
            string studentClass = Console.ReadLine();

            Console.Write("Enter Semester: ");
            string semester = Console.ReadLine();

            Console.Write("Enter Branch: ");
            string branch = Console.ReadLine();

            return new Student(rollNo, name, studentClass, semester, branch);
        }
    }

    class StudentProgram
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of students: ");
            int numStudents = int.Parse(Console.ReadLine());

            for (int i = 0; i < numStudents; i++)
            {
                Student student = Student.GetStudentDetails(i + 1);
                student.InputMarks();
                student.DisplayStudentResult();
                student.DisplayData();
            }
            Console.ReadKey();
        }
    }
}