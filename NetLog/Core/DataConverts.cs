using NetLog.ConfigModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace NetLog.Core
{
    public class DataConverts
    {
        public static IList<T> XMLToObject<T>(string xmlString, string dataNodeName)
        {
            IList<T> result = new List<T>();
            XElement xmlDoc = XElement.Parse(xmlString.Trim());
            IEnumerable<XElement> dataNodes = from target in xmlDoc.Descendants(dataNodeName)
                                              select target;
            if (dataNodes == null || dataNodes.Count() == 0)
            {
                throw new Exception("不存在名称为【" + dataNodeName + "】的元素！");
            }

            try
            {
                Type t = typeof(T);
                //Assembly ass = Assembly.GetAssembly(t);//获取泛型的程序集  
                PropertyInfo[] pc = t.GetProperties();//获取到泛型所有属性的集合

                foreach (XElement dataNode in dataNodes)
                {
                    Object obj = Activator.CreateInstance<T>();//泛型实例化
                    foreach (PropertyInfo pi in pc)
                    {
                        if (!pi.CanWrite) continue; //判断属性能不能赋值
                        string _name = pi.Name;
                        string _value = String.Empty;
                        IEnumerable<XElement> property = from target in dataNode.Descendants(_name)
                                                         select target;
                        if (property != null && property.Count() > 0)
                        {
                            _value = property.FirstOrDefault().Value;
                        }
                        //if (pi.PropertyType.Equals(typeof(String)))//判断属性的类型是不是String  
                        //{
                        //    pi.SetValue((T)obj, _value, null);//给泛型的属性赋值  
                        //}
                        pi.SetValue((T)obj, _value, null);//给泛型的属性赋值
                    }
                    result.Add((T)obj);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("转换数据报错，错误信息：" + ex.Message + ";" + ex.InnerException);
            }
            return result;
        }

        public static IList<T> DataTableToObject<T>(DataTable dataTable)
        {
            // 确认参数有效
            if (dataTable == null || dataTable.Rows.Count == 0 || dataTable.Columns.Count == 0)
            {
                return null;
            }

            IList<T> result = new List<T>();

            try
            {
                Type t = typeof(T);
                //Assembly ass = Assembly.GetAssembly(t);//获取泛型的程序集  
                PropertyInfo[] pc = t.GetProperties();//获取到泛型所有属性的集合

                foreach (DataRow dr in dataTable.Rows)
                {
                    Object obj = Activator.CreateInstance<T>();//泛型实例化
                    foreach (PropertyInfo pi in pc)
                    {
                        if (!pi.CanWrite) continue; //判断属性能不能赋值
                        string _name = pi.Name;
                        if (!dataTable.Columns.Contains(_name)) continue;
                        object _value = dr[_name];
                        object changedValue = TypeChange(pi.PropertyType, _value);
                        pi.SetValue((T)obj, changedValue, null);//给泛型的属性赋值
                    }
                    result.Add((T)obj);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("转换数据报错，错误信息：" + ex.Message + ";" + ex.InnerException);
            }
            return result;
        }

        public static LogCategory XMLToCategory(string xmlString, string category)
        {
            LogCategory result = new LogCategory();
            XElement xmlDoc = XElement.Parse(xmlString.Trim());
            IEnumerable<XElement> dataNodes = from target in xmlDoc.Descendants("Category")
                                              select target;
            if (dataNodes == null || dataNodes.Count() == 0)
            {
                throw new Exception("不存在日志类型的配置信息！");
            }
            foreach (XElement dataNode in dataNodes)
            {
                IEnumerable<XElement> idProperty = from target in dataNode.Descendants("ID")
                                                 select target;
                string id = idProperty.FirstOrDefault().Value;
                if (id != category) continue;
                foreach(XElement item in dataNode.Descendants())
                {
                }
            }
            return result;
        }

        private static object TypeChange(Type type, object data)
        {
            object result = null;
            if (type.Equals(typeof(int)))//判断属性的类型是不是int
            {
                int tempValue = 0;
                int.TryParse(data.ToString().Trim(), out tempValue);
                result = tempValue;
            }
            else if (type.Equals(typeof(decimal)))
            {
                decimal tempValue = 0;
                decimal.TryParse(data.ToString().Trim(), out tempValue);
                result = tempValue;
            }
            else if (type.Equals(typeof(decimal)))
            {
                decimal tempValue = 0;
                decimal.TryParse(data.ToString().Trim(), out tempValue);
                result = tempValue;
            }
            else if (type.Equals(typeof(double)))
            {
                double tempValue = 0;
                double.TryParse(data.ToString().Trim(), out tempValue);
            }
            else if (type.Equals(typeof(DateTime)))
            {
                DateTime tempValue = DateTime.MinValue;
                DateTime.TryParse(data.ToString().Trim(), out tempValue);
                result = tempValue;
            }
            else if (type.Equals(typeof(Boolean)))
            {
                bool tempValue = false;
                if (data.ToString().Trim() == "0")
                {
                    tempValue = false;
                }
                else if (data.ToString().Trim() == "1")
                {
                    tempValue = true;
                }
                else
                {
                    bool.TryParse(data.ToString().Trim(), out tempValue);
                }
                result = tempValue;
            }
            else
            {
                result = data.ToString().Trim();
            }
            return result;
        }
    }
}
