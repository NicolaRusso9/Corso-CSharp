
namespace CorsoCSharp
{
    // Abstract class can't be instantiate
    public abstract class _28_AbstractClass
    {
        public abstract int Somma(int a, int b);

        public virtual int Moltiply(int a, int b)
        {
            return a * b;
        }
    }

    public class Tester : _28_AbstractClass
    {
        public override int Somma(int a, int b)
        {
            return a + b;
        }
    }
}
