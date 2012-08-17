using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace ProjectEuler.Problem76
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int target = 100;
            int[] result = new int[target + 1];
            result[0] = 1;

            for (int i = 1; i <= 99; i++)
            {
                for (int j = i; j <= target; j++)
                {
                    result[j] += result[j - i];
                }
            }

            stopwatch.Stop();

            Console.WriteLine(
                "Target Value: " + target + Environment.NewLine + 
                "Result: " + result[result.Length - 1] + Environment.NewLine +
                "Elapsed Time: " + stopwatch.ElapsedMilliseconds + "ms");

            Console.WriteLine("Press ENTER to quit");
            Console.ReadLine();
        }
    }
}
