using Microsoft.Extensions.Logging;

namespace EFCore21.GroupByTranslation.EF20.Common
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