using System;
using System.Collections.Generic;

namespace ApiPrueba.Models
{
    public partial class Profesore
    {
        public int Idempleado { get; set; }
        public string? NombreCompleto { get; set; }
        public string? Genero { get; set; }
        public string? FechaNacimiento { get; set; }
        public string? LugarDeNacimiento { get; set; }
        public string? Nacionalidad { get; set; }
        public string? Cedula { get; set; }
        public string? EstadoCivil { get; set; }
        public string? DepartamentoEnseñar { get; set; }
        public string? Telefono { get; set; }
        public string? Activo { get; set; }
        public string? Email { get; set; }
    }
}
