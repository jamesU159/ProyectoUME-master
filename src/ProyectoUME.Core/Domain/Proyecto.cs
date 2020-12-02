using System;
using System.Collections.Generic;

namespace ProyectoUME.Core.Domain
{
    public partial class Proyecto
    {
        public Proyecto()
        {
            ListaEmpleados = new HashSet<ListaEmpleados>();
        }

        public int IdProyecto { get; set; }
        public int NumeroEmpleados { get; set; }
        public string DireccionPoyecto { get; set; }
        public string PersonaResponsable { get; set; }

        public virtual ICollection<ListaEmpleados> ListaEmpleados { get; set; }
    }
}
