using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoCSharp
{
    internal class _49_Set_Bag
    {
        // Set is a collection of one or more unique objects
        // A multiset, aka bag, is a collaction of one or more objects that can have duplicates

        public void Starter()
        {
            string[] cohort1 = new[] { "Rachel", "Gareth", "Jonathan", "George" };
            string[] cohort2 = new[] { "Jack", "Stephen", "Daniel", "Jack", "Jared" };
            string[] cohort3 = new[] { "Declan", "Jack", "Jack", "Jasmine", "Conor" };

            Console.WriteLine(cohort2.Distinct());
            Console.WriteLine(cohort2.DistinctBy(name => name.Substring(0,2)));
            Console.WriteLine(cohort2.Union(cohort3));
            Console.WriteLine(cohort2.Concat(cohort3));
            Console.WriteLine(cohort2.Intersect(cohort3));
            Console.WriteLine(cohort2.Except(cohort3));
            Console.WriteLine(cohort1.Zip(cohort2, (c1,c2) => $"{c1} matched with {c2}"));

        }
    }
}
