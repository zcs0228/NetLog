using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetLog.ConfigModel
{
    public class DBLogListener
    {
        /// <summary>
        /// 编号
        /// </summary>
        public string LogListener_BH { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string LogListener_MC { get; set; }
        /// <summary>
        /// 输出方式
        /// </summary>
        public int LogListener_DestinationType { get; set; }
        /// <summary>
        /// 连接字符串
        /// </summary>
        public string LogListener_ConnString { get; set; }
        /// <summary>
        /// 保存日志SQL
        /// </summary>
        public string LogListener_InsertSql { get; set; }

        /// <summary>
        /// 文件路径
        /// </summary>
        public string LogListener_FilePath { get; set; }
        /// <summary>
        /// 文件名称
        /// </summary>
        public string LogListener_FileName { get; set; }
        /// <summary>
        /// 是否追加到文件
        /// </summary>
        public bool LogListener_AppendToFile { get; set; }
        /// <summary>
        /// 日期格式
        /// </summary>
        public string LogListener_DateFormatter { get; set; }
        /// <summary>
        /// 文件最大存储
        /// </summary>
        public int LogListener_MaximumFileSize { get; set; }

        /// <summary>
        /// 日志布局头
        /// </summary>
        public string LogListener_LayoutHeader { get; set; }
        /// <summary>
        /// 日志内容
        /// </summary>
        public string LogListener_LayoutContent { get; set; }
        /// <summary>
        /// 日志布局尾
        /// </summary>
        public string LogListener_LayoutFooter { get; set; }
    }
}
