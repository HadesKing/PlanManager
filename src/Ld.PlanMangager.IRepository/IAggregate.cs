using System;
using System.Collections.Generic;
using System.Text;

namespace Ld.PlanMangager.Repository.Interface
{
    public interface IAggregate
    { 
    
    }


    public interface IAggregate<TId> : IAggregate
    {

        TId Id { get; set; }
        
        /// <summary>
        /// 对应的数据库表名称
        /// </summary>
        String DbTableName { get; }

    }


}
