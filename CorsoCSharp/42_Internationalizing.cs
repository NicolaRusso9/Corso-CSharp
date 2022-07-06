using System.Globalization;

namespace CorsoCSharp
{
    class _42_Internationalizing
    {
        public _42_Internationalizing()
        {
            CultureInfo globalization = CultureInfo.CurrentCulture;             // about writing code to accommodate multiple languages and region combinations (ex. datetime format)
            CultureInfo localization = CultureInfo.CurrentUICulture;            // about customizing the user interface to support a language (ex. change label of a button)

            Console.WriteLine($"The current globalization is {0} : {1}", globalization.Name, globalization.DisplayName);
            Console.WriteLine($"The current localization is {0} : {1}", localization.Name, localization.DisplayName);

            Console.WriteLine("en-US: English (United States)");
            Console.WriteLine("da-DK: English (Denmark)");
            Console.WriteLine("fr-CA: French (Canada)");
            Console.WriteLine("Enter an ISO culture code: ");

            string culture = Console.ReadLine();

            if (!string.IsNullOrEmpty(culture))
            {
                var ci = new CultureInfo(culture);
                CultureInfo.CurrentCulture = ci;
                CultureInfo.CurrentUICulture = ci;
            }

            Console.WriteLine();

            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your date of birth: ");
            string dob = Console.ReadLine();

            Console.Write("Enter your salary: ");
            string salary = Console.ReadLine();

            DateTime date = DateTime.Parse(dob);
            int minutes = (int)DateTime.Today.Subtract(date).TotalMinutes;
            decimal earns = decimal.Parse(salary);

            Console.WriteLine($"{0} was born on a {1:dddd}, is {2:N0} minutes old, and earns {3:C}", name, date, minutes, earns);

        }
    }
}
