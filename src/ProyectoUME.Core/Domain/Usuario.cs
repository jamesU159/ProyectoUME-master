using System;
using System.Collections.Generic;

namespace ProyectoUME.Core.Domain
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Correo { get; set; }
        public int Edad { get; set; }
        public string Telefono { get; set; }
        public string Contraseña { get; set; }
        public int EmpresaNit { get; set; }
        public string AspnetusersId { get; set; }

        public virtual Aspnetusers Aspnetusers { get; set; }
        public virtual Empresa EmpresaNitNavigation { get; set; }
        public virtual Documentos Documentos { get; set; }
    }
}
