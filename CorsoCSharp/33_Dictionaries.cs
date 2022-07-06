
namespace CorsoCSharp
{
    internal class _33_Dictionaries
    {
        public void Starter()
        {
            Dictionary<string, string> dic = new();

            dic.Add(key: "int", value: "32-bit integer data type");


            Dictionary<string, string> dic2 = new() {
                { "int", "32-bit integer data type" },
            };

            Dictionary<string, string> dic3 = new()
            {
                 ["int"] = "32-bit integer data type" ,
            };

            foreach( KeyValuePair<string, string> pair in dic)
            {
                Console.WriteLine("Key is {0} and its value is {1}", pair.Key, pair.Value);
            }
        }
    }
}
