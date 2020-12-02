using System;
using System.Collections.Generic;

namespace ProyectoUME.Core.Domain
{
    public partial class ListaEmpleados
    {
        public int IdListaEmpleados { get; set; }
        public int ProyectoIdProyecto { get; set; }

        public virtual Proyecto ProyectoIdProyectoNavigation { get; set; }
    }
}
