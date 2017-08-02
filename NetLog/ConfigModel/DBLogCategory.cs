using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetLog.ConfigModel
{
    public class DBLogCategory
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string LogCategory_BH { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string LogCategory_MC { get; set; }
        /// <summary>
        /// 日志等级
        /// </summary>
        public int LogCategory_MiniLevel { get; set; }
        /// <summary>
        /// 日志监听者
        /// </summary>
        public string LogCategory_Listeners { get; set; }
        /// <summary>
        /// 日志监听者
        /// </summary>
        public List<DBLogListener> LogListeners { get; set; }
    }
}
