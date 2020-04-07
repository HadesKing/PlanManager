using Ld.PlanMangager.Repository.Interface.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ld.PlanMangager.Repository.Interface.Plan
{
    public interface IPlanTypeRepository<TEntity> : IRepository<TEntity> where TEntity : class, IAggregate
    {


    }
}
