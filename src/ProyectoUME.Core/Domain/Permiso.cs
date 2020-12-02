using System;
using System.Collections.Generic;

namespace ProyectoUME.Core.Domain
{
    public partial class Permiso
    {
        public int IdPermiso { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
    }
}
