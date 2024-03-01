using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotnet_day4
{
    class practice
    {
        
        
            static void Main()
            {


            //write a C# Sharp program to accept two integers and check whether they are equal or not. 

            EqualOrNot eq = new EqualOrNot();
            eq.CalculateEqual();

            ////Checking the number is postive or negative calling the class
            PositiveNegative pn = new PositiveNegative();
            pn.CalculatPosNeg();



            //// checking the number operatin 

            MathOper mo = new MathOper();
            mo.CalculateOper();

            //cheking the day with day no.

            DaysTeller dt = new DaysTeller();
            dt.ExactDay();



            //table program



            TableProg tp = new TableProg();
            tp.table();




            // max and min  and average


            ArrayMaxcs am = new ArrayMaxcs();
            am.MaXmin();



            //string programs
            ProgString ps = new ProgString();
            ps.strinProg();


            length ls = new length();
            ls.lengthCal();


        }
       
        }
}

