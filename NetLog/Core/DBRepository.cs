using Genersoft.MDM.Pub.Server.Com;
using NetLog.ConfigModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace NetLog.Core
{
    public class DBRepository
    {
        private MDMDatabaseFactory db = new MDMDatabaseFactory(String.Empty, String.Empty);

        public DBLogCategory GetLogCategory(string categoryBh)
        {
            DBLogCategory result;
            string queryCategory = @"select * from MDMLogCategory where LogCategory_BH='{0}'";
            queryCategory = String.Format(queryCategory, categoryBh);
            string errMsg = String.Empty;
            DataSet category = db.MDMExecutDataSet(queryCategory, string.Empty, ref errMsg);
            if (category == null || category.Tables.Count == 0 || category.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            IList<DBLogCategory> dbLogCategorys = DataConverts.DataTableToObject<DBLogCategory>(category.Tables[0]);
            if (dbLogCategorys == null || dbLogCategorys.Count == 0) return null;
            result = dbLogCategorys.FirstOrDefault();
            if (result.LogCategory_Listeners == String.Empty) return null;

            IList<string> listenersbh = result.LogCategory_Listeners.Split(',').ToList();
            result.LogListeners = new List<DBLogListener>();
            string queryListener = @"select * from MDMLogListener where LogListener_BH='{0}'";
            foreach (var item in listenersbh)
            {
                string sql = String.Format(queryListener, item);
                DataSet listeners = db.MDMExecutDataSet(sql, string.Empty, ref errMsg);
                if (listeners == null || listeners.Tables.Count == 0) return null;
                IList<DBLogListener> listenerList = DataConverts.DataTableToObject<DBLogListener>(listeners.Tables[0]);
                if (listenerList == null) return null;
                result.LogListeners.Add(listenerList.FirstOrDefault());
            }
            return result;
        }

        public DBLogCategory GetLogCategoryWithDefaultListener(string categoryBh)
        {
            DBLogCategory result;
            string queryCategory = @"select * from MDMLogCategory where LogCategory_BH='{0}'";
            queryCategory = String.Format(queryCategory, categoryBh);
            string errMsg = String.Empty;
            DataSet category = db.MDMExecutDataSet(queryCategory, string.Empty, ref errMsg);
            if (category == null || category.Tables.Count == 0 || category.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            IList<DBLogCategory> dbLogCategorys = DataConverts.DataTableToObject<DBLogCategory>(category.Tables[0]);
            if (dbLogCategorys == null || dbLogCategorys.Count == 0) return null;
            result = dbLogCategorys.FirstOrDefault();
            result.LogListeners = new List<DBLogListener>();
            DBLogListener dbLogLis = new DBLogListener()
            {
                LogListener_BH = "file",
                LogListener_MC = "文件监听器",
                LogListener_DestinationType = 0,
                LogListener_AppendToFile = true,
                LogListener_FileName = "",
                LogListener_FilePath = "\\MDMLog\\" + result.LogCategory_MC,
                LogListener_DateFormatter = "",
                LogListener_LayoutHeader = "---------------------------",
                LogListener_LayoutContent = "",
                LogListener_LayoutFooter = "---------------------------"
            };
            result.LogListeners.Add(dbLogLis);
            return result;
        }

        public string WriteLogToDB(string insertSql, string logLevel, string methodInfo, string message)
        {
            string errMsg = String.Empty;
            IList<IDbDataParameter> parameters = new List<IDbDataParameter>();
            if (db.DBType == DBTypes.SQLServer)
            {
                parameters.Add(db.MDMMakeParam("@LogID", Guid.NewGuid()));
                parameters.Add(db.MDMMakeParam("@LogDate", DateTime.Now));
                parameters.Add(db.MDMMakeParam("@LogLevel", logLevel));
                parameters.Add(db.MDMMakeParam("@MethodInfo", methodInfo));
                parameters.Add(db.MDMMakeParam("@Message", message));
            }
            else if (db.DBType == DBTypes.Oracle)
            {
                insertSql = insertSql.Replace('@', ':');
                parameters.Add(db.MDMMakeParam(":LogID", Guid.NewGuid()));
                parameters.Add(db.MDMMakeParam(":LogDate", DateTime.Now));
                parameters.Add(db.MDMMakeParam(":LogLevel", logLevel));
                parameters.Add(db.MDMMakeParam(":MethodInfo", methodInfo));
                parameters.Add(db.MDMMakeParam(":Message", message));
            }
            db.MDMExecutSql(insertSql, ref errMsg, parameters.ToArray());
            return errMsg;
        }
    }
}
