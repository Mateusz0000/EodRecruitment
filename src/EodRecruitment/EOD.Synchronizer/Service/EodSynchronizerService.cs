using EOD.Synchronizer.Jobs;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOD.Synchronizer.Service
{
    public class EodSynchronizerService
    {
        private readonly IScheduler _scheduler;

        public EodSynchronizerService()
        {
            _scheduler = new StdSchedulerFactory().GetScheduler().GetAwaiter().GetResult();
        }

        public void Start()
        {
            Console.WriteLine("Uruchomiono usługe EOD Synchronizer");

            _scheduler.Start();

            IJobDetail job = JobBuilder.Create<SynchronizeDataJob>()
                .WithIdentity("SynchronizeDataJob", "SynchronizerGroup")
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("SynchronizerTrigger", "SynchronizerGroup")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(30)
                    .RepeatForever())
                .Build();

            _scheduler.ScheduleJob(job, trigger);
        }

        public void Stop()
        {
            Console.WriteLine("Zatrzymywanie usługi EOD Synchronizer");
            
            _scheduler.Shutdown(true);
        }
    }
}
