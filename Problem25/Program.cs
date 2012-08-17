using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace ProjectEuler.Problem25
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int digits = 1000;
            bool isBruteForce = false;

            if (isBruteForce)
            {
                // Brute force
                FibonacciSequence sequence = new FibonacciSequence();
                int term = 0;
                string result = string.Empty;

                using (IEnumerator<BigInteger> e = sequence.GetEnumerator())
                {
                    while (e.MoveNext() && e.Current.ToString().Length < digits)
                    {
                        term++;
                    }

                    result = e.Current.ToString();
                }

                stopwatch.Stop();

                Console.WriteLine(
                    "Result: " + Environment.NewLine + result + Environment.NewLine +
                    "Term: " + term + Environment.NewLine +
                    "Elapsed Time: " + stopwatch.ElapsedMilliseconds + "ms");
            }
            else
            {
                // Math
                int term = (int)Math.Ceiling((digits + Math.Log10(5) / 2 - 1) / Math.Log10(((1 + Math.Sqrt(5)) / 2)));

                stopwatch.Stop();

                Console.WriteLine(
                    "Term: " + term + Environment.NewLine +
                    "Elapsed Time: " + stopwatch.ElapsedMilliseconds + "ms");
            }

            Console.WriteLine("Press ENTER to quit");
            Console.ReadLine();
        }

        /// <summary>
        /// Provides a mechanism for calculating large Fibonacci numbers.
        /// </summary>
        public class FibonacciSequence : IEnumerable<BigInteger>
        {
            /// <summary>
            /// Gets the next BigInteger value in the Fibonacci sequence.
            /// </summary>
            /// <returns>The BigInteger Fibonacci value.</returns>
            public IEnumerator<BigInteger> GetEnumerator()
            {
                BigInteger a = new BigInteger(0);
                BigInteger b = new BigInteger(1);

                while (true)
                {
                    yield return a;

                    BigInteger c = a + b;
                    a = b;
                    b = c;
                }
            }

            /// <summary>
            /// Returns an enumerator that iterates through a collection.
            /// </summary>
            /// <returns>Enumerator that supports a simple iteration over a collection.</returns>
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

    }
}
