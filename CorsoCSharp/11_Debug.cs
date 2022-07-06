using System.Diagnostics;

namespace CorsoCSharp
{
    class _11_Debug
    {
        public static void Test()
        {
            Trace.WriteLine("i'm watching");    // show message in debug output
            Debug.WriteLine("i'm watching");    // i messaggi di debug vengono mostrati solo in debug, i trace anche in release


            // Crea un file nella directory del progetto
            Trace.Listeners.Add(
                new TextWriterTraceListener(
                    File.CreateText(
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "log.txt")
            )));
            Trace.AutoFlush = true;
            Trace.WriteLine("i'm watching");    // write text in output listener

        }
    }
}
