using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC1.Models
{
    public class Categoria
    {
        public int id { get; set; }

        [Display(Name ="Título")]
        [Required(ErrorMessage ="ERRRRRRouuuuu")]
        public string Nome { get; set; }

        public bool Ativo { get; set; }
    }
}