namespace CorsoCSharp
{
    class _04_Switch
    {
        Stream? s = File.Open(
            Path.Combine(@"C:\", "file.txt"),
            FileMode.OpenOrCreate,
            FileAccess.Read
        );

        public void switchStandard()
        {
            int o = 0;
            switch (o)
            {
                case 0:
                    Console.WriteLine("ok");
                    break;
                case 1:
                case 2:
                    goto case 0;
                default:
                    break;
            }
        }

        // Pattern Matching Switch
        public void PatternMatching()
        {
            string? message;

            switch (s)
            {
                case FileStream writebleFile when s.CanWrite:
                    message = "The stream is a file that i can write to.";
                    break;
                case FileStream readOnlyFile:
                    message = "The stream isread-only.";
                    break;
                case MemoryStream ms:
                    message = "The stream is memory address";
                    break;
                default:
                    message = "The stream is some other type";
                    break;
                case null:
                    message = "The stream is null.";
                    break;
            }
        }

        // Lambda expression with switch
        public void SwitchExpression()
        {
            string message = s switch
            {
                FileStream writeableFile when s.CanWrite => "The stream is a file that i can write to.",
                FileStream readOnlyFile => "The stream is a readonly file.",
                MemoryStream ms when s.CanWrite => "The stream is a memory address.",
                null => "The stream is null",
                _ => "The stram is some other type."            //  default case
            };


            int number = 145;
            int lastDigit = number % 10;
            string suffix = lastDigit switch
            {
                1 => "st",
                2 => "nd",
                3 => "rd",
                _ => "th",
            };
        }
    }
}
