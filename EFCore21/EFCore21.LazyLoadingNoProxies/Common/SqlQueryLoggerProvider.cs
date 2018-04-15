using Microsoft.Extensions.Logging;

namespace EFCore21.LazyLoadingNoProxies.Common
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