using Ld.PlanMangager.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ld.PlanMangager.Domain.Plan
{
    public sealed partial class PlanType : BaseEntity<Int32>, IEntity<Int32>
    {

        public override string DbTableName => "PlanType";

        public String Name { get; set; }

        public Int32 Level { get; set; }

    }
}
