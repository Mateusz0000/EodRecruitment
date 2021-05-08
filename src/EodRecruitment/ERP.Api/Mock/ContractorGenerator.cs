using AutoFixture;
using ERP.Api.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ERP.Api.Mock
{
    internal class ContractorGenerator : IContractorGenerator
    {
        private Fixture _fixture;
        private List<ContractorDataDto> _may6thContractors;
        private List<ContractorDataDto> _may7thContractors;
        private List<ContractorDataDto> _may8thContractors;

        public ContractorGenerator()
        {
            _fixture = new Fixture();
            _may6thContractors = new List<ContractorDataDto>();
            _may7thContractors = new List<ContractorDataDto>();
            _may8thContractors = new List<ContractorDataDto>();
        }

        public List<ContractorDataDto> GetDataOn6thMay(int numberOfNewContractors)
        {
            if (_may6thContractors.Count == 0)
            {
                var data = GetNewMockedData(numberOfNewContractors);
                _may6thContractors.AddRange(data);
            }

            return _may6thContractors;
        }

        public List<ContractorDataDto> GetDataOn7thMay(int numberOfNewContractors, int numberOfContractorsToChange = 0)
        {
            if (_may7thContractors.Count == 0)
            {
                var newData = GetNewMockedData(numberOfNewContractors);
                _may7thContractors.AddRange(_may6thContractors);

                if (numberOfContractorsToChange > 0)
                {
                    ChangeRecords(numberOfContractorsToChange, ref _may7thContractors);
                }

                _may7thContractors.AddRange(newData);
            }

            return _may7thContractors;
        }

        public List<ContractorDataDto> GetDataOn8thMay(int numberOfNewContractors, int numberOfContractorsToChange = 0)
        {
            if (_may8thContractors.Count == 0)
            {
                var newData = GetNewMockedData(numberOfNewContractors);
                _may8thContractors.AddRange(_may7thContractors);

                if (numberOfContractorsToChange > 0)
                {
                    ChangeRecords(numberOfContractorsToChange, ref _may8thContractors);
                }

                _may8thContractors.AddRange(newData);
            }

            return _may8thContractors;
        }

        #region private methods
        private List<ContractorDataDto> GetNewMockedData(int numberOfNewContractors)
            =>  _fixture.CreateMany<ContractorDataDto>(numberOfNewContractors).ToList();

        private void ChangeRecords(int numberOfContractorsToChange, ref List<ContractorDataDto> changedContractorsList)
        {
            var random = new Random();

            for (int i = 0; i < numberOfContractorsToChange; i++)
            {
                var itemToChange = random.Next(0, _may6thContractors.Count - 1);
                changedContractorsList[itemToChange].Name = $"Nowa nazwa kontrahenta-{i}";
            }
        }

#endregion
    }
}
