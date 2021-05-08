using EOD.Synchronizer.Infrastructure.Tables;
using System;

namespace EOD.Synchronizer.Repository
{
    public interface IEodDbRepo
    {
        Contractor GetContractorById(Guid contractorId);
        void AddNewContractor(Contractor newContractor);
        void UpdateContractor(Contractor updatedContractor);
    }
}
