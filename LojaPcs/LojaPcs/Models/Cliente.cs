using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LojaPcs.Models
{
    [Table("Clientes")]
    public class Cliente
    {


        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        [MaxLength(50, ErrorMessage = "Maximo 50 caracteres")]
        [Display(Name = "Nome:*")]
        public string ClienteNome { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        [Display(Name = "Email:*")]
        [EmailAddress(ErrorMessage = "Email invalido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        [Display(Name = "Senha:*")]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "Campos não coincidem")]
        [Display(Name = "Confirmar senha:*")]
        [NotMapped]
        public string ConfSenha { get; set; }
    }
    }