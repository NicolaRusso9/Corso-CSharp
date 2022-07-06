using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CorsoCSharp
{

    internal class _31_LibrerieNative
    {
        // Importa la libreria nativa, si possono utilizzare librerie scritte in C
        [DllImport("user32", CharSet = CharSet.Auto)]
        static extern int MessageBox(IntPtr hWnd, String text, String caption, int options);

        public _31_LibrerieNative()
        {
            MessageBox(IntPtr.Zero, "Hello World", "Hello World", 0);
        }
    }
}
