using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CondominioDev.Dtos
{
    public class HabitanteDto
    {

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

    }
}
