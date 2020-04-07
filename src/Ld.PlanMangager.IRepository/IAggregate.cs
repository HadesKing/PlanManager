using System;
using System.Collections.Generic;
using System.Text;

namespace Ld.PlanMangager.Repository.Interface
{
    /// <summary>
    /// 所有领域模型都属于一个聚合
    /// 一个聚合包含聚合根（至少一个）、实体（0或多个）、值对象（0或多个）
    /// </summary>
    public interface IAggregate
    { 
    
    }


    public interface IAggregate<TId> : IAggregate
    {

        /// <summary>
        /// 这里使用ID是因为数据库每张表都有一张ID
        /// </summary>
        TId Id { get; set; }

    }


}
