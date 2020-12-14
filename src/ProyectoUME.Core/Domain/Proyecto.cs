using System;
using System.Collections.Generic;

namespace ProyectoUME.Core.Domain
{
    public partial class Proyecto
    {
        public Proyecto()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int IdProyecto { get; set; }
        public int NumeroEmpleados { get; set; }
        public string DireccionPoyecto { get; set; }
        public string PersonaResponsable { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
