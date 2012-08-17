using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace ProjectEuler.Problem22
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            long sum = 0;

            //// LINQ Sort
            //string[] input = ReadInput(@"..\..\names.txt");
            //string[] names = input.OrderBy(n => n).ToArray();

            // Array Sort (performs an unstable sort using the QuickSort algorithm)
            string[] names = ReadInput(@"..\..\names.txt");
            Array.Sort(names);

            for (int i = 0; i < names.Length; i++)
            {
                sum += (i + 1) * Sum(names[i]);
            }

            stopwatch.Stop();

            Console.WriteLine(
                "Result: " + sum + Environment.NewLine +
                "Elapsed Time: " + stopwatch.ElapsedMilliseconds + "ms");

            Console.WriteLine("Press ENTER to quit");
            Console.ReadLine();
        }

        private static string[] ReadInput(string filename)
        {
            StreamReader sr = new StreamReader(filename);
            string line = sr.ReadToEnd();
            sr.Close();

            string[] names = line.Split(',');

            return names;
        }

        private static long Sum(string name)
        {
            name = name.Trim('"');

            long result = 0;

            for (int i = 0; i < name.Length; i++)
            {
                result += Convert.ToInt32(name[i]) - 64;
            }

            return result;
        }
    }
}
