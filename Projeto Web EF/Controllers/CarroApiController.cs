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
            var mensagempesquisar = new CarroNegocio(_context).PesquisarPorId(id);
            return new JsonResult(mensagempesquisar);
        }

        //Adicionar um Carro
        [HttpPost]
        public JsonResult IncluirCarro(Carro carro)
        {
            string mensagemincluir = new CarroNegocio(_context).Incluir(carro);
            return new JsonResult(mensagemincluir);
        }

        //Editar um Carro
        [HttpPut]
        public JsonResult AtualizarCarro(Carro carro)
        {
            string mensagematualizar = new CarroNegocio(_context).Atualizar(carro);
            return new JsonResult(mensagematualizar);
        }

        //Deletar um Carro
        [HttpDelete]
        [Route("{id}")]
        public JsonResult DeletarCarro(int id)
        {
            string mensagemdeletar = new CarroNegocio(_context).Excluir(new Carro { Id = id });
            return new JsonResult(mensagemdeletar);
        }

    }
}
