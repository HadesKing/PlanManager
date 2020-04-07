using System;
using System.Collections.Generic;
using System.Text;

namespace Ld.PlanMangager.Infrastructure.TSqlRules
{
    public sealed class SpecialCharacterRule : BaseTSqlRule
    {
        /// <summary>
        /// 是否匹配
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>
        /// 返回结果：
        ///     true#表示匹配规则
        ///     false#表示不匹配规则
        /// </returns>
        public override bool IsMatch(string sql)
        {
            String tmpSql = sql.ToLower();

            /**
             * 规则：
             *     sql 语句中不能包含特殊字符（特别是单引号、斜杠、反斜杠）
             *     另外，不允许出现*号字符（防止select*），所有sql参数必须参数化
             */
            if (tmpSql.IndexOf("*") > -1 
                || tmpSql.IndexOf("'") > -1 
                || tmpSql.IndexOf("/") > -1 
                || tmpSql.IndexOf("\\") > -1)
            {
                ErrorMsg = "T-SQL can't contain special characters ! Special character: * ' / \\ ";
                return true;
            }

            return false;
        }
    }
}
