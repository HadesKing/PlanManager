using Ld.PlanMangager.Repository.Interface.Plan;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ld.PlanMangager.Domain.Plan
{
    public sealed partial class DailyPlanner
    {
        private readonly IDailyPlannerRepository m_dailyPlannerRepository;

        public DailyPlanner()
        {

        }

        public DailyPlanner(IDailyPlannerRepository dailyPlannerRepository)
        {
            m_dailyPlannerRepository = dailyPlannerRepository;
        }

        public bool Add()
        {
            StringBuilder sbSql = new StringBuilder();
            sbSql.Append($"INSERT INTO {DbTableName} ");
            sbSql.Append(" ( Id, Date, PlanTypeId, Description, PlanSpendTimes, Remark, CreateTime, LastUpdateTime) ");
            sbSql.Append(" VALUES  ");
            sbSql.Append(" ( @Id, @Date, @PlanTypeId, @Description, @PlanSpendTimes, @Remark, @CreateTime, @LastUpdateTime )");
            sbSql.Append("");

            return m_dailyPlannerRepository.Add(sbSql.ToString(), this);
        }


    }
}
