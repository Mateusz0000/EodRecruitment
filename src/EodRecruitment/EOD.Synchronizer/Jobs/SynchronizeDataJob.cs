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
        public async Task Execute(IJobExecutionContext context)
        {
            await Task.Run(() =>
            {
                Console.WriteLine($"Uruchomiono joba - {DateTime.Now}");
            });
        }
    }
}
