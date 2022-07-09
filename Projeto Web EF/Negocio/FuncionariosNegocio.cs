using Projeto_Web_EF.Contexto;
using Projeto_Web_EF.Entidades;

namespace Projeto_Web_EF.Negocio
{
    public class FuncionariosNegocio
    {
        private readonly EFContexto _contexto;

        public FuncionariosNegocio(EFContexto contexto)
        {
            this._contexto = contexto;
        }

        public Funcionarios PesquisarPorId(int id)
        {
            //validacoes
            return _contexto.Funcionarios.Find(id);
        }

        public List<Funcionarios> PesquisarTodos()
        {
            //validacoes
            return _contexto.Funcionarios.ToList();
        }

        public string Incluir(Funcionarios funcionarios)
        {
            List<Funcionarios> lista = PesquisarTodos();
          
            string resultado = "";

            if (funcionarios.NomedoFuncionario == null)
            {
                resultado = "Preencha o Nome";
            }
            if (funcionarios.NumerodaCarteiradeTrabalho == null)
            {
                resultado = "Preencha o Numero";
            }
            if (funcionarios.Cpf == null)
            {
                resultado = "Preencha o Cpf";
            }
            if (funcionarios.Função == null)
            {
                resultado = "Preencha a Função";
            }
            else
            {
                _contexto.Funcionarios.Add(funcionarios);
                _contexto.SaveChanges();
            }

            return resultado;

        }

        public string Atualizar(Funcionarios funcionarios)
        {
            List<Funcionarios> lista = PesquisarTodos();
            
            string resultado = "";

            if (funcionarios.NomedoFuncionario == null)
            {
                resultado = "Preencha o Nome";
            }
            if (funcionarios.NumerodaCarteiradeTrabalho == null)
            {
                resultado = "Preencha o Numero";
            }
            if (funcionarios.Cpf == null)
            {
                resultado = "Preencha o Cpf";
            }
            if (funcionarios.Função == null)
            {
                resultado = "Preencha a Função";
            }
            else
            {
                _contexto.Funcionarios.Update(funcionarios);
                _contexto.SaveChanges();
            }

            return resultado;

        }

        internal void Incluir(object funcionario)
        {
            throw new NotImplementedException();
        }

        public string Excluir(Funcionarios funcionarios)
        {
            //validacoes
            _contexto.Funcionarios.Remove(funcionarios);
            _contexto.SaveChanges();
            return "ok";
        }
    }
}
