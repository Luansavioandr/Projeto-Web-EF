using Projeto_Web_EF.Contexto;
using Projeto_Web_EF.Entidades;

namespace Projeto_Web_EF.Negocio
{
    public class EnderecoNegocio
    {
        private readonly EFContexto _contexto;

        public EnderecoNegocio(EFContexto contexto)
        {
            this._contexto = contexto;
        }

        public Endereco PesquisarPorId(int id)
        {
            //validacoes
            return _contexto.Endereco.Find(id);
        }

        public List<Endereco> PesquisarTodos()
        {
            //validacoes
            return _contexto.Endereco.ToList();
        }

        public string Incluir(Endereco endereco)
        {
            List<Endereco> lista = PesquisarTodos();

            string resultado = "";

            if (endereco.Rua == null)
            {
                resultado = "Preencha o Nome da Rua";
            }
            if (endereco.Bairro == null)
            {
                resultado = "Preencha o Bairro";
            }
            if (endereco.Cidade == null)
            {
                resultado = "Preencha a Cidade";
            }
            else
            {
                _contexto.Endereco.Add(endereco);
                _contexto.SaveChanges();
            }

            return resultado;

        }

        public string Atualizar(Endereco endereco)
        {
            List<Endereco> lista = PesquisarTodos();

            string resultado = "";

            if (endereco.Rua == null)
            {
                resultado = "Preencha o Nome da Rua";
            }
            if (endereco.Bairro == null)
            {
                resultado = "Preencha o Bairro";
            }
            if (endereco.Cidade == null)
            {
                resultado = "Preencha a Cidade";
            }
            else
            {
                _contexto.Endereco.Update(endereco);
                _contexto.SaveChanges();
            }

            return resultado;

        }
        public string Excluir(Endereco endereco)
        {
            //validacoes
            _contexto.Endereco.Remove(endereco);
            _contexto.SaveChanges();
            return "ok";
        }
    }
}

