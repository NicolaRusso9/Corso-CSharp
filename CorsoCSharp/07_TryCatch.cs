using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoCSharp
{
    internal class _07_TryCatch
    {
        public void Starter()
        {
            string? amount = System.Console.ReadLine();

            try
            {
                //code
            }
            catch (Exception ex)
            {

            }


            // try catch with filters
            try
            {
                decimal amountValue = decimal.Parse(amount);
            }
            catch (FormatException) when (amount.Contains("$"))
            {
                Console.WriteLine("il carattere $ non è ammesso");
            }
            catch(FormatException)
            {
                Console.WriteLine("Errore generico del formato");
            }
        }
    }
}
