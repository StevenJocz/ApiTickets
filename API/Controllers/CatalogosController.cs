using Microsoft.AspNetCore.Mvc;
using Persistence.Queries;


namespace Tickets.Controllers
{
    [Route("api/catalogos")]
    [ApiController]
    public class CatalogosController : ControllerBase
    {
        private readonly ICatalogoQueries _catalogoQueries;

        public CatalogosController(ICatalogoQueries catalogoQueries)
        {
            _catalogoQueries = catalogoQueries;
        }

        [HttpGet("areas")]
        public async Task<IActionResult> ObtenerAreas()
        {
            var areas = await _catalogoQueries.ObtenerAreasAsync();
            return Ok(areas);
        }


        [HttpGet("prioridades")]
        public async Task<IActionResult> ObtenerPrioridades()
        {
            var prioridades = await _catalogoQueries.ObtenerPrioridadesAsync();
            return Ok(prioridades);
        }


        [HttpGet("estados")]
        public async Task<IActionResult> ObtenerEstados()
        {
            var estados = await _catalogoQueries.ObtenerEstadosAsync();
            return Ok(estados);
        }
    }
}
