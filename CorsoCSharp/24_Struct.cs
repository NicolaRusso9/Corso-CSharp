using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoCSharp
{
    /// <summary>
    /// Una struct è identica alla classe, la differenza sta nella memoria in cui immagazzina le informazioni.
    /// La classe utilizza l'heap, la struct lo stack.
    /// Se i dati da contenere sono inferiori ai 16bytes deve essere utilizzata la struct per ottimizzare le performance.
    /// Se una struttura usa type che non sono di tipo struct questi campi vengono allocati nello heap.
    /// 
    /// Struct Type:
    ///             - Number system type: byte, sbyte, short, ushort, int, uint, long, ulong, float, double, decimal
    ///             - Other systemtype: char, DateTime, bool
    ///             - System.Drawing types: Color, Point, Rectangle
    ///             
    /// La struct non può essere ereditata
    /// </summary>

    struct _24_Struct
    {
        public int x;
        public int y;

        public _24_Struct(int initialX, int initialY)
        {
            x = initialX;
            y = initialY;
        }

        // Ovveride of + operator
        public static _24_Struct operator +(_24_Struct vector1, _24_Struct vector2)
        {
            return new _24_Struct(vector1.x + vector2.x, vector1.y + vector2.y);
        }
    }

    record struct _24_StructRecord(int initialX, int initialY);

    class TestStruct
    {
        public void test()
        {
            var v1 = new _24_Struct(3, 5);
            var v2 = new _24_Struct(2, 7);

            var v3 = v1 + v2;       // avendo effettuato l'overload dell'operatore + verrà restituita correttamente la somma del vettore
        }
    }

}
