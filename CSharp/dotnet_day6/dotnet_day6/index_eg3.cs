using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_day6
{
   

        public class Flower

        {

            string name;

            string color;

            public Flower(string name, string color)

            {

                this.name = name;

                this.color = color;

            }

            public void Display()

            {

                Console.WriteLine(name + " " + " is in " + color + "color");

            }

        }

        class Flowervase

        {

            Flower[] floobj = new Flower[2];// aggegation / creation

            //indexers, that keeps track of the array object 

            public Flower this[int pos]

            {

                get { return floobj[pos]; }

                set { floobj[pos] = value; }

            }

        }

        class index_eg3

        {

            static void Main()

            {

                Flowervase fv = new Flowervase();

                fv[0] = new Flower("Rose", "Red");

                fv[1] = new Flower("Lily", "white");

                for (int i = 0; i < 5; i++)

                {

                    fv[i].Display();

                }

                Console.Read();

            }

        }

    }


