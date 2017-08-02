using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetLog.ConfigModel
{
    public enum Level
    {
        /// <summary>
        /// ALL Level 是最低等级的，用于打开所有日志记录
        /// </summary>
        ALL,
        /// <summary>
        /// 与DEBUG 相比更细致化的记录事件消息
        /// </summary>
        TRACE,
        /// <summary>
        /// DEBUG Level 指出细粒度信息事件对调试应用程序是非常有帮助的
        /// </summary>
        DEBUG,
        /// <summary>
        /// INFO level 表明 消息在粗粒度级别上突出强调应用程序的运行过程
        /// </summary>
        INFO,
        /// <summary>
        /// WARN level 表明会出现潜在错误的情形
        /// </summary>
        WARN,
        /// <summary>
        /// ERROR level 指出虽然发生错误事件，但仍然不影响系统的继续运行
        /// </summary>
        ERROR,
        /// <summary>
        /// FATAL level 指出每个严重的错误事件将会导致应用程序的退出
        /// </summary>
        FATAL,
        /// <summary>
        /// OFF Level 是最高等级的，用于关闭所有日志记录
        /// </summary>
        OFF
    }
    public class LogCategory : ICloneable
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 日志等级
        /// </summary>
        public Level MiniLevel { get; set; }
        /// <summary>
        /// 日志监听者
        /// </summary>
        public List<LogListener> LogListeners { get; set; }

        public object Clone()
        {
            LogCategory result = new LogCategory();
            result.ID = this.ID;
            result.Name = this.Name;
            result.MiniLevel = this.MiniLevel;
            result.LogListeners = new List<LogListener>();
            return result;
        }
    }
}
