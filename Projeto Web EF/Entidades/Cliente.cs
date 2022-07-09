using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Web_EF.Entidades
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("CarroId")]
        public int CarroId { get; set; }

        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cpf { get; set; }
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }
        [Required]
        public string NomeMae { get; set; }
        public virtual Carro Carro { get; set; }
    }
}
