using System;
using System.Diagnostics;
using System.IO;
using ProjectEuler;

namespace ProjectEuler.Problem102
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            string[] lines = File.ReadAllLines(@"..\..\triangles.txt");
            int result = 0;

            foreach (string line in lines)
            {
                string[] segments = line.Split(',');

                int[] a = {Convert.ToInt32(segments[0]),
                           Convert.ToInt32(segments[1])};

                int[] b = {Convert.ToInt32(segments[2]),
                           Convert.ToInt32(segments[3])};

                int[] c = {Convert.ToInt32(segments[4]),
                           Convert.ToInt32(segments[5])};

                int[] p = { 0, 0 };

                if (Area(a, b, c) ==
                    Area(a, b, p) +
                    Area(a, p, c) +
                    Area(p, b, c))
                {
                    // If the area of the triangle abc is equal to
                    // the area of the triangles abc + apc + pbc then
                    // the triangle contains point p.
                    result++;
                }
            }

            stopwatch.Stop();

            Console.WriteLine(
                "Result: " + result + Environment.NewLine +
                "Elapsed Time: " + stopwatch.ElapsedMilliseconds + "ms");

            Console.WriteLine("Press ENTER to quit");
            Console.ReadLine();
        }

        /// <summary>
        /// Find the area of a triangle using its coordinates.
        /// </summary>
        /// <param name="a">Coordinates for line segment a.</param>
        /// <param name="b">Coordinates for line segment b.</param>
        /// <param name="c">Coordinates for line segment c.</param>
        /// <returns>The area of the triangle with the specified coordinates.</returns>
        private static double Area(int[] a, int[] b, int[] c)
        {
            return Math.Abs(0.5*((a[0] - c[0]) * (b[1] - a[1]) - (a[0] - b[0]) * (c[1] - a[1])));
        }
    }
}
