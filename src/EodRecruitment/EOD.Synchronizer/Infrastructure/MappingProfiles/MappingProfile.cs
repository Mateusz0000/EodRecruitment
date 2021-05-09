using AutoMapper;
using EOD.Synchronizer.Dtos;
using EOD.Synchronizer.Infrastructure.Tables;

namespace EOD.Synchronizer.Infrastructure.MappingProfiles
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ContractorDataDto, Contractor>();
        }
    }
}
