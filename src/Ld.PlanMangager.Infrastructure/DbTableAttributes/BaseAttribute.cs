using System;
using System.Collections.Generic;
using System.Text;

namespace Ld.PlanMangager.Infrastructure.DbTableAttributes
{
    public abstract class BaseAttribute : Attribute
    {

        public BaseAttribute()
        {

        }

        public BaseAttribute(String name)
        {
            Name = name;
        }

        /// <summary>
        /// 名称
        /// </summary>
        public String Name { get; protected set; }

    }
}
