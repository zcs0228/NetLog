using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetLog.ConfigModel
{
    public class XMLLogListener
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
        private string _destinationType;
        public string DestinationType
        {
            set { _destinationType = value.ToString().Trim(); }
        }
        public int IntDestinationType
        {
            get
            {
                int destinationType = 0;
                int.TryParse(_destinationType, out destinationType);
                return destinationType;
            }
        }
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
        string _appendToFile;
        public string AppendToFile
        {
            set { _appendToFile = value.ToString().Trim(); }
        }
        public bool BooleanAppendToFile
        {
            get
            {
                if (_appendToFile == "0")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        /// <summary>
        /// 日期格式
        /// </summary>
        public string DateFormatter { get; set; }
        /// <summary>
        /// 文件最大存储
        /// </summary>
        string _maximumFileSize;
        public string MaximumFileSize
        {
            set { _maximumFileSize = value.ToString().Trim(); }
        }
        public int IntMaximumFileSize
        {
            get
            {
                int maximumFileSize = 0;
                int.TryParse(_maximumFileSize, out maximumFileSize);
                return maximumFileSize;
            }
        }

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
