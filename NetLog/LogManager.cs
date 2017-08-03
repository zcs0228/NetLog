using Nelibur.ObjectMapper;
using NetLog.ConfigModel;
using NetLog.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NetLog
{
    public class LogManager
    {
        private static LogCategory _logCategory;
        private static Dictionary<string, ILog> _logsDic = new Dictionary<string, ILog>();

        public static ILog CreateLogger(string logCategory)
        {
            if (_logsDic.ContainsKey(logCategory))
            {
                return _logsDic[logCategory];
            }
            else
            {
                InitLogConfig(logCategory);
                Log netLog = new Log(_logCategory);
                return netLog;
            }
        }

        /// <summary>
        /// 初始化日志配置信息
        /// </summary>
        /// <param name="logCatefory"></param>
        private static void InitLogConfig(string logCategory)
        {
            TinyMapperHelper.TinyMapperConfig();

            #region 获取XML配置信息
            //_logCategory = XMLRepository.GetNetLogConfig(logCategory);
            #endregion 获取XML配置信息

            #region 获取数据库配置信息
            DBRepository dbr = new DBRepository();
            DBLogCategory dbCategory = dbr.GetLogCategoryWithDefaultListener(logCategory);
            if (dbCategory == null)
            {
                _logCategory = null;
            }
            else
            {
                _logCategory = TinyMapper.Map<LogCategory>(dbCategory);
            }
            #endregion 获取数据库配置信息
        }
    }
}
