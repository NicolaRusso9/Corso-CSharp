namespace CorsoCSharp
{
    class _06_Casting
    {
        public void Cast() { 
            int n = 5;
            double f = n;   // cast implicito - permesso in quanto non si verificano perdite di informazioni con il cast

            double a = 3.3;
            int b = (int)a; // cast esplicito - necessario in quanto si perderanno le informazioni dopo la virgola
        }

        public void SystemConvert()
        {
            double a = 3.7;
            int n = Convert.ToInt32(a);  // System.Convert effettua la conversione del numero e l'arrotondamento dello stesso
            Console.WriteLine($"Il valore di n ora è: {n}");
        }

        public void TryParseConversion()
        {
            int n;
            string? input = Console.ReadLine();

            if (int.TryParse(input, out n))
            {
                Console.WriteLine($"Il numero intero è: {n}");
            }
        }

        public void ConversioneBinaria()
        {
            byte[] binaryObject = new byte[128];

            (new Random()).NextBytes(binaryObject);     // inserimento di byte randomici nell'array

            // Ciclo for per visualizzare gli esadecimali dell'array di byte
            for (int index = 0; index < binaryObject.Length; index++)
            {
                Console.Write($"{binaryObject[index]:X}");
            }

            // Conversione del byte in stringa
            string encoded = Convert.ToBase64String(binaryObject);
            Console.Write($"Binary Object as Base64: {encoded}");
        }

        public void IsAType()
        {
            ClassLibrary.Person p = new();
            int j = 93;

            if (p is int)       // Verify if p is the same type of int
            {

            }

            double? d = j as double?;       //return null if type cannot be cast
        }
    }
}
