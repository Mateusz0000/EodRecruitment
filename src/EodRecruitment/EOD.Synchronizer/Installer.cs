﻿using EOD.Synchronizer.Infrastructure;
using EOD.Synchronizer.Jobs;
using EOD.Synchronizer.Repository;
using Ninject;
using Ninject.Modules;
using Quartz;
using Quartz.Impl;

namespace EOD.Synchronizer
{
    public static class Installer
    {
        public static IKernel InitializeKernel()
        {
            var kernel = new StandardKernel();

            kernel.Bind<IScheduler>().ToMethod(x =>
            {
                var sched = new StdSchedulerFactory().GetScheduler();
                sched.JobFactory = new JobFactory(kernel);
                return sched;
            });
            kernel.Bind<IEodDbContextFactory>().To<EodDbContextFactory>().InTransientScope();
            kernel.Bind<IEodDbRepo>().To<EodDbRepo>().InTransientScope();
            kernel.Bind<IJob>().ToSelf().InTransientScope();

            return kernel;
        }
    }
}
