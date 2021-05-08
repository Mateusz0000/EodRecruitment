using EOD.Synchronizer.Infrastructure;
using EOD.Synchronizer.Repository;
using Ninject.Modules;
using Quartz;

namespace EOD.Synchronizer
{
    public class Installer : NinjectModule
    {
        public override void Load()
        {
            Bind<IEodDbContextFactory>().To<EodDbContextFactory>().InTransientScope();
            Bind<IEodDbRepo>().To<EodDbRepo>().InTransientScope();
            Bind<IJob>().ToSelf().InTransientScope();
        }
    }
}
