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
            return fileName + DateTime.Now.ToString("yyyyMMdd") + ".log";
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
            string time = "DateTime:" + DateTime.Now.ToString();
            message = time + Environment.NewLine + methodInfo + Environment.NewLine + "LogContent:" + message;
            return message;
        }

        public static string LogMessageFormatter(string formatter, string methodInfo, string message,
            Exception exception)
        {
            string time = "DateTime:" + DateTime.Now.ToString();
            string errMsg = "ExceptionMessage:" + exception.Message;
            message = time + Environment.NewLine + methodInfo + Environment.NewLine + "LogContent:" + message
                + Environment.NewLine + errMsg;
            return message;
        }
    }
}
