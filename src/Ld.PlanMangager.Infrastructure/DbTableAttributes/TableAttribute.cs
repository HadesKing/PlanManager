using System;
using System.Collections.Generic;
using System.Text;

namespace Ld.PlanMangager.Infrastructure.DbTableAttributes
{
    /// <summary>
    /// 表
    /// </summary>
    public sealed class TableAttribute : BaseAttribute
    {
        public TableAttribute(String name) : this("", name)
        {
        }

        public TableAttribute(String schema, String name)
        {
            Schema = schema;
            Name = name;
        }

        /// <summary>
        /// 架构/所属用户
        /// </summary>
        public String Schema { get; set; }

    }
}
