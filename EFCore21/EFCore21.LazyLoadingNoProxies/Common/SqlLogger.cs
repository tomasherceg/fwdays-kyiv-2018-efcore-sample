using System;
using Microsoft.Extensions.Logging;

namespace EFCore21.LazyLoadingNoProxies.Common
{
    public class SqlLogger : ILogger
    {
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (eventId.Name == "Microsoft.EntityFrameworkCore.Database.Command.CommandExecuting")
            {
                var message = state.ToString();
                message = message.Substring(message.IndexOf("\n") + 1);

                Console.WriteLine(message);
                Console.WriteLine();
            }
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
    }
}