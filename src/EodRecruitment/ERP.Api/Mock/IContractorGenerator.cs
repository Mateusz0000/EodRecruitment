using ERP.Api.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Api.Mock
{
    internal interface IContractorGenerator
    {
        List<ContractorDataDto> GetDataOn6thMay(int numberOfNewContractors);
        List<ContractorDataDto> GetDataOn7thMay(int numberOfNewContractors, int numberOfChangedContractors = 0);
        List<ContractorDataDto> GetDataOn8thMay(int numberOfNewContractors, int numberOfChangedContractors = 0);
    }
}
