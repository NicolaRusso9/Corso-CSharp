#nullable enable       // disable to disable  - enabled to defaultwith .NET 6 on .csproj

using System.Runtime.Versioning;

namespace CorsoCSharp
{

    internal class _99_PreprocessorDirectives
    {
        int? a; // nullable int
        string? text;

        public void Starter()
        {
            int? b = a ?? 7;         // if a is null set default value = 7
            

            if ( a is null)
            {
                // a is null
            }

            if(a is not null)
            {
                b = a;
            }

            b = text?.Length;
        }

        //public void Test2(Person a!!, Person Employee!!)     //--> syntax available from c# 11
        //{

        //}


        public void Test(Person a, Person Employee)
        {
            // this part of code is replaced by !! in c# 11
            if (a is null)
            {
                throw new ArgumentNullException(nameof(a));
            }
            if (Employee is null)
            {
                throw new ArgumentNullException(nameof(Employee));
            }
        }
    }
}
