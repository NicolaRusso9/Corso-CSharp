using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoCSharp
{
    /// <summary>
    /// Creazione del complex type per un return multiplo.
    /// </summary>
    class IntAndString
    {
        public int? numero;
        public string? stringa;
    }

    class _14_ReturnMultipeValue_Tuple
    {
        public IntAndString RitornaDueValori()
        {
            return new IntAndString
            {
                numero = 0,
                stringa = "ciao"
            };
        }

        /// <summary>
        /// Funzione con valori di ritorno TUPLA.
        /// </summary>
        /// <returns></returns>
        public (int, string) DueValoriTUPLA()
        {
            return (0, "ciao");
        }

        /// <summary>
        /// Funzione con valori di ritorno TUPLA e viene assegnato un nome ai valori.
        /// </summary>
        /// <returns></returns>
        public (int intero, string stringa) DueValoriTUPLANaming()
        {
            return (intero: 0, stringa: "ciao");
        }


        public void richiamo()
        {
            var x = RitornaDueValori();
            Console.WriteLine($"Il mio numero è {0} e la mia stringa è {1}",
                arg0: x.numero,
                arg1: x.stringa
            );

            var y = DueValoriTUPLA();
            Console.WriteLine($"Il mio numero è {0} e la mia stringa è {1}",
                arg0: y.Item1,
                arg1: y.Item2
            );

            var z = DueValoriTUPLANaming();
            Console.WriteLine($"Il mio numero è {0} e la mia stringa è {1}",
                arg0: z.intero,
                arg1: z.stringa
            );


            // Decostruzione della tupla, vengono assegnati i valori alle nuove variabili
            var (numero, stringa) = z;
            Console.WriteLine($"Il mio numero è {numero} e la mia stringa è {stringa}");
        }
    }
}
