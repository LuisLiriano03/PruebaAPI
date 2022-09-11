using System;
using System.Collections.Generic;

namespace ApiPrueba.Models
{
    public partial class Aula
    {
        public int Idaulas { get; set; }
        public string? Profesor { get; set; }
        public string? Alumnos { get; set; }
    }
}
