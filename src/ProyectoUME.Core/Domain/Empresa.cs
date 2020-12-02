using System;
using System.Collections.Generic;

namespace ProyectoUME.Core.Domain
{
    public partial class Empresa
    {
        public Empresa()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int Nit { get; set; }
        public string NombreEmpresa { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Telefono { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
