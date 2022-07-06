using System.Numerics;
using System.Xml;

namespace CorsoCSharp
{
    internal class _01_Variable
    {
        static int variabile;       // il valore di questa variabile sarà condivisa con tutte le istanze. Modificando il valore in una istanza si modifica in tutte le altre
        const int variabile2 = 2;   // questa variabile non può cambiare valore in quanto in fase di compilazione viene sostituita in tutto il codice con il suo valore
        readonly int variabile3;    // miglior modo per definire una variabile const in quanto il suo valore può essere settato dal costruttore o con un assegnamento durante l'inizilizzazione della classe. Una volta assegnato non può cambiare

        public void starter()
        {
            char letter = 'a';                          // char variable

            string stringa = "hello";
            string verbatim = @"C:\television\test";
            string interpolatedString = $"{stringa}";
            string nullable = default(string);

            uint naturalNumber = 23;    //  unsigned int means positive whole number or 0
            int integerNumber = -23;    // negative and positive whole number or 0
            int digitSeparator = 2_000_000;
            int binaryNotation = 0b_0001_1110_1000_0100_1000_0000;      // =>  2.000.000
            int hexNotation = 0x_001E_8480;                             // =>  2.000.000
            nint nintType = 9;                                          // Da c# 9 => uguale a int ma con dimensioni specifiche dalla piattaforma. Su os 32 bit vale 4 byte, su os 64bit vale 8 byte. Puntatore memoria a int
            nuint nuintType = 10;                                       // Da c# 9 => uguale a uint ma con dimensioni specifiche dalla piattaforma. Su os 32 bit vale 4 byte, su os 64bit vale 8 byte. Puntatore memoria a uint
            IntPtr nintTypeName;                                        // uguale a nint
            UIntPtr nuintTypeName;                                      // uguale a nuint
            BigInteger bigger = BigInteger.Parse("123456789012345678901234567890"); // Massimo di 40 cifre

            Complex complexNumber = new(real: 4, imaginary: 3);         // Numero complesso
            Complex complexNumber2 = new(real: 4, imaginary: 3);         // complexNumber + complexNumber2 = 8+6i 

            double doubleNumber = 2.3;                                  // double means double precision point
            double binaryDecimalNotation = 0000_1100.1100;              // =>  12.75          
            double infinitePositive = double.PositiveInfinity;          // +infinito

            float floatNumber = 2.3F;                                   // single precision floating point - F suffix makes it a float literal

            var if_nullable = nullable?.Length ?? 0;                    // if nullable is null 0 is default value

            bool happy = true;
            bool sad = false;

            object generic = 'a';
            dynamic intero = 1;                                         // unlike object it has all function and member of its object type without an explicit cast, but performace is too bad

            XmlDocument doc = new();                                    // target typed new to instantiate objects

            string? test = default;                                     // default value to string
            string[] array = new[] { "ciao" };

            // Watch 14_
            //var tupla = (stringa: "ciao", intero: 4, listadiprova: new List<int>());    // definizione di una tupla, una tupla può contenere diversi tipi di dato
            //tupla.listadiprova = null;

            Console.WriteLine($"{digitSeparator == hexNotation && digitSeparator == binaryNotation}");
            Console.WriteLine($"Int utilizza {sizeof(int)} bytes e il suo numero massimo può essere {int.MaxValue:N0} mentre il numero minimo {int.MinValue:N0}");      // con N0 si inserisce il punto tra le cifre

            decimal cost = 1.50M * 3;
            Console.WriteLine($"Formatted string example: {12} apple costs {cost,10:C}");      // Format string: {index [, alignment]  [: formatString]}   --> :C  =  currency      ,10 = number of char


            // --- COMPARISON FROM FLOATIN NUBER

            double value1 = 0.2;
            double value2 = 0.1;

            if ( value1 + value2 == 0.3)                                // false because the local seprator is "," and so compiler evalate literal value and not numeric value. Use double only when is not needed to compare number 
            {
                Console.WriteLine($"{value1} + {value2} = {0.3}");
            }
            else
            {
                Console.WriteLine($"{value1} + {value2} != {0.3}");
            }

            decimal decimalNumber = 0.2M;                               // M suffix means a decimal literal value
            decimal decimalNumber2 = 0.1M;

            if (decimalNumber + decimalNumber2 == 0.3M)                        
            {
                Console.WriteLine($"{decimalNumber} + {decimalNumber2} = {0.3}");
            }
            else
            {
                Console.WriteLine($"{decimalNumber} + {decimalNumber2} != {0.3}");
            }
        }
    }
}
