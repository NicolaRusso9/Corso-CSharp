

using System.Text;

namespace CorsoCSharp
{
    internal class _46_Encoding
    {
        public void Starter()
        {
            Console.WriteLine("[1] ASCII");
            Console.WriteLine("[2] UTF-7");
            Console.WriteLine("[3] UTF-8");
            Console.WriteLine("[4] UTF-16 (Unicode)");
            Console.WriteLine("[5] UTF-32");
            Console.WriteLine("[All other key] Default");

            ConsoleKey number = Console.ReadKey(intercept: false).Key;
            Console.WriteLine();

            Encoding encoder = number switch
            {
                ConsoleKey.D1 => Encoding.ASCII,
                ConsoleKey.D2 => Encoding.UTF7,
                ConsoleKey.D3 => Encoding.UTF8,
                ConsoleKey.D4 => Encoding.Unicode,
                ConsoleKey.D5 => Encoding.UTF32,
                _ => Encoding.Default,
            };

            string message = "Cafè cost: £4.39";
            byte[] encoded= encoder.GetBytes(message);      // encode string into byte[]

            Console.WriteLine("{0} uses {1:N0} bytes",
                encoder.GetType().Name,
                encoded.Length);

            Console.WriteLine("BYTE HEX CHAR");
            foreach (byte b in encoded)
            {
                Console.WriteLine($"{b,4} {b.ToString("X"),4} {(char)b,5}");
            }

            string decoded= encoder.GetString(encoded);     // decode string
            Console.WriteLine(decoded);
        }
    }
}
