using System.Collections;

namespace CorsoCSharp
{
    internal class _05_WhileDoFor
    {
        public void Starter()
        {
            int x = 0;

            while(x < 10)
            {
                //
            }


            do
            {
                x++;
            }
            while(x < 10);


            for (int i = 0; i < x; i++)
            {
                //
            }

            string[] foreachTest = new[] { "ciao", "casa" };                // =>             IEnumerator e = foreachTest.GetEnumerator();
            foreach (var text in foreachTest)                               // =>             while(e.MoveNext()){
            {                                                               // =>             string text = (string)e.Current
                Console.WriteLine($"{text} has {text.Length} characters");  // =>             Console.WriteLine($"{text} has {text.Length} characters");
            }

        }
    }
}
