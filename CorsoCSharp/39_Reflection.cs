using System.Reflection;

namespace CorsoCSharp
{
    internal class _39_Reflection
    {
        public void Starter()
        {
            Assembly? assembly = Assembly.GetEntryAssembly();
            if (assembly == null) return;

            foreach(AssemblyName name in assembly.GetReferencedAssemblies())
            {
                Assembly a = Assembly.Load(name);
                int methodCount = 0;
                foreach(TypeInfo typeInfo in a.DefinedTypes)
                {
                    methodCount+= typeInfo.GetMethods().Count();
                }

                Console.WriteLine("{0:N0} types with {1:N0} methods in {2} assembly",
                    arg0: a.DefinedTypes.Count(),
                    arg1: methodCount, arg2: name.Name);
            }


            AssemblyInformationalVersionAttribute? version =  assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            Console.WriteLine($"Version: {version?.InformationalVersion}");

            AssemblyCompanyAttribute? company = assembly.GetCustomAttribute<AssemblyCompanyAttribute>();
            Console.WriteLine($"Company: {company?.Company}");

        }
    }
}
