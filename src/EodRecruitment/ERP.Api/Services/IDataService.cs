using ERP.Api.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Api.Services
{
    public interface IDataService
    {
        List<ContractorDataDto> GetContractorListByDate(DateTime date);
    }
}
