using Ld.PlanMangager.Infrastructure.DbTableAttributes;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Ld.PlanMangager.Infrastructure.DataMapping
{
    public sealed class DbTableColumnMapping
    {
        private static IDictionary<String, Dictionary<String, String>> m_tableColumnMappingDict = new Dictionary<String, Dictionary<String, String>>();

        /// <summary>
        /// 获取数据库列映射
        /// 说明：
        ///     根据数据库的不同，返回结果的key可能需要增加不同的前缀
        ///     SqlServer(即MSSQL)为 @
        ///     MySQL为 ?
        ///     Oracle为 :
        /// </summary>
        /// <param name="type"></param>
        /// <returns>
        /// 返回结果说明：
        ///     key#实体属性名称
        ///     value#数据库表字段名称
        /// </returns>
        public static Dictionary<String, String> GetColumnMapping(Type type)
        {
            Dictionary<String, String> dict = new Dictionary<String, String>();
            if(null != type)
            {
                String columnMappingKey = type.Name;
                if(m_tableColumnMappingDict.ContainsKey(columnMappingKey))
                {
                    //如果缓存中已经有了，则从缓存中获取
                    return m_tableColumnMappingDict[columnMappingKey];
                }
                PropertyInfo[] propertyInfos = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                if(null != propertyInfos && propertyInfos.Length > 0)
                {
                    TableIgnoreColumnAttribute ignoreColumnAttribute = null;
                    TableColumnAttribute columnAttribute = null;
                    foreach (PropertyInfo propertyInfo in propertyInfos)
                    {
                        //判断是否需要忽略
                        ignoreColumnAttribute = propertyInfo.GetCustomAttribute<TableIgnoreColumnAttribute>();
                        if(null == ignoreColumnAttribute)
                        {
                            String key = propertyInfo.Name;
                            if (dict.ContainsKey(key)) continue;        //如果设置了多个列，则只设置一个，其他的不进行映射
                            //判断是否有自主设置映射属性
                            columnAttribute = propertyInfo.GetCustomAttribute<TableColumnAttribute>();
                            if(null == columnAttribute)
                            {
                                dict[key] = key;
                            }
                            else
                            {
                                dict[key] = columnAttribute.Name;
                            }
                        }
                    }
                }
                m_tableColumnMappingDict[columnMappingKey] = dict;
            }
            return dict;
        }

    }
}
