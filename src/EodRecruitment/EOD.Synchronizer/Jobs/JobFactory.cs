using Ninject;
using Quartz;
using Quartz.Simpl;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOD.Synchronizer.Jobs
{
    internal class JobFactory : SimpleJobFactory
    {
        private readonly IKernel _kernel;

        public JobFactory(IKernel kernel)
        {
            _kernel = kernel ?? throw new ArgumentNullException(nameof(kernel));
        }

        public override IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            try
            {
                return (IJob)_kernel.Get(bundle.JobDetail.JobType);
            }
            catch (Exception e)
            {
                throw new SchedulerException(string.Format("Błąd przy tworzeniu joba - ", bundle.JobDetail.Key), e);
            }
        }
    }
}
