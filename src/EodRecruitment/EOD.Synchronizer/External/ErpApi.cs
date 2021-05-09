using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using RestEase;
using EOD.Synchronizer.External.Models;

namespace EOD.Synchronizer.External.Api
{
    /// <summary>
    /// Api umożliwiające pobieranie danych z systemu ERP.
    /// </summary>
    public interface IErpApiApi
    {
        [Query("date")]
        DateTime? Date { get; set; }

        /// <summary>
        /// Pobierz dane kontrahentów na dany dzień
        /// </summary>
        [Get("/api/Contractor")]
        Task<ContractorDataDto[]> GetApiContractorAsync();
    }
}

namespace EOD.Synchronizer.External.Models
{
    public class ContractorDataDto
    {
        public Guid Id { get; set; }

        public string NipNumber { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }
    }
}

namespace EOD.Synchronizer.External.Models
{
    public class ProblemDetails
    {
        public string Type { get; set; }

        public string Title { get; set; }

        public int? Status { get; set; }

        public string Detail { get; set; }

        public string Instance { get; set; }
    }
}
