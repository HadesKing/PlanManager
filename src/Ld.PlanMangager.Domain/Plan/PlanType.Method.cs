using Ld.PlanMangager.Infrastructure.Ioc;
using Ld.PlanMangager.Repository.Interface;
using Ld.PlanMangager.Repository.Interface.Plan;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ld.PlanMangager.Domain.Plan
{
    public partial class PlanType
    {
        private readonly IPlanTypeRepository<PlanType> m_planTypeRepository;

        public PlanType()
        {
            m_planTypeRepository = IocContainer.Instance.Resolve<IPlanTypeRepository<PlanType>>();
        }

        public bool Add()
        {
            return m_planTypeRepository.Add(this);
        }

        public bool Update()
        {
            return m_planTypeRepository.Update(this);
        }

        public bool Delete()
        {
            return m_planTypeRepository.Delete(this);
        }

    }
}
