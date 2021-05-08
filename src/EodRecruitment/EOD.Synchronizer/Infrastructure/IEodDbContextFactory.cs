namespace EOD.Synchronizer.Infrastructure
{
    internal interface IEodDbContextFactory
    {
        EodDbContext Create();
    }
}