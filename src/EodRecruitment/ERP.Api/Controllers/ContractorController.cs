using ERP.Api.Dtos;
using ERP.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Endpont do pobierania danych kontrahentów z bazy systemu ERP")]
    public class ContractorController : ControllerBase
    {
        private readonly IDataService _dataService;

        public ContractorController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        [SwaggerOperation("Pobierz dane kontrahentów na dany dzień", "Metoda umożliwiająca pobranie danych kontrahentów na wskazany dzień w postaci listy.")]
        [SwaggerResponse(StatusCodes.Status200OK, "Dane kontrahenta", typeof(List<ContractorDataDto>))]
        public async Task<IActionResult> Get([SwaggerParameter("Dzień, na który pobrać dane")] DateTime date)
        {
            var contractorList = _dataService.GetContractorListByDate(date);

            return Ok(contractorList);
        }
    }
}
