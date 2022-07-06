using System.Diagnostics;

namespace CorsoCSharp
{
    internal class _51_LinqMultiThread
    {
        // LINQ multithread or PLINQ
        // not all time multi thread means that you are improving the applications's performance

        public _51_LinqMultiThread()
        {
            var watch = new Stopwatch();
            Console.Write("Press Enter to start: ");
            Console.ReadLine();

            int max = 45;

            watch.Start();

            IEnumerable<int> numbers = Enumerable.Range(1, max);

            Console.WriteLine($"Calculating Fibonacci sequence up to {max}. Please wait...");

            int[] fibonacciNumbers = numbers
                .Select(number => Fibonacci(number))
                .ToArray();

            watch.Stop();
            Console.WriteLine("{0:#,##0} elapsed milliseconds.",
                arg0: watch.ElapsedMilliseconds);

            Console.Write("Results: ");
            foreach (int number in fibonacciNumbers)
            {
                Console.Write($" {number}");
            }


            Console.WriteLine();
            Console.WriteLine();

            // pararelizzazione dell'operazione
            watch.Reset();
            watch.Start();
            int[] fibonacciNumbers2 = numbers
                .AsParallel()
                .Select(number => Fibonacci(number))
                .OrderBy(number => number)              // richiesto l'ordinamento in quanto potrebbero ritornare risultati prima di altri e quindi non sarebbero ordinati secondo la serie di fibonacci
                .ToArray();
            watch.Stop();

            Console.WriteLine("{0:#,##0} elapsed milliseconds.",
                arg0: watch.ElapsedMilliseconds);

            Console.Write("Results: ");
            foreach (int number in fibonacciNumbers2)
            {
                Console.Write($" {number}");
            }

            // Local function
            static int Fibonacci(int term) =>
                term switch
                {
                    1 => 0,
                    2 => 1,
                    _ => Fibonacci(term - 1) + Fibonacci(term - 2),
                };



            //// Su più thread - in questo caso risulta più dispendioso
            //watch.Start();

            //var squares2 = numbers.AsParallel()
            //    .Select(numbers => numbers * numbers).ToArray();

            //watch.Stop();
            //Console.WriteLine("{0:#,##0} elapsed milliseconds.",
            //    arg0: watch.ElapsedMilliseconds);
        }
    }
}
