using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_day7
{
    class VotingException : ApplicationException
    {
        public VotingException (String  msg): base (msg)
        {

        }
    }
    class Vote
    {
        int age;
       
        public void AcceptAge()
        {
            Console.WriteLine("enter your age");
            age = int.Parse(Console.ReadLine());
            if (age <= 18)
            {
                throw (new VotingException("AGE SHOUD BE GREATER THAN"));
            }
            else
            {
                Console.WriteLine("thanku for voting ");
            }

         
        }
        
    }
    class userdefined_exception 
    {
        static void Main()
        {
            Vote vote = new Vote();
            try
            {
                vote.AcceptAge();
            }
            catch(VotingException ve)
            {
                Console.WriteLine(ve.Message);
                
            }
            Console.ReadLine();
        }

    }
}
