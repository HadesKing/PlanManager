using Ld.PlanMangager.Infrastructure.DbTableAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Ld.PlanMangager.Infrastructure.DataMapping
{
    public sealed class DbTablePrimaryKeyMapping
    {
        private static IDictionary<String, Dictionary<String, String>> m_primaryKeyDict = new Dictionary<String, Dictionary<String, String>>();

        /// <summary>
        /// 获取表名称
        /// </summary>
        /// <param name="Type"></param>
        /// <returns>
        /// key是属性名称
        /// value是数据库字段名称
        /// </returns>
        public static Dictionary<String, String> GetPrimaryKey(Type type)
        {
            String key = type.Name;
            String primaryKeyName = null;
            Dictionary<String, String> dict = null;
            if (m_primaryKeyDict.ContainsKey(key))
            {
                return m_primaryKeyDict[key];
            }
            else
            {
                dict = new Dictionary<String, String>();
                String keyName = null;
                PropertyInfo[] propertyInfos = type.GetProperties();

                if(null != propertyInfos && propertyInfos.Length > 0)
                {
                    TablePrimaryKeyAttribute primaryKeyAttribute = null;
                    foreach (PropertyInfo propertyInfo in propertyInfos)
                    {
                        primaryKeyAttribute = propertyInfo.GetCustomAttribute<TablePrimaryKeyAttribute>();
                        if (null != primaryKeyAttribute)
                        {
                            keyName = propertyInfo.Name;
                            primaryKeyName = String.IsNullOrWhiteSpace(primaryKeyAttribute.Name)
                                 ? "id"
                                : $"{primaryKeyAttribute.Name}";
                            dict[keyName] = primaryKeyName;
                            break;
                        }
                        else if(propertyInfo.Name.ToLower() == "id")
                        {
                            //这里必须保证每个领域对象（实体类）都要有id字段
                            keyName = propertyInfo.Name;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }

                if (null == primaryKeyName)
                {
                    primaryKeyName = "id";
                }
                dict[keyName] = primaryKeyName;
                m_primaryKeyDict[key] = dict;
            }

            return dict;
        }

    }
}
