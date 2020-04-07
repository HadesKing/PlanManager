using Ld.PlanMangager.Domain.Plan;
using Ld.PlanMangager.Repository.Interface;
using Ld.PlanMangager.Repository.Interface.Plan;
using System;

namespace Ld.PlanMangager.Repository.Plan
{
    /// <summary>
    /// 每日计划 仓储
    /// </summary>
    public sealed class DailyPlannerRepository : BaseRepository, IPlanTypeRepository<Domain.Plan.DailyPlanner>
    {
        public bool Add(DailyPlanner entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(DailyPlanner entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(DailyPlanner entity)
        {
            throw new NotImplementedException();
        }

    }
}
