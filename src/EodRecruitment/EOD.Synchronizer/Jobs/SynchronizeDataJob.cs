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
            try
            {
                if (DateList.Dates.Count == 0)
                {
                    Console.WriteLine("Brak terminów do uruchomienia joba :)");
                    return;
                }

                var today = DateList.Dates[0];
                Console.WriteLine($"Uruchomiono joba - {DateTime.Now} na dzień {today}");

                _httpClient.BaseAddress = new Uri("https://localhost:44387/api/Contractor");
                HttpResponseMessage response = _httpClient.GetAsync($"?date={today}").Result;
                string responseBody = response.Content.ReadAsStringAsync().Result;

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException(responseBody);
                }

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
                        existedContractor.UpdateData(contractor);
                        _eodDbRepo.UpdateContractor(existedContractor);
                    }
                }

                DateList.Dates.RemoveAt(0);
                Console.WriteLine($"Zakończono działanie joba - {DateTime.Now} na dzień {today}");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Message :{e.Message} ");
                DateList.Dates.RemoveAt(0);
            }
        }
    }
}
