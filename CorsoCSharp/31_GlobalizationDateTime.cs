using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoCSharp
{
    internal class GlobalizationDateTime
    {
        public void Starter() {
            Console.WriteLine("Current culture is {0]",
                arg0: CultureInfo.CurrentCulture.Name);

            string textDate = "4 July 2021";
            DateTime independenceDay = DateTime.Parse(textDate);        // can cause error on parsing depending on current culture

            independenceDay = DateTime.Parse(textDate,                  // traduce la data da un formato en-US
                provider: CultureInfo.GetCultureInfo("en-US"));


            DateOnly queensBirthday = new(year: 2022, month: 4, day:18); // Better solution for date and for SQL date
            TimeOnly partyStart = new(hour: 10, minute: 22, second: 30); // Better solution for time and for SQL time

            DateTime queenParty = queensBirthday.ToDateTime(partyStart); // Creation of date time from DateOnly and TimeOnly
        }

    }
}
