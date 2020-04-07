using Ld.PlanMangager.Repository.Interface.Interface;
using System;

namespace Ld.PlanMangager.Repository.Interface.Plan
{
    public interface IDailyPlannerRepository<TEntity> : IRepository<TEntity> where TEntity : class, IAggregate, new()
    {


    }
}
