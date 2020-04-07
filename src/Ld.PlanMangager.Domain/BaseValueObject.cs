using Ld.PlanMangager.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ld.PlanMangager.Domain
{
    public abstract class BaseValueObject<TId> : BaseDomain, IValueObject<TId>
    {
        public TId Id { get; set; }

        public abstract string DbTableName { get; }

        public String Description { get; set; }

        public String Remark { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime LastUpdateTime { get; set; }

    }
}
