using Microsoft.AspNetCore.Mvc;
using dotnet_CI.Services;

namespace dotnet_CI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WordleController : ControllerBase
    {
        private readonly WordleService _service = new WordleService();

        [HttpGet("check")]
        public IActionResult Check([FromQuery] string palabra)
        {
            if (string.IsNullOrWhiteSpace(palabra) || palabra.Length != 5)
                return BadRequest("La palabra debe tener 5 letras.");

            var resultado = _service.Verificar(palabra);
            return Ok(resultado);
        }
    }
}
