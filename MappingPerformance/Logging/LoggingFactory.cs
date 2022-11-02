using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MappingPerformance.Logging
{
    public class LoggingFactory : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new LoggerService();
        }

        public void Dispose()
        {
            
        }
    }
}
