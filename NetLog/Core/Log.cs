using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetLog.ConfigModel;
using System.Diagnostics;
using System.Reflection;

namespace NetLog.Core
{
    public class Log : ILog, ILogConfig
    {
        private LogCategory _logCategory;
        private Dictionary<string, NetLogRepository> _netLogRepDic = new Dictionary<string, NetLogRepository>();

        public LogCategory LogCategory
        {
            get
            {
                return _logCategory;
            }
        }
        public Log(LogCategory logCategory)
        {
            _logCategory = logCategory;
        }

        public void Debug(object message)
        {
            if (_logCategory == null || _logCategory.MiniLevel > Level.DEBUG) return; //等级高于该方法等级时不记录日志
            string methodInfo = GetMethodInfo();

            foreach (LogListener item in _logCategory.LogListeners)
            {
                NetLogRepository netLog = GetNetLogRepository(item, methodInfo);
                netLog.SaveLog(message.ToString());
            }
        }

        public void Debug(object message, Exception exception)
        {
            if (_logCategory == null || _logCategory.MiniLevel > Level.DEBUG) return; //等级高于该方法等级时不记录日志
            string methodInfo = GetMethodInfo();

            foreach (LogListener item in _logCategory.LogListeners)
            {
                NetLogRepository netLog = GetNetLogRepository(item, methodInfo);
                netLog.SaveLog(message.ToString(), exception);
            }
        }

        public void Error(object message)
        {
            if (_logCategory == null || _logCategory.MiniLevel > Level.DEBUG) return; //等级高于该方法等级时不记录日志
            string methodInfo = GetMethodInfo();

            foreach (LogListener item in _logCategory.LogListeners)
            {
                NetLogRepository netLog = GetNetLogRepository(item, methodInfo);
                netLog.SaveLog(message.ToString());
            }
        }

        public void Error(object message, Exception exception)
        {
            if (_logCategory == null || _logCategory.MiniLevel > Level.DEBUG) return; //等级高于该方法等级时不记录日志
            string methodInfo = GetMethodInfo();

            foreach (LogListener item in _logCategory.LogListeners)
            {
                NetLogRepository netLog = GetNetLogRepository(item, methodInfo);
                netLog.SaveLog(message.ToString(), exception);
            }
        }

        public void Fatal(object message)
        {
            if (_logCategory == null || _logCategory.MiniLevel > Level.DEBUG) return; //等级高于该方法等级时不记录日志
            string methodInfo = GetMethodInfo();

            foreach (LogListener item in _logCategory.LogListeners)
            {
                NetLogRepository netLog = GetNetLogRepository(item, methodInfo);
                netLog.SaveLog(message.ToString());
            }
        }

        public void Fatal(object message, Exception exception)
        {
            if (_logCategory == null || _logCategory.MiniLevel > Level.DEBUG) return; //等级高于该方法等级时不记录日志
            string methodInfo = GetMethodInfo();

            foreach (LogListener item in _logCategory.LogListeners)
            {
                NetLogRepository netLog = GetNetLogRepository(item, methodInfo);
                netLog.SaveLog(message.ToString(), exception);
            }
        }

        public void Info(object message)
        {
            if (_logCategory == null || _logCategory.MiniLevel > Level.DEBUG) return; //等级高于该方法等级时不记录日志
            string methodInfo = GetMethodInfo();

            foreach (LogListener item in _logCategory.LogListeners)
            {
                NetLogRepository netLog = GetNetLogRepository(item, methodInfo);
                netLog.SaveLog(message.ToString());
            }
        }

        public void Info(object message, Exception exception)
        {
            if (_logCategory == null || _logCategory.MiniLevel > Level.DEBUG) return; //等级高于该方法等级时不记录日志
            string methodInfo = GetMethodInfo();

            foreach (LogListener item in _logCategory.LogListeners)
            {
                NetLogRepository netLog = GetNetLogRepository(item, methodInfo);
                netLog.SaveLog(message.ToString(), exception);
            }
        }

        public void Warn(object message)
        {
            if (_logCategory == null || _logCategory.MiniLevel > Level.DEBUG) return; //等级高于该方法等级时不记录日志
            string methodInfo = GetMethodInfo();

            foreach (LogListener item in _logCategory.LogListeners)
            {
                NetLogRepository netLog = GetNetLogRepository(item, methodInfo);
                netLog.SaveLog(message.ToString());
            }
        }

        public void Warn(object message, Exception exception)
        {
            if (_logCategory == null || _logCategory.MiniLevel > Level.DEBUG) return; //等级高于该方法等级时不记录日志
            string methodInfo = GetMethodInfo();

            foreach (LogListener item in _logCategory.LogListeners)
            {
                NetLogRepository netLog = GetNetLogRepository(item, methodInfo);
                netLog.SaveLog(message.ToString(), exception);
            }

        }

        public string GetMethodInfo()
        {
            StackFrame fr = new StackFrame(2, true);
            MethodBase mb = fr.GetMethod();
            string systemModule = "Module:" + mb.Module.ToString() + Environment.NewLine;
            systemModule += "Namespace:" + mb.ReflectedType.Namespace + Environment.NewLine;
            //完全限定名，包括命名空间
            systemModule += "Class:" + mb.ReflectedType.FullName + Environment.NewLine;
            systemModule += "Method:" + mb.Name;
            return systemModule;
        }

        private NetLogRepository GetNetLogRepository(LogListener listener, string methodInfo)
        {
            NetLogRepository netLog;
            if (_netLogRepDic.ContainsKey(listener.ID))
            {
                netLog = _netLogRepDic[listener.ID];
                netLog.MethodInfo = methodInfo;
            }
            else
            {
                LogCategory logCategory = (LogCategory)_logCategory.Clone();
                logCategory.LogListeners.Add(listener);
                netLog = new NetLogRepository(logCategory, methodInfo);
                _netLogRepDic.Add(listener.ID, netLog);
            }
            return netLog;
        }
    }
}
