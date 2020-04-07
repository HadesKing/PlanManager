using Ld.PlanMangager.Infrastructure.Ioc;
using Ld.PlanMangager.Repository.Interface.Plan;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ld.PlanMangager.Domain.Plan
{
    public sealed partial class DailyPlanner
    {
        private readonly IDailyPlannerRepository<DailyPlanner> m_dailyPlannerRepository;

        public DailyPlanner()
        {
            m_dailyPlannerRepository = IocContainer.Instance.Resolve<IDailyPlannerRepository<DailyPlanner>>();
        }

        public bool Add()
        {
            return m_dailyPlannerRepository.Add(this);
        }


    }
}
