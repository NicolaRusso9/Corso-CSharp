using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoCSharp
{
    class _10_FunctionalProgramming
    {
        public int FibonacciFunctional(int term) =>
            term switch
            {
                1 => 0,
                2 => 1,
                _ => FibonacciFunctional(term - 1) + FibonacciFunctional(term - 2)
            };

        public int FibonacciImperative(int term)
        {
            if (term == 1)
            {
                return 0;
            }
            if (term == 2)
            {
                return 1;
            }
            else
            {
                return FibonacciImperative(term - 1) + FibonacciImperative(term - 2);
            }
        }

        public void callFibonacci()
        {

            for (int i = 0; i <= 30; i++)
            {
                Console.WriteLine($"The {0} term of the Fibonacci sequence is {1:N0}.",
                    arg0: i,
                    arg1: FibonacciImperative(term: i));
            }

            for (int i = 0; i <= 30; i++)
            {
                Console.WriteLine($"The {0} term of the Fibonacci sequence is {1:N0}.",
                    arg0: i,
                    arg1: FibonacciFunctional(term: i));
            }
        }
    }
}
