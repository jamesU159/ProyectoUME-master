using System;
using System.Collections.Generic;

namespace ProyectoUME.Core.Domain
{
    public partial class Usuario
    {
        public Usuario()
        {
            Excusa = new HashSet<Excusa>();
            Permiso = new HashSet<Permiso>();
            TurnoLaboral = new HashSet<TurnoLaboral>();
        }

        public int IdUsuario { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public int Cedula { get; set; }
        public int Edad { get; set; }
        public string Telefono { get; set; }
        public int Jornada { get; set; }
        public int IdProyecto { get; set; }
        public int? EmpresaNit { get; set; }
        public string AspnetusersId { get; set; }

        public virtual Aspnetusers Aspnetusers { get; set; }
        public virtual Empresa EmpresaNitNavigation { get; set; }
        public virtual Proyecto IdProyectoNavigation { get; set; }
        public virtual Jornada JornadaNavigation { get; set; }
        public virtual Documentos Documentos { get; set; }
        public virtual ICollection<Excusa> Excusa { get; set; }
        public virtual ICollection<Permiso> Permiso { get; set; }
        public virtual ICollection<TurnoLaboral> TurnoLaboral { get; set; }
    }
}
