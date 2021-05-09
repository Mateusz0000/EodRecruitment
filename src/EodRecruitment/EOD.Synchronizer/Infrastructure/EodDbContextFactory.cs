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
            string connectionString = ConfigurationManager.ConnectionStrings["EodDb"].ConnectionString;

            return new EodDbContext(connectionString);
        }
    }
}
