using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoCSharp
{
    /// <summary>
    /// Simili ai puntatori di C. I delegati contengono l'indirizzo di memoria del metodo che ha la stessa firma del delegato stesso.
    /// </summary>
    internal class _22_Delegate
    {
        delegate int DelegateWithMatchingSignature(string s);

        public void MyMethod()
        {
            string j = "ciao";

            // Instanza del delegato che punta al metodo
            DelegateWithMatchingSignature instanceDelegate = new(new Test().MethodThatIWantCall);

            // richiamo il delegato che chiama il metodo
            int value = instanceDelegate(j);

        }
    }

    internal class Test
    {
        public int MethodThatIWantCall(string s)
        {
            return s.Length;
        }
    }

    public class MicrosoftDefaultDelegateForEvent
    {
        public delegate void EventHandler(object? sender, EventArgs s);

        public delegate void EventHandler<TeventArgs>(object? sender, TeventArgs args);
    }




    // EventHandler
    internal class CallDelegateOfPerson
    {
        public void Starter()
        {
            ClassLibrary.Person harry = new();
            harry.Shout += ClassLibrary.Person.Harry_Shout;
            harry.Poke();
        }
    }

}
