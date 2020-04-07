using System;
using System.Collections.Generic;
using System.Text;

namespace Ld.PlanMangager.Repository.Interface
{
    /// <summary>
    /// 聚合根
    /// 是一个特殊的实体
    /// </summary>
    public interface IAggregateRoot<TId> : IEntity<TId>
    {
    }
}
