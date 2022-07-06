using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoCSharp
{
    class _08_Overflow
    {
        public void OverflowTryCatch()
        {
            try
            {
                int x = int.MaxValue - 1;
                x++;
                Console.WriteLine($"x value is: {x}");
                x++;
                Console.WriteLine($"x value is: {x}");
                x++;
                Console.WriteLine($"x value is: {x}");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Errore overflow");
            }
        }

        public void OverflowChecked()
        {
            checked
            {
                int x = int.MaxValue - 1;
                x++;
                Console.WriteLine($"x value is: {x}");
                x++;
                Console.WriteLine($"x value is: {x}");
                x++;
                Console.WriteLine($"x value is: {x}");
            }
        }

        public void OverflowUnchecked()
        {
            unchecked {
                int x = int.MaxValue - 1;
                x++;
                Console.WriteLine($"x value is: {x}");
                x++;
                Console.WriteLine($"x value is: {x}");
                x++;
                Console.WriteLine($"x value is: {x}");
            }
        }
    }
}
