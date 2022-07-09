using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Web_EF.Entidades
{
    [Table("Endereco")]
    public class Endereco
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("EnderecoId")]
        public int EnderecoId { get; set; }
        [Display(Name = "Rua Cliente")]
        [Column("Rua")]
        [Required]
        public string Rua { get; set; }
        [Required]
        public int Numero { get; set; }
        [Required]
        public string Bairro { get; set; }
        [Required]
        public string Cidade { get; set; }
    }
}
