using System;
using System.Collections.Generic;
using System.Text;

namespace Ld.PlanMangager.Infrastructure.TSqlRules
{
    public sealed class WhereSqlRule : BaseTSqlRule
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
             *     select/update/delete 语句必须包含where条件
             */
            if (tmpSql.IndexOf("select") == 0
                || tmpSql.IndexOf("update") == 0
                || tmpSql.IndexOf("delete") == 0
                )
            {
                if (tmpSql.IndexOf(" where ") < 0)
                {
                    ErrorMsg = "T-SQL must contain a where condition !";
                    return true;
                }
            }

            return false;
        }

    }
}
