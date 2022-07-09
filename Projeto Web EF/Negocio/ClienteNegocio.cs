using Projeto_Web_EF.Contexto;
using Projeto_Web_EF.Entidades;

namespace Projeto_Web_EF.Negocio
{
    public class ClienteNegocio
    {
        private readonly EFContexto _contexto;

        public ClienteNegocio(EFContexto contexto)
        {
            this._contexto = contexto;
        }

        public Cliente PesquisarPorId(int id)
        {
            //validacoes
            return _contexto.Cliente.Find(id);
        }

        public List<Cliente> PesquisarTodos()
        {
            //validacoes
            return _contexto.Cliente.ToList();
        }

        public string Incluir(Cliente cliente)
        {
            List<Cliente> lista = PesquisarTodos();
            
            string resultado = "";

            if (cliente.Nome == null)
            {
                resultado = "Preencha o Nome";
            }
            if (cliente.Cpf == null)
            {
                resultado = "Preencha a Cpf";
            }
            if (cliente.NomeMae == null)
            {
                resultado = "Preencha o NomeMae";
            }
            else
            {
                _contexto.Cliente.Add(cliente);
                _contexto.SaveChanges();
            }

            return resultado;

        }

        public string Atualizar(Cliente cliente)
        {
            List<Cliente> lista = PesquisarTodos();
            
            string resultado = "";

            if (cliente.Nome == null)
            {
                resultado = "Preencha o Nome";
            }
            if (cliente.Cpf == null)
            {
                resultado = "Preencha a Cpf";
            }
            if (cliente.NomeMae == null)
            {
                resultado = "Preencha o NomeMae";
            }
            else
            {
                _contexto.Cliente.Update(cliente);
                _contexto.SaveChanges();
            }

            return resultado;

        }
        public string Excluir(Cliente cliente)
        {
            //validacoes
            _contexto.Cliente.Remove(cliente);
            _contexto.SaveChanges();
            return "ok";
        }
    }
}
