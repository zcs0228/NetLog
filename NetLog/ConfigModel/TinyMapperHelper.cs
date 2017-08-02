using Nelibur.ObjectMapper;
using Nelibur.ObjectMapper.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetLog.ConfigModel
{
    public class TinyMapperHelper
    {
        private static bool _configFlag = false;
        public static void TinyMapperConfig()
        {
            if (!_configFlag)
            {
                TinyMapper.Bind<DBLogListener, LogListener>(config =>
                {
                    config.Bind(x => x.LogListener_BH, y => y.ID);
                    config.Bind(x => x.LogListener_MC, y => y.Name);
                    config.Bind(x => x.LogListener_DestinationType, y => y.DestinationType);
                    config.Bind(x => x.LogListener_ConnString, y => y.DBConnectionString);
                    config.Bind(x => x.LogListener_InsertSql, y => y.InsertSql);
                    config.Bind(x => x.LogListener_FilePath, y => y.FilePath);
                    config.Bind(x => x.LogListener_FileName, y => y.FileName);
                    config.Bind(x => x.LogListener_AppendToFile, y => y.AppendToFile);
                    config.Bind(x => x.LogListener_DateFormatter, y => y.DateFormatter);
                    config.Bind(x => x.LogListener_MaximumFileSize, y => y.MaximumFileSize);
                    config.Bind(x => x.LogListener_LayoutHeader, y => y.LayoutHeader);
                    config.Bind(x => x.LogListener_LayoutContent, y => y.LayoutContent);
                    config.Bind(x => x.LogListener_LayoutFooter, y => y.LayoutFooter);
                });
                TinyMapper.Bind<DBLogCategory, LogCategory>(config =>
                {
                    config.Bind(x => x.LogCategory_BH, y => y.ID);
                    config.Bind(x => x.LogCategory_MC, y => y.Name);
                    config.Bind(x => x.LogCategory_MiniLevel, y => y.MiniLevel);
                    config.Bind(x => x.LogListeners, y => y.LogListeners);
                });
                TinyMapper.Bind<XMLLogListener, LogListener>(config =>
                {
                    config.Bind(x => x.ID, y => y.ID);
                    config.Bind(x => x.Name, y => y.Name);
                    config.Bind(x => x.IntDestinationType, y => y.DestinationType);
                    config.Bind(x => x.DBConnectionString, y => y.DBConnectionString);
                    config.Bind(x => x.InsertSql, y => y.InsertSql);
                    config.Bind(x => x.FilePath, y => y.FilePath);
                    config.Bind(x => x.FileName, y => y.FileName);
                    config.Bind(x => x.BooleanAppendToFile, y => y.AppendToFile);
                    config.Bind(x => x.DateFormatter, y => y.DateFormatter);
                    config.Bind(x => x.IntMaximumFileSize, y => y.MaximumFileSize);
                    config.Bind(x => x.LayoutHeader, y => y.LayoutHeader);
                    config.Bind(x => x.LayoutContent, y => y.LayoutContent);
                    config.Bind(x => x.LayoutFooter, y => y.LayoutFooter);
                });
                TinyMapper.Bind<XMLLogCategory, LogCategory>(config =>
                {
                    config.Bind(x => x.ID, y => y.ID);
                    config.Bind(x => x.Name, y => y.Name);
                    config.Bind(x => x.IntMiniLevel, y => y.MiniLevel);
                    config.Ignore(x => x.LogListeners);
                });
                _configFlag = true;
            }
        }
    }
}
