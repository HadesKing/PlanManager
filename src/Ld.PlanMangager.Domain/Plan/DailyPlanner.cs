using Ld.PlanMangager.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ld.PlanMangager.Domain.Plan
{
    public sealed partial class DailyPlanner : BaseEntity<String>, IEntity<String>
    {


        public String Date { get; set; }

        public Int32 PlanTypeId { get; set; }

        /// <summary>
        /// 计划花费时间，单位：分钟
        /// </summary>
        public Int32 PlanSpendTimes { get; set; }

    }
}
