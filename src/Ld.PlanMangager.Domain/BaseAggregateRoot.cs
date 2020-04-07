using System;
using System.Collections.Generic;
using System.Text;
using Ld.PlanMangager.Repository.Interface;

namespace Ld.PlanMangager.Domain
{
    /// <summary>
    /// 聚合根基类
    /// </summary>
    public abstract class BaseAggregateRoot<TId> : IAggregateRoot<TId>
    {
        public TId Id { get; set; }

    }
}
