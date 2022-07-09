using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Projeto_Web_EF.Models;

namespace Projeto_Web_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculadoraController : ControllerBase
    {
        [HttpGet]
        [Route("{num1}/{num2}")]
        public JsonResult SomarValores(long num1, long num2)
        {
            return new JsonResult(num1 + num2);
        }

        [HttpPost]
        public JsonResult SubtrairValores(Calculadora obj)
        {
            return new JsonResult(obj.Numero1 - obj.Numero2);
        }

        [HttpPut]
        public JsonResult MultiplicarValores(Calculadora obj)
        {
            return new JsonResult(obj.Numero1 * obj.Numero2);
        }

        [HttpDelete]
        [Route("{num1}/{num2}")]
        public JsonResult DividirValores(long num1, long num2)
        {
            return new JsonResult(num1 / num2);
        }
    }
}
