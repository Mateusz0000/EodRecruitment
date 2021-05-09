using AutoMapper;
using EOD.Synchronizer.External.Models;
using EOD.Synchronizer.Infrastructure.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
