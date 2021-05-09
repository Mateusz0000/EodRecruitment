using System;
using System.ComponentModel.DataAnnotations;

namespace EOD.Synchronizer.Infrastructure.Tables
{
    public class AuditRecord
    {
        public DateTime Created { get; set; } // #DateTime
        [StringLength(450)]
        public string CreatedBy { get; set; } // #Varchar(450) uzupełniamy wartością stałą “KontoSystemowe”
        public DateTime? Modified { get; set; } // #DateTime
        [StringLength(450)]
        public string ModifiedBy { get; set; } // #Varchar(450) uzupełniamy wartością stałą “KontoSystemowe”
        public bool? Removed { get; set; } // #Boolean, null
        public bool? Archived { get; set; } // #Boolean, null

        public bool? Cancelled { get; set; } // #Boolean, null
        public bool? Rejected { get; set; } // #Boolean, null

        public string Zrodlo { get; set; } // #źródło wartość stała dla systemu z którego pobierane są dane
        public Guid IdentyfikatorZrodla { get; set; } // #identyfikator unikatowy dla systemu z którego pobierane są dane

        public void MarkAsNew(string bySomebody)
        {
            Created = DateTime.Now;
            CreatedBy = bySomebody;
            Zrodlo = "ERP";
            IdentyfikatorZrodla = Guid.Empty;
        }

        public void MarkAsUpdated(string bySomebody)
        {
            Modified = DateTime.Now;
            ModifiedBy = bySomebody;
        }
    }
}