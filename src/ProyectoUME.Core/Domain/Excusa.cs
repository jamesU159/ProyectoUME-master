﻿using System;
using System.Collections.Generic;

namespace ProyectoUME.Core.Domain
{
    public partial class Excusa
    {
        public int IdExcusa { get; set; }
        public string AnexoEvidencia { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido1 { get; set; }
        public string Apellodo2 { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public int IdUsuarios { get; set; }

        public virtual Usuario IdUsuariosNavigation { get; set; }
    }
}
