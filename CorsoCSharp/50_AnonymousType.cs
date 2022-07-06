using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoCSharp
{
    internal class _50_AnonymousType
    {

        public void Starter()
        {
            List<Type> nomi = new()
            {
                new(0, "Nicola"),
                new(1, "Laura"),
                new(2, "Anita")
            };

            // New anonymous type with LINQ
            var nome = nomi.Where(s => s.MioNome!.StartsWith("N"))
                .Select(n => new        // new {} create new anonymous type. In this case new type is an object with one string field that is stored in nome
                {
                    n.MioNome
                });



            
        }
    }

    public class Type
    {
        public string? MioNome { get; set; } = null;
        public int? MioIndice { get; set; }

        public Type( int indice, string nome)
        {
            MioNome = nome;
            MioIndice = indice;
        }
    }
}
