using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetLog.Core
{
    public static class NetLogFormatter
    {
        public static string FileNameFormatter(string fileName)
        {
            return fileName + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() 
                + DateTime.Now.Day.ToString() + ".log";
        }

        public static string LogMessageFormatter(string formatter, string message)
        {
            return message;
        }

        public static string LogMessageFormatter(string formatter, string message,
            Exception exception)
        {
            return message;
        }

        public static string LogMessageFormatter(string formatter, string methodInfo, string message)
        {
            message = methodInfo + Environment.NewLine + message;
            return message;
        }

        public static string LogMessageFormatter(string formatter, string methodInfo, string message,
            Exception exception)
        {
            return message;
        }
    }
}
