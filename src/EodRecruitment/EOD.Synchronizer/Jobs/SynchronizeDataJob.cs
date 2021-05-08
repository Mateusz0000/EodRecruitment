using EOD.Synchronizer.Repository;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOD.Synchronizer.Jobs
{
    [DisallowConcurrentExecution]
    public class SynchronizeDataJob : IJob
    {
        private readonly IEodDbRepo _eodDbRepo;

        public SynchronizeDataJob(IEodDbRepo eodDbRepo)
        {
            _eodDbRepo = eodDbRepo ?? throw new ArgumentNullException(nameof(eodDbRepo));
        }

        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine($"Uruchomiono joba - {DateTime.Now}");
        }
    }
}
