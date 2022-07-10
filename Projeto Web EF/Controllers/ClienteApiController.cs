using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto_Web_EF.Contexto;
using Projeto_Web_EF.Entidades;
using Projeto_Web_EF.Negocio;

namespace Projeto_Web_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteApiController : ControllerBase
    {
        public readonly EFContexto _context;
        public ClienteApiController(EFContexto context)
        {
            _context = context;
        }
        //Detalhes do Cliente
        [HttpGet]
        [Route("{Id}")]
        public JsonResult PesquisarCliente(int id)
        {
            var mensagempesquisar = new ClienteNegocio(_context).PesquisarPorId(id);
            return new JsonResult(mensagempesquisar);
        }

        //Adicionar um Cliente
        [HttpPost]
        public JsonResult IncluirCliente(Cliente cliente)
        {
            string mensagemincluir = new ClienteNegocio(_context).Incluir(cliente);
            return new JsonResult(mensagemincluir);
        }

        //Editar um Cliente
        [HttpPut]
        public JsonResult AtualizarCliente(Cliente cliente)
        {
            string mensagematualizar = new ClienteNegocio(_context).Atualizar(cliente);
            return new JsonResult(mensagematualizar);
        }

        //Excluit um Cliente
        [HttpDelete]
        [Route("{Id}")]
        public JsonResult DeletarCliente(int Id)
        {
            var objetocliente = new ClienteNegocio(_context).PesquisarPorId(Id);
            string mensagemdeletar = new ClienteNegocio(_context).Excluir(objetocliente);
            return new JsonResult(mensagemdeletar);
        }





    }
}
