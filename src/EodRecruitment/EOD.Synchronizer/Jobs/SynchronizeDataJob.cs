using AutoMapper;
using EOD.Synchronizer.Dtos;
using EOD.Synchronizer.Infrastructure.Tables;
using EOD.Synchronizer.Repository;
using Newtonsoft.Json;
using Quartz;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace EOD.Synchronizer.Jobs
{
    [DisallowConcurrentExecution]
    public class SynchronizeDataJob : IJob
    {
        private readonly IEodDbRepo _eodDbRepo;
        private readonly IMapper _mapper;
        private HttpClient _httpClient;

        public SynchronizeDataJob(IEodDbRepo eodDbRepo, IMapper mapper)
        {
            _eodDbRepo = eodDbRepo ?? throw new ArgumentNullException(nameof(eodDbRepo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _httpClient = new HttpClient();
        }

        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine($"Uruchomiono joba - {DateTime.Now}");

            try
            {
                _httpClient.BaseAddress = new Uri("https://localhost:44387/api/Contractor");
                HttpResponseMessage response = _httpClient.GetAsync("?date=2021-05-06").Result;
                response.EnsureSuccessStatusCode();
                string responseBody = response.Content.ReadAsStringAsync().Result;
                var contractorsList = JsonConvert.DeserializeObject<List<ContractorDataDto>>(responseBody);

                foreach (var contractor in contractorsList)
                {
                    var existedContractor = _eodDbRepo.GetContractorById(contractor.Id);

                    if (existedContractor == null)
                    {
                        var newContractor = _mapper.Map<Contractor>(contractor);
                        newContractor.MarkAsNew("KontoSystemowe");
                        _eodDbRepo.AddNewContractor(newContractor);
                    }
                    else
                    {
                        //porównaj
                    }
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Message :{e.Message} ");
            }
        }
    }
}
