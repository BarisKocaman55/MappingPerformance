using System;
using System.Collections.Generic;
using System.Text;

namespace MappingPerformance.Infrastructure.Logging
{
    public interface ILogginsService<T>
    {
        void Debug(string message);
        void Debug(Exception exception, string message, params object[] args);
        void Error(string message);
        void Error(Exception exception, string message, params object[] args);
        void Fatal(string message);
        void Fatal(Exception exception, string message, params object[] args);
        void Trace(string message);
        void Trace(Exception exception, string message, params object[] args);
        void Info(string message);
        void Info(Exception exception, string message, params object[] args);
    }
}
