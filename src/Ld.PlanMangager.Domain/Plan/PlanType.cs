using Ld.PlanMangager.Infrastructure.DbTableAttributes;
using Ld.PlanMangager.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ld.PlanMangager.Domain.Plan
{
    [Table("PlanType")]
    public sealed partial class PlanType : BaseEntity<Int32>
    {


        public String Name { get; set; }

        public Int32 Level { get; set; }

    }
}
