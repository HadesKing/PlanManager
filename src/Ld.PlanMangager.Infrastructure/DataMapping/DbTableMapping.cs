using Ld.PlanMangager.Infrastructure.DbTableAttributes;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Ld.PlanMangager.Infrastructure.DataMapping
{
    public sealed class DbTableMapping
    {
        private static IDictionary<String, String> m_tableMappingDict = new Dictionary<String, String>();

        /// <summary>
        /// 获取表名称
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static String GetTableName<T>(T t) where T : class
        {
            String tmpTableName = t.GetType().Name;
            String tableName = null;
            if (m_tableMappingDict.ContainsKey(tmpTableName))
            {
                return m_tableMappingDict[tmpTableName];
            }
            else if (null != t)
            {
                TableAttribute tableAttribute = t.GetType().GetCustomAttribute<TableAttribute>();
                if (null != tableAttribute)
                {
                    tableName = String.IsNullOrWhiteSpace(tableAttribute.Schema)
                         ? $"{tableAttribute.Name}"
                        : $"{tableAttribute.Schema}.{tableAttribute.Name}";
                }
                else
                {
                    tableName = t.GetType().Name;
                }
                m_tableMappingDict[tmpTableName] = tableName;
            }

            return tableName;
        }

    }
}
