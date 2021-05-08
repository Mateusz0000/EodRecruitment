using EOD.Synchronizer.Infrastructure.Tables;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOD.Synchronizer.Infrastructure
{
    internal class EodDbContext : DbContext
    {
        public EodDbContext() : 
            base("name=EodDb")
        {

        }

        DbSet<Contractor> Contractors { get; set; }
    }
}
