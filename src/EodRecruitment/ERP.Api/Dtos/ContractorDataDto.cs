using System;
using System.ComponentModel.DataAnnotations;

namespace ERP.Api.Dtos
{
    public class ContractorDataDto
    {
        public Guid Id { get; set; }
        [StringLength(10)]
        public string NipNumber { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
    }
}