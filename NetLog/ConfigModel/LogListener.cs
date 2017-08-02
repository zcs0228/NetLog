using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetLog.ConfigModel
{
    public enum DestinationType
    {
        File,
        DB
    }
    public class LogListener
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
        /// 输出方式
        /// </summary>
        public DestinationType DestinationType { get; set; }
        /// <summary>
        /// 连接字符串
        /// </summary>
        public string DBConnectionString { get; set; }
        /// <summary>
        /// 保存日志SQL
        /// </summary>
        public string InsertSql { get; set; }

        /// <summary>
        /// 文件路径
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 是否追加到文件
        /// </summary>
        public bool AppendToFile { get; set; }
        /// <summary>
        /// 日期格式
        /// </summary>
        public string DateFormatter { get; set; }
        /// <summary>
        /// 文件最大存储
        /// </summary>
        public int MaximumFileSize { get; set; }

        /// <summary>
        /// 日志布局头
        /// </summary>
        public string LayoutHeader { get; set; }
        /// <summary>
        /// 日志内容
        /// </summary>
        public string LayoutContent { get; set; }
        /// <summary>
        /// 日志布局尾
        /// </summary>
        public string LayoutFooter { get; set; }
    }
}
