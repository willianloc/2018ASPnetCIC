﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaPcs.Models
{
    [Table("Gabinetes")]

    public class Gabinete
    {
        [Key]
        public int GabineteId { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        [MaxLength(50, ErrorMessage = "Maximo 50 caracteres")]
        [Display(Name = "Nome:*")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        [Display(Name = "Preço:*")]
        public double Preco { get; set; }

    }
}