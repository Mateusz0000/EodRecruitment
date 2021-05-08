using ERP.Api.Dtos;
using System;
using System.Collections.Generic;

namespace ERP.Api.Services
{
    internal sealed class DataService : IDataService
    {
        public List<ContractorDataDto> GetContractorListByDate(DateTime date)
        {
            return new List<ContractorDataDto>();
            //throw new NotImplementedException();
        }
    }
}
