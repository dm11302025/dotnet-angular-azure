using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApp
{
    internal class Demo1
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("Welcome to Arrays");
                //array declaration
                int[] nos = new int[4] { 12, 23, 34, 45 };
                string[] names = new string[3];
                //assign values
                names[0] = "Ram";
                names[1] = "Krishna";
                names[2] = "Virat";
                //names[3] = "Rohith"; //exception occure here
                Console.WriteLine(names[2]);
                foreach(var item in names)
                {
                    Console.WriteLine($"{item}");
                }
                //2 dimensional array
                int[,] _2darray = new int[3, 2];
                //assign values
                _2darray[0, 0] = 10;
                _2darray[0, 1] = 12;
                _2darray[1, 0] = 13;
                _2darray[1, 1] = 15;
                _2darray[2, 0] = 17;
                _2darray[2, 1] = 19;
                for(int r=0; r<3; r++)
                {
                    for(int c=0;c<2;c++)
                    {
                        Console.Write(_2darray[r, c] + " ");
                    }
                    Console.WriteLine();
                }
                //Jagged Array
                int[][] jarray= new int[3][];
                jarray[0] = new int[5] { 1, 2, 3, 4, 5 };
                jarray[1] = new int[3] { 6, 7, 8 };
                jarray[2] = new int[4] { 12, 23, 34, 45 };
                foreach(var item in jarray[0])
                {
                    Console.WriteLine(item);
                }

               
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
    }
}
