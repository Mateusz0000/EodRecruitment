using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOD.Synchronizer.Infrastructure.Tables
{
    [Table("Kontrahenci")]
    public class Contractor
    {
        [Key]
        public Guid Id { get; set; }
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
        [StringLength(10)] 
        public string NIP { get; set; }// #Varchar(10)
        [StringLength(450)] 
        public string Nazwa { get; set; }// #Varchar(450)
        [StringLength(450)] 
        public string Miasto { get; set; }// #Varchar(450)
        [StringLength(450)] 
        public string KodPocztowy { get; set; }// #Varchar(450)
        [StringLength(450)] 
        public string Ulica { get; set; }// #Varchar(450)
        [StringLength(100)] 
        public string Numer { get; set; } // #Varchar(100)
    }
}
