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
    public class Contractor : AuditRecord
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(10)]
        [Column("NIP")]
        public string NipNumber { get; set; }// #Varchar(10)
        [StringLength(450)] 
        [Column("Nazwa")]
        public string Name { get; set; }// #Varchar(450)
        [StringLength(450)]
        [Column("Miasto")]
        public string City { get; set; }// #Varchar(450)
        [StringLength(450)]
        [Column("KodPocztowy")]
        public string PostalCode { get; set; }// #Varchar(450)
        [StringLength(450)]
        [Column("Ulica")]
        public string Street { get; set; }// #Varchar(450)
        [StringLength(100)]
        [Column("Numer")]
        public string Number { get; set; } // #Varchar(100)
    }
}
