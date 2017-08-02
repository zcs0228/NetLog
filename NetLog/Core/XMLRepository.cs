using Nelibur.ObjectMapper;
using NetLog.ConfigModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NetLog.Core
{
    public class XMLRepository
    {
        public static LogCategory GetNetLogConfig(string category)
        {
            LogCategory logCategory = null;
            string configPath = AppDomain.CurrentDomain.BaseDirectory + "\\NetLog.config";
            string configContent = File.ReadAllText(configPath, Encoding.UTF8);
            IList<XMLLogCategory> xmlCategorys = DataConverts.XMLToObject<XMLLogCategory>(configContent, "Category");
            string listeners = String.Empty;
            foreach (var item in xmlCategorys)
            {
                if (item.ID != "test") continue;
                listeners = item.LogListeners;
                logCategory = TinyMapper.Map<LogCategory>(item);
            }
            if (listeners == String.Empty) return null;
            logCategory.LogListeners = new List<LogListener>();
            IList<XMLLogListener> xmlListeners = DataConverts.XMLToObject<XMLLogListener>(configContent, "Listener");
            IList<string> listenersList = listeners.Split(',').ToList();
            foreach (string ls in listenersList)
            {
                foreach (var item in xmlListeners)
                {
                    if (item.ID != ls) continue;
                    LogListener logListener = TinyMapper.Map<LogListener>(item);
                    logCategory.LogListeners.Add(logListener);
                }
            }
            return logCategory;
        }
    }
}
