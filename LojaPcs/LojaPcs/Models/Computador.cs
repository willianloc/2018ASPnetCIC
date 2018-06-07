using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaPcs.Models
{
    [Table("Computadores")]
    public class Computador
    {

        [Key]
        public int ComputadorId { get; set; }

        [Required]
        [Display(Name = "Gabinete:")]
        public virtual Gabinete Gabinete { get; set; }

        [Required]
        [Display(Name = "Processador:")]
        public virtual Processador Processador { get; set; }

        [Required]
        [Display(Name = "Placa Mãe:")]
        public virtual PlacaMae Placamae { get; set; }

        [Required]
        [Display(Name = "Memoria Ram:")]
        public virtual Ram Ram { get; set; }

        [Required]
        [Display(Name = "QTD:")]
        public int QtdRam { get; set; }

        [Required]
        [Display(Name = "Placa de vídeo:")]
        public virtual GPU Gpu { get; set; }

        [Required]
        [Display(Name = "QTD:")]
        public int QtdGpu { get; set; }

        [Required]
        [Display(Name = "Fonte:")]
        public virtual Fonte Fonte { get; set; }

        [Required]
        [Display(Name = "Disco Rigido (HD):")]
        public virtual HD Hd { get; set; }

        [Required]
        [Display(Name = "QTD:")]
        public int QtdHd { get; set; }

        [Required]
        [ScaffoldColumn(false)]
        public double Preço { get; set; }


    }
}