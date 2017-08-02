using NetLog.ConfigModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetLog.Core
{
    internal class NetLogRepository
    {
        private LogCategory _logCategory;
        private string _methodInfo;
        private LogListener _logListener;
        private string _filePath;
        private string _fileName;

        public string MethodInfo
        {
            set { _methodInfo = value; }
        }

        public NetLogRepository(LogCategory logCategory, string methodInfo)
        {
            _logCategory = logCategory;
            _methodInfo = methodInfo;
            _logListener = logCategory.LogListeners.FirstOrDefault();
            _filePath = AppDomain.CurrentDomain.BaseDirectory + "\\" + _logListener.FilePath;
            _fileName = NetLogFormatter.FileNameFormatter(_logListener.FileName);
        }

        public void SaveLog(string message)
        {
            if (_logListener.DestinationType == DestinationType.File)
            {
                LogToFile(message);
            }
            else if (_logListener.DestinationType == DestinationType.DB)
            {
                LogToDB(message);
            }
        }

        public void SaveLog(string message, Exception exception)
        {
            if (_logListener.DestinationType == DestinationType.File)
            {
                LogToFile(message, exception);
            }
            else if (_logListener.DestinationType == DestinationType.DB)
            {
                LogToDB(message, exception);
            }
        }

        private void LogToFile(string message)
        {
            if (message == null || message == String.Empty) return;

            string layOutHeader = _logListener.LayoutHeader;
            string layOutFooter = _logListener.LayoutFooter;
            message = NetLogFormatter.LogMessageFormatter(_logListener.LayoutContent, _methodInfo, message);
            message = layOutHeader + Environment.NewLine + message + Environment.NewLine + layOutFooter;
            WriteFile(_filePath, _fileName, _logListener.AppendToFile, message);
        }

        private void LogToFile(string message, Exception exception)
        {
            if (message == null || message == String.Empty) return;

            string layOutHeader = _logListener.LayoutHeader;
            string layOutFooter = _logListener.LayoutFooter;
            message = NetLogFormatter.LogMessageFormatter(_logListener.LayoutContent, _methodInfo,
                    message, exception);
            message = layOutHeader + Environment.NewLine + message + Environment.NewLine + layOutFooter;
            WriteFile(_filePath, _fileName, _logListener.AppendToFile, message);
        }

        private void LogToDB(string message)
        {
            if (message == null || message == String.Empty) return;

            string insertSql = _logListener.InsertSql;
            string layOutHeader = _logListener.LayoutHeader;
            string layOutFooter = _logListener.LayoutFooter;
            message = NetLogFormatter.LogMessageFormatter(_logListener.LayoutContent, _methodInfo, message);
            message = layOutHeader + Environment.NewLine + message + Environment.NewLine + layOutFooter;
            DBRepository dbRep = new DBRepository();
            dbRep.WriteLogToDB(insertSql, _logCategory.MiniLevel.ToString(), _methodInfo, message);
        }

        private void LogToDB(string message, Exception exception)
        {
            if (message == null || message == String.Empty) return;

            string insertSql = _logListener.InsertSql;
            message = NetLogFormatter.LogMessageFormatter(_logListener.LayoutContent, message);
            DBRepository dbRep = new DBRepository();
            dbRep.WriteLogToDB(insertSql, _logCategory.MiniLevel.ToString(), _methodInfo, message);
        }

        private void WriteFile(string filePath, string fileName, bool appendToFile, string message)
        {
            if (message == null || message == String.Empty) return;
            if (!Directory.Exists(filePath)) //目录不存在时创建
            {
                try
                {
                    Directory.CreateDirectory(filePath);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            try
            {
                FileStream file = null;
                string filePathAndName = filePath + "\\" + fileName;
                if (!File.Exists(filePathAndName))
                {
                    file = new FileStream(filePathAndName, FileMode.Create);
                }
                else
                {
                    if (appendToFile)
                    {
                        file = new FileStream(filePathAndName, FileMode.Append);
                    }
                    else
                    {
                        File.Delete(filePathAndName);
                        file = new FileStream(filePathAndName, FileMode.Create);
                    }
                }
                StreamWriter w = new StreamWriter(file);
                w.WriteLine(message);
                w.Flush();
                w.Close();
                w.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
