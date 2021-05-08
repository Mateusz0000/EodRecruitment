using EOD.Synchronizer.Infrastructure;
using EOD.Synchronizer.Infrastructure.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOD.Synchronizer.Repository
{
    internal class EodDbRepo : IEodDbRepo
    {
        private readonly IEodDbContextFactory _dbContextFactory;

        public EodDbRepo(IEodDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory ?? throw new ArgumentNullException(nameof(dbContextFactory));
        }

        public void AddNewContractor(Contractor newContractor)
        {
            throw new NotImplementedException();
        }

        public Contractor GetContractorById(Guid contractorId)
        {
            throw new NotImplementedException();
        }

        public void UpdateContractor(Contractor updatedContractor)
        {
            throw new NotImplementedException();
        }
    }
}
