using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoCSharp
{
    internal class _21_LocalFunction
    {
        public void NormalFunction()
        {
            int a = 3;
            int b = 4;

            int c = LocalFunction(a, b);

            //Local function have visibility only on method where is declared. It can be declared in all parts of method (before, middle, at the end)
            int LocalFunction(int a, int b)
            {
                return a + b;
            }
        }
    }
}
