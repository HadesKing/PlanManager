using System;
using System.Collections.Generic;
using System.Text;

namespace Ld.PlanMangager.Infrastructure.DbTableAttributes
{
    /// <summary>
    /// 忽略列
    /// </summary>
    public sealed class TableIgnoreColumnAttribute : BaseAttribute
    {

        public TableIgnoreColumnAttribute()
        {

        }

        public TableIgnoreColumnAttribute(String name) : base(name)
        {

        }

    }
}
