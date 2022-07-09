using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_Web_EF.Contexto;
using Projeto_Web_EF.Entidades;
using Projeto_Web_EF.Negocio;

namespace Projeto_Web_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarroApiController : ControllerBase
    {
        private readonly EFContexto _context;
        public CarroApiController(EFContexto context)
        {
            _context = context;
        }
        //Detalhes do Carro 
        [HttpGet]
        [Route("{id}")]
        public JsonResult PesquisarCarro(int id)
        {
            var carro = new CarroNegocio(_context).PesquisarPorId(id);
            return new JsonResult(carro);
        }

        [HttpPost]
        public JsonResult IncluirCarro(Carro carro)
        {
            var mensagem = new CarroNegocio(_context).Incluir(carro);
            return new JsonResult(mensagem);
        }

        [HttpPut]
        public JsonResult AtualizarCarro(Carro carro)
        {
            new CarroNegocio(_context).Atualizar(carro);
            return new JsonResult("Atualizado com sucesso");
        }

        
        [HttpDelete]
        [Route("{id}")]
        public JsonResult DeletarCarro(int id)
        {
            new CarroNegocio(_context).Excluir(new Carro { Id = id });
            return new JsonResult("Deletado com Sucesso");
        }

    }
}
