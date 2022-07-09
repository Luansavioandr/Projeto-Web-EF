using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Web_EF.Entidades
{
    [Table("Funcionarios")]
    public class Funcionarios
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NomedoFuncionario { get; set; }
        [Required]
        public string NumerodaCarteiradeTrabalho { get; set; }
        [Required]
        public string Cpf { get; set; }
        [Required]
        public string Função { get; set; }


    }
}
