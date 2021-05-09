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
            try
            {
                newContractor.Created = DateTime.Now;

                using (var ctx = _dbContextFactory.Create())
                {
                    ctx.Contractors.Add(newContractor);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Contractor GetContractorById(Guid contractorId)
        {
            try
            {
                using (var ctx = _dbContextFactory.Create())
                {
                    return ctx.Contractors.SingleOrDefault(c => c.Id == contractorId);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public void UpdateContractor(Contractor updatedContractor)
        {
            throw new NotImplementedException();
        }
    }
}
