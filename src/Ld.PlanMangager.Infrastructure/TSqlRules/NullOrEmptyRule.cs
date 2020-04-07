using System;
using System.Collections.Generic;
using System.Text;

namespace Ld.PlanMangager.Infrastructure.TSqlRules
{
    public sealed class NullOrEmptyRule : BaseTSqlRule
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
            if (String.IsNullOrWhiteSpace(sql))
            {
                ErrorMsg = "T-Sql is null or empty !";
                return true;
            }

            return false;
        }

    }
}
