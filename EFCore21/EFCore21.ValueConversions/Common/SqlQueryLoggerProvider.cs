using Microsoft.Extensions.Logging;

namespace EFCore21.ValueConversions.Common
{
    public class SqlQueryLoggerProvider : ILoggerProvider
    {
        public void Dispose()
        {
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new SqlLogger();
        }
    }
}