using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CondominioDev.Models
{
    public class Habitante
    {
        public int Id { get; set; }

        [Required(ErrorMessage= "Campo Nome de preenchimento obrigatório")]
        [StringLength(100, ErrorMessage = "O tamanho máximo do campo nome é de 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Sobrenome de preenchimento obrigatório")]
        [StringLength(150, ErrorMessage = "O tamanho máximo do campo SobreNome é de 150 caracteres")]
        public string Sobrenome { get; set; }

        [Column(TypeName = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataNascimento { get; set; }

        [Required(ErrorMessage = "Campo Renda de preenchimento obrigatório")]
        public decimal Renda { get; set; }

        [Required(ErrorMessage = "Campo CPF de preenchimento obrigatório")]
        [StringLength(11, ErrorMessage = "O tamanho máximo do campo CPF é de 11 caracteres")]
        public string Cpf { get; set; }


    }
}
