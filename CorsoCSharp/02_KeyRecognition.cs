using static System.Console;

namespace CorsoCSharp
{
    class _02_KeyRecognition
    {
        public void starter()
        {
            Write("Press any key to continue");
            ConsoleKeyInfo key = ReadKey();
            WriteLine();
            WriteLine("Key: {0}, Char: {1}, Modifiers: {2}",
                arg0: key.Key,
                arg1: key.KeyChar,
                arg2: key.Modifiers);
        }
    }
}
