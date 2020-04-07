using Ld.PlanMangager.Application.Dto.Plan;
using Ld.PlanMangager.Domain.Plan;
using Ld.PlanMangager.Repository.Interface.Plan;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ld.PlanMangager.Application.Plan
{
    public sealed class PlanTypeApplication
    {
        public PlanTypeApplication()
        {
        }

        public bool Add(PlanTypeDto planTypeDto)
        {
            PlanType planType = new PlanType();
            //planType.Id = planTypeDto.Id;
            planType.Name = planTypeDto.Name;
            planType.Level = planTypeDto.Level;
            planType.Description = planTypeDto.Description;
            planType.Remark = planTypeDto.Remark;
            planType.CreateTime = System.DateTime.UtcNow;

            return planType.Add();
        }

    }
}
