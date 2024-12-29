using GerenciadorDeTarefas.Integration;
using GerenciadorDeTarefas.Integration.Interfaces;
using GerenciadorDeTarefas.Integration.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

namespace GerenciadorDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CepController : ControllerBase
    {
        private readonly IViaCepIntegration _viaCepIntegration;
        public CepController(IViaCepIntegration viaCepIntegration)
        {
            _viaCepIntegration = viaCepIntegration;
        }

        /// <summary>
        /// Get all the address data.
        /// </summary>
        /// <param name="cep"></param>
        /// <returns></returns>
        /// <response code="200">Return the address information.</response>
        /// <response code="400">The address information is invalid.</response>
        /// <response code="500">Server error.</response>
        [HttpGet("{cep}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ViaCepResponse>> GetAllDataAddress(string cep)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cep) || !Regex.IsMatch(cep, @"^\d{5}-?\d{3}$"))
                {
                    return BadRequest(new { message = "Cep format is invalid. Must have 8 digits." });
                }

                var responseData = await _viaCepIntegration.GetDatasViaCep(cep);

                if (responseData == null || string.IsNullOrWhiteSpace(responseData.Cep)) 
                {
                    return BadRequest(new { message = "Cep não encontrado!" });
                }
                return Ok(responseData);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new {message="Error to find the CEP."});
            }
        }
    }
}
