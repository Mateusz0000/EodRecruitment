using System;
using System.Configuration;

namespace EOD.Synchronizer.Infrastructure
{
    internal class EodDbContextFactory : IEodDbContextFactory
    {
        public EodDbContextFactory()
        {

        }

        public EodDbContext Create()
        {
            return new EodDbContext();
        }
    }
}
