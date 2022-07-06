using System.Text.RegularExpressions;

namespace CorsoCSharp
{
    internal class _30_TextRegex
    {
        string _text = "Ciao, questo è un testo di prova";

        // Per concatenare efficientemente le stringhe utilizzare StringBuilder
        public void Starter()
        {
            int lunghezzaStringa = _text.Length;
            char firstChar = _text[0];
            string[] splitting = _text.Split(',');

            string subString= _text.Substring(3);   //parte dalla 4 lettera
            string subStringWithIndex = _text.Substring(0, _text.IndexOf(","));     // da 0 fino alla virgola

            bool contiene = _text.Contains(subStringWithIndex);
            bool start = _text.StartsWith(subStringWithIndex);
            bool end = _text.EndsWith(subStringWithIndex);

            string joined = string.Join("=>", splitting);       // ogni elemento di splitting sarà seguto da "=>"
        }


        /**
         * PAGE 332
         * 
         *  ^           = start of input
         *  $           = end of input
         *  \d          = single digit
         *  \D          = single NON digit
         *  \s          = whitespace
         *  \S          = NON whitespace
         *  \w          = word character
         *  \W          = NON word character
         *  [A-Za-z0-9] = Ranges of characters
         *  [aeiou]     = Set of characaters
         *  [^aeiou]    = NOT in set of characters
         *  \^          = ^ character
         *  .           = Any single character
         *  \.  q       = . character
         *  
         *  +           = one or more
         *  ?           = one or none
         *  {3}         = exactly 3
         *  {3,5}       = Three or five
         *  {3,}        = at least three
         *  {,3}        = Up to three
         *  
         */
        public void PatternMatchingRegex()
        {
            Console.Write("Enter your age:");
            string? age = Console.ReadLine();

            Regex ageChecker = new(@"^\d+$");       // 2154 => ok       3 => ok

            if (ageChecker.IsMatch(age))
            {
                Console.WriteLine("Thanks");
            }
            else
            {
                Console.WriteLine($"This is not a valid age: {age}");
            }
        }
    }
}
