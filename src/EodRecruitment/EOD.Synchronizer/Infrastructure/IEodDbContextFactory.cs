using System.Data.Entity.Infrastructure;

namespace EOD.Synchronizer.Infrastructure
{
    internal interface IEodDbContextFactory : IDbContextFactory<EodDbContext>
    {
    }
}