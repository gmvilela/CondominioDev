using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CondominioDev.Models
{
    public class Despesas
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Descrição de preenchimento obrigatório")]
        [StringLength(200, ErrorMessage = "O tamanho máximo do campo Descrição é de 200 caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo Valor de preenchimento obrigatório")]
        public decimal Valor { get; set; }

        [ForeignKey("Habitante")]
        public int? HabitanteId { get; set; }   
        
        public Habitante? Habitante { get; set; }

    }
}
