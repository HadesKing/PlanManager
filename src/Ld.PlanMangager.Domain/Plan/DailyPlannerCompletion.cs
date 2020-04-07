using Ld.PlanMangager.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ld.PlanMangager.Domain.Plan
{
    public sealed partial class DailyPlannerCompletion : BaseDomain, IEntity<Int32>
    {
        public int Id { get; set; }

        public string DbTableName => "DailyPlannerCompletion";



    }
}
