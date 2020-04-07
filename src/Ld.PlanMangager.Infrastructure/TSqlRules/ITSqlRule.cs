using System;
using System.Collections.Generic;
using System.Text;

namespace Ld.PlanMangager.Infrastructure.TSqlRules
{
    public interface ITSqlRule
    {
        String ErrorMsg { get; }

        /// <summary>
        /// 是否匹配
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>
        /// 返回结果：
        ///     true#表示匹配规则
        ///     false#表示不匹配规则
        /// </returns>
        bool IsMatch(String sql);

    }
}
