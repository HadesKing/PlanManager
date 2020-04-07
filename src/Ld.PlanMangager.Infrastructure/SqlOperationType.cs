using System;
using System.ComponentModel;

namespace Ld.PlanMangager.Infrastructure
{
    public enum SqlOperationType
    {
        /// <summary>
        /// INSERT
        /// </summary>
        [Description("增加")]
        INSERT = 1,
        /// <summary>
        /// UPDATE
        /// </summary>
        [Description("更新")]
        UPDATE = 2,
        /// <summary>
        /// DELETE
        /// </summary>
        [Description("删除")]
        DELETE = 3,
        /// <summary>
        /// SELECT
        /// </summary>
        [Description("查询")]
        SELECT = 4
    }
}
