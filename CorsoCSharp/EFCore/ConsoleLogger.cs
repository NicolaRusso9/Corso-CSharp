using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorsoCSharp.EFCore
{
    public class ConsoleLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            // we could have different logger implementation for different categoryName values
            return new ConsoleLogger();
        }

        public void Dispose()
        {

        }
    }

    public class ConsoleLogger : ILogger
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Information:
                case LogLevel.Trace:
                case LogLevel.None:
                    return false;
                case LogLevel.Critical:
                case LogLevel.Debug:
                case LogLevel.Warning:
                case LogLevel.Error:
                default:
                    return true;
            }
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            Console.Write($"Level: {logLevel}, Event id: {eventId.Id}");

            if (state != null)
            {
                Console.Write($", State: {state}");
            }

            if (exception != null)
            {
                Console.Write($", Exception: {exception}");
            }

            Console.WriteLine();
        }
    }

}
