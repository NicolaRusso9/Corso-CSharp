using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoCSharp
{
    internal class _20_OverrideOperator
    {
        public void MoltiplicationOfPerson()
        {
            ClassLibrary.Person p1 = new() { FirstName = "George", Name = "Micael" };
            ClassLibrary.Person p2 = new() { FirstName = "Spears", Name = "Barbara" };

            ClassLibrary.Person p3 = p1 * p2;       // operator override must be in class definition
        }
    }
}
