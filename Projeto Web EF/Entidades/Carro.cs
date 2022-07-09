using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Web_EF.Entidades
{
    [Table("Carro")]
    public class Carro
    {
        [Key]
        public int Id { get; set; }

        
        public string Nome { get; set; }

        
        public string Cor { get; set; }

        
        public string Ano { get; set; }

        
        public string Placa { get; set; }
    }
}
