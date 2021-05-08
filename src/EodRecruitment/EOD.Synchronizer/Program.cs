using EOD.Synchronizer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace EOD.Synchronizer
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(configure =>
            {
                configure.Service<EodSynchronizerService>(service =>
                {
                    service.ConstructUsing(s => new EodSynchronizerService());
                    service.WhenStarted(s => s.Start());
                    service.WhenStopped(s => s.Stop());
                });
                configure.RunAsLocalSystem();
                configure.SetServiceName("EODSynchronizer");
                configure.SetDisplayName("EOD Synchronizer");
                configure.SetDescription("Usługa synchronizująca dane pomiędzy bazami ERP i EOD.");
            });
        }
    }
}
