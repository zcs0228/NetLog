using Nelibur.ObjectMapper;
using NetLog;
using NetLog.ConfigModel;
using NetLog.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetLogTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ILog log = LogManager.CreateLogger("test");
            log.Debug("abcdefg");            
        }

        public class TestClase
        {
            public int dc1 { get; set; }
            public decimal dc2 { get; set; }
            public double dc3 { get; set; }
            public DateTime dc4 { get; set; }
            public string dc5 { get; set; }
        }
    }
}
