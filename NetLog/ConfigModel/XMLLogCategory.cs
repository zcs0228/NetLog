using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetLog.ConfigModel
{
    public class XMLLogCategory
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
        private string _miniLevel;
        public int IntMiniLevel
        {
            get
            {
                int miniLevel = 0;
                int.TryParse(_miniLevel.ToString(), out miniLevel);
                return miniLevel;
            }
        }
        public string MiniLevel
        {
            set
            {
                _miniLevel = value;
            }
        }
        /// <summary>
        /// 日志监听者
        /// </summary>
        public string LogListeners { get; set; }
    }
}
