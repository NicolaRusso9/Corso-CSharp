using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoCSharp
{
    internal class _32_List
    {
        void WorkingWithList()
        {
            List<string> cities = new();
            cities.Add("Roma");

            List<string> cities2 = new() { "Roma" };    // Converted by compilator in add statement
            
            List<string> cities3 = new();
            cities3.AddRange(new[] { "Roma" });         // Converted by compilator in add statement from array

            cities.Insert(0, "Milano");                 // Add element on specific index
            cities.RemoveAt(1);                         // Remove specific index
            cities.Remove("Milano");                    // Remove from value

            int numberoOfElements = cities.Count;       // Number of element

            ImmutableList<string> listaImmutabile = cities.ToImmutableList();       // can't change, add or delete

        }
    }
}
