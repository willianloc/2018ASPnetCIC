﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC1.Models
{
    public class Categoria
    {
        public int id { get; set; }

        public string Nome { get; set; }

        public bool Ativo { get; set; }
    }
}