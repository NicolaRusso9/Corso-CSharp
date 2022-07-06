namespace CorsoCSharp
{
    class _03_IfElse
    {
        // Info: good practice to insert all times brakets "{}" in if and else statement to avoid serius bugs like #gotofail on iOS 

        public void starter()
        {
            decimal decimalNumber = 0.3M;                   // decimal risulta più accurato sulla comparazione dei numeri decimali
            decimal decimalNumber2 = 0.1M;                  // decimal risulta più accurato sulla comparazione dei numeri decimali
            double doubleNumber = 0.3;                      // double is double precision
            double doubleNumber2 = 0.1;                     // double is double precision

            if (doubleNumber + doubleNumber2 == 0.4)
            {
                Console.WriteLine($"Utilizzando i double {doubleNumber} + {doubleNumber2} risulta uguale a {doubleNumber + doubleNumber2}");
            }
            else if (decimalNumber + decimalNumber2 == 0.4M)     // nota che il 0.6 presenta la M
            {
                Console.WriteLine($"Utilizzando i decimal {decimalNumber} + {decimalNumber2} risulta uguale a {decimalNumber + decimalNumber2}");
            }

            object o = 2;
            int j = 4;

            if (o is int i)    // se o è un intero assegna il valore nella variabile, dichiarata localmente, i
            {
                Console.WriteLine($"{i} * {j} = {i * j}");
            }
            else
            {
                // ...
            }
        }
    }
}
