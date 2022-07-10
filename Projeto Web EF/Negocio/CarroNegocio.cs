using Microsoft.EntityFrameworkCore;
using Projeto_Web_EF.Contexto;
using Projeto_Web_EF.Entidades;

namespace Projeto_Web_EF.Negocio
{
    public class CarroNegocio
    {
        private readonly EFContexto _contexto;

        public CarroNegocio(EFContexto contexto)
        {
            this._contexto = contexto;
        }

        public Carro PesquisarPorId(int id)
        {
            //validacoes
            return _contexto.Carros.Find(id);
        }

        public List<Carro> PesquisarTodos()
        {
            //validacoes
            return _contexto.Carros.AsNoTracking().ToList();
        }        

        public string Incluir(Carro carro)
        {
            List<Carro> lista = PesquisarTodos();
            foreach (Carro car in lista)
            {
                if (car.Placa == carro.Placa)
                {
                    return "Ja existe";
                }
            }
            string resultado = "Salvo com Sucesso";

            if (carro.Nome == null || carro.Nome == "")
            {
                resultado = "Preencha o Nome";
            }
            else if (carro.Placa == null || carro.Placa == "")
            {
                resultado = "Preencha a Placa";
            }
            else if (carro.Cor == null || carro.Cor == "")
            {
                resultado = "Preencha a Cor";
            }
            else if (carro.Ano == null || carro.Ano == "")
            {
                resultado = "Preencha o Ano";
            }
            else
            {
                _contexto.Carros.Add(carro);
                _contexto.SaveChanges();
            }

            return resultado;
            
        }

        public string Atualizar(Carro carro)
        {
            List<Carro> lista = PesquisarTodos();
            foreach (Carro car in lista)
            {
                if (car.Placa == carro.Placa && car.Id != carro.Id)
                {
                    return "Ja existe";
                }
            }
            string resultado = "";

            if (carro.Nome == null || carro.Nome == "")
            {
                resultado = "Preencha o Nome";
            }
            else if (carro.Placa == null || carro.Placa == "")
            {
                resultado = "Preencha a Placa";
            }
            else if (carro.Cor == null || carro.Cor == "")
            {
                resultado = "Preencha a Cor";
            }
            else if (carro.Ano == null || carro.Ano == "")
            {
                resultado = "Preencha o Ano";
            }
            else
            {
                _contexto.Carros.Update(carro);
                _contexto.SaveChanges();
            }

            return resultado;

        }
        public string Excluir(Carro carro)
        {
            //validacoes
            _contexto.Carros.Remove(carro);
            _contexto.SaveChanges();
            return "ok";
        }
    }
}
