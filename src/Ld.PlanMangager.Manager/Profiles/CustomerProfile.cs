using AutoMapper;
using Ld.PlanMangager.Application.Dto.Plan;
using Ld.PlanMangager.Domain.Plan;
using Ld.PlanMangager.Repository.Interface.Plan;

namespace Ld.PlanMangager.Manager.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<PlanType, PlanTypeDto>()
                .ConstructUsing(user => new PlanTypeDto())
                .ReverseMap()
                .ConstructUsing(userDto => new PlanType(Resolve IPlanTypeRepository<PlanType>));
        }

	}
}
