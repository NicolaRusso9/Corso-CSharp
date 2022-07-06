using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoCSharp
{
    /// <summary>
    /// Record key word set and immutable object like init on property.
    /// Nothing on record must be change its value after initialization.
    /// Record, like a class, is reference type. This mean that the memory for the object is allocated on the heap, only memory address is stored on the stack.
    /// </summary>

    /*
    internal record _19_RecordsInit
    {
        public int X { get; init; }
        public int Y { get; init; }

        public _19_RecordsInit(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Decontruct(out int x, out int y)
        {
            y = Y;
            x = X;
        }
    }
    */

    public record _19_RecordsInit(int X, int Y);        // Semplificazione del codice commentato sopra. Con una sola riga vengono definiti membri, costruttore e distruttore


    public class TestRecord
    {

        public void Starter()
        {
            _19_RecordsInit ImmutableObject1 = new( Y: 1, X: 1);                        // calls a constructor method


            _19_RecordsInit ImmutableObject2 = ImmutableObject1 with { X = 5 };         // copy the same value with change

            var (x1, y2) = ImmutableObject1;                                            // calls a destructor method
        }
    }
}
