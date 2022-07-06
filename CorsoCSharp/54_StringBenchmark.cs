using BenchmarkDotNet.Attributes;

namespace CorsoCSharp
{
    public class _54_StringBenchmark
    {
        int[] numbers;
        
        public _54_StringBenchmark()
        {
            numbers = Enumerable.Range(1, 20).ToArray();
        }

        [Benchmark(Baseline = true)]
        public string StringConcatenationTest()
        {
            string s = String.Empty;
            for (int i = 0; i < numbers.Length; i++) {
                s += numbers[i] + ", ";
            }
            return s;
        }

        [Benchmark]
        public string StringBuilderTest()
        {
            System.Text.StringBuilder sb = new();
            for (int i = 0; i < numbers.Length; i++)
            {
                sb.Append(numbers[i]);
                sb.Append(", ");
            }
            return sb.ToString();
        }
    }
}
