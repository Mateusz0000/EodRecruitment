using EOD.Synchronizer.Jobs;
using EOD.Synchronizer.Repository;
using Ninject;
using Quartz;
using Quartz.Impl;
using System;
using System.Configuration;
using System.Reflection;

namespace EOD.Synchronizer.Service
{
    public class EodSynchronizerService
    {
        private IScheduler _scheduler;
        private IKernel _kernel;

        public EodSynchronizerService()
        {
        }

        public void Start()
        {
            Console.WriteLine("Uruchomiono usługe EOD Synchronizer");

            _kernel = Installer.InitializeKernel();

            _scheduler = _kernel.Get<IScheduler>();
            _scheduler.Start();

            IJobDetail job = JobBuilder.Create<SynchronizeDataJob>()
                .WithIdentity("SynchronizeDataJob", "SynchronizerGroup")
                .Build();

            string cronSchedule = ConfigurationManager.AppSettings["QuartzCron"];
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("SynchronizerTrigger", "SynchronizerGroup")
                .StartAt(DateTime.Now.AddSeconds(15))
                .WithCronSchedule(cronSchedule)
                .Build();

            _scheduler.ScheduleJob(job, trigger);
        }

        public void Stop()
        {
            Console.WriteLine("Zatrzymywanie usługi EOD Synchronizer");

            _scheduler.Shutdown(true);
            _kernel.Dispose();
        }
    }
}
