
namespace CorsoCSharp
{
    class _35_GenericType<T> where T : IComparable
    {
        public T Data = default(T);

        public string Process(T input)
        {
            if (Data.CompareTo(input) == 0)
            {
                return "is the same";
            }
            else
            {
                return "not the same";
            }
        }

        public void callGeneric()
        {
            var gt1 = new _35_GenericType<int>();
            gt1.Data = 1;
            Console.WriteLine(gt1.Process(42));
        }
    }
}
