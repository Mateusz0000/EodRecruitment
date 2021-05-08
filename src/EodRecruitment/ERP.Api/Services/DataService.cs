using ERP.Api.Dtos;
using ERP.Api.Exceptions;
using ERP.Api.Mock;
using System;
using System.Collections.Generic;

namespace ERP.Api.Services
{
    internal sealed class DataService : IDataService
    {
        private readonly IContractorGenerator _contractorGenerator;

        public DataService(IContractorGenerator contractorGenerator)
        {
            _contractorGenerator = contractorGenerator ?? throw new ArgumentNullException(nameof(contractorGenerator));
        }

        public List<ContractorDataDto> GetContractorListByDate(DateTime date)
        {
            var gotData = new List<ContractorDataDto>();
            string dateString = date.ToString("yyyy-MM-dd");

            switch (dateString)
            {
                case "2021-05-06":
                    gotData.AddRange(GetMockedData6thMay());
                    break;

                case "2021-05-07":
                    gotData.AddRange(GetMockedData7thMay());
                    break;

                case "2021-05-08":
                    gotData.AddRange(GetMockedData8thMay());
                    break;

                default:
                    throw new EmptyContractorsListException("Brak danych kontrahentów na dany dzień.");
            }

            return gotData;
        }

        private List<ContractorDataDto> GetMockedData6thMay()
            => _contractorGenerator.GetDataOn6thMay(5);

        private List<ContractorDataDto> GetMockedData7thMay()
            => _contractorGenerator.GetDataOn7thMay(5, 2);

        private List<ContractorDataDto> GetMockedData8thMay()
            => _contractorGenerator.GetDataOn8thMay(5, 3);
    }
}
