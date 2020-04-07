using Ld.PlanMangager.Repository.Interface.Plan;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ld.PlanMangager.Application.Plan
{
    public sealed class DailyPlannerApplication
    {

        private readonly IDailyPlannerRepository m_dailyPlannerRepository;

        public DailyPlannerApplication(IDailyPlannerRepository dailyPlannerRepository)
        {
            m_dailyPlannerRepository = dailyPlannerRepository;
        }



    }
}
