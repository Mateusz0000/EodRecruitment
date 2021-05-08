using EOD.Synchronizer.Jobs;
using Ninject;
using Quartz;
using Quartz.Impl;
using System;

namespace EOD.Synchronizer.Service
{
    public class EodSynchronizerService
    {
        private readonly IScheduler _scheduler;
        private readonly IKernel _container;

        public EodSynchronizerService()
        {
            _scheduler = new StdSchedulerFactory().GetScheduler();
            _container = new StandardKernel();
        }

        public void Start()
        {
            Console.WriteLine("Uruchomiono usługe EOD Synchronizer");

            _container.Load(new Installer());
            _scheduler.Start();

            IJobDetail job = JobBuilder.Create<SynchronizeDataJob>()
                .WithIdentity("SynchronizeDataJob", "SynchronizerGroup")
                .Build();
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("SynchronizerTrigger", "SynchronizerGroup")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(10)
                    .RepeatForever())
                .Build();

            _scheduler.ScheduleJob(job, trigger);
        }

        public void Stop()
        {
            Console.WriteLine("Zatrzymywanie usługi EOD Synchronizer");

            _scheduler.Shutdown(true);
            _container.Dispose();
        }
    }
}
