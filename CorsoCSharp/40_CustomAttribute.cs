
namespace CorsoCSharp
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class _40_CustomAttribute : Attribute
    {
        public string Coder { get; set; }
        public DateTime LastModified { get; set; }

        public _40_CustomAttribute(string coder, string lastModified)
        {
            Coder = coder;
            LastModified = DateTime.Parse(lastModified);
        }
    }





    public class ExampleOfUse
    {
        [_40_CustomAttribute("Nicola Russo", "20 June 2022")]
        public void Nothing()
        {
            return;
        }
    }
}
