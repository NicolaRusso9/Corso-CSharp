using System.Text.RegularExpressions;

namespace CorsoCSharp
{
    static class _29_ExtensionMethod
    {
        /// <summary>
        /// Questo metodo, prende in input la stessa variabile che lo richiama, in questo caso email.
        /// Viene definito ExtensionMethod in quanto sta estendendo le proprietà di una stringa.
        /// Essendo string di tipo "sealed" si può estendere la sua funzionalità solo in questo modo.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsValidEmail (this string input)
        {
            return Regex.IsMatch(input,
                @"[a-zA-Z0-9\.-_]+@[a-zA-Z0-9\.-_]+"
                );
        }

        public static void callIsValidEmail()
        {
            string email = "ncl.russo12@gmail.com";
            Console.WriteLine($"{0} la mail è valida: {1}",
                arg0: email,
                arg1: email.IsValidEmail());
        }
    }

    public class TestExtensionMethod
    {
        public void Starter()
        {
            string x ="test@boh";
            bool result = x.IsValidEmail();
        }
    }
}
