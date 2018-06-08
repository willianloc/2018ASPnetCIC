using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaPcs.Models
{
    [Table("Vendas")]
    public class Venda
    {
        [Key]
        public int VendaId { get; set; }

        [Required]
        [Display(Name = "Computador:")]
        public virtual Computador Computador { get; set; }

        [Required]
        [Display(Name = "Cliente:")]
        public virtual Cliente Cliente { get; set; }


    }
}