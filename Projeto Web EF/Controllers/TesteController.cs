using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_Web_EF.Contexto;
using Projeto_Web_EF.Entidades;

namespace Projeto_Web_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TesteController : ControllerBase
    {
        private readonly EFContexto _context;

        public TesteController(EFContexto context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("{nome}/{nomee}")]
        public JsonResult GetTeste(string nome, string nomee)
        {
            return new JsonResult(nome + " " + nomee);
        }


        [HttpPost]
        public JsonResult PostTeste(Carro carro)
        {

            return new JsonResult("Mensagem Post Recebida: " + carro.Nome);
        }

        [HttpPut]
        public JsonResult PutTeste(Carro carro)
        {

            return new JsonResult("Mensagem Post Recebida: " + carro.Nome);
        }

        [HttpDelete]
        [Route("{id}")]
        public JsonResult DeleteTeste(int id)
        {

            return new JsonResult("Vamos deletar o: " + id);
        }
    }
}
