using System;
using System.Collections.Generic;
using System.Text;

namespace Ld.PlanMangager.Application.Dto.Plan
{
    public sealed class PlanTypeDto
    {

        public Int32 Id { get; set; }

        public String Name { get; set; }

        public Int32 Level { get; set; }

        public String Description { get; set; }

        public String Remark { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime LastUpdateTime { get; set; }

    }
}
