using System;
using System.Collections.Generic;

namespace ApiPrueba.Models
{
    public partial class Alumno
    {
        public int Idalumnos { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public string? Nombre { get; set; }
        public string? Genero { get; set; }
        public string? FechaNacimiento { get; set; }
        public string? LugarDeNacimiento { get; set; }
        public string? Nacionalidad { get; set; }
        public string? Calle { get; set; }
        public string? NumeroDeCalle { get; set; }
        public string? NumeroDeTelefono { get; set; }
        public string? Email { get; set; }
    }
}
