using System;
using System.Collections.Generic;

namespace ProyectoUME.Core.Domain
{
    public partial class Jornada
    {
        public Jornada()
        {
            TurnoLaboral = new HashSet<TurnoLaboral>();
            Usuario = new HashSet<Usuario>();
        }

        public int IdJornada { get; set; }
        public string Jornada1 { get; set; }

        public virtual ICollection<TurnoLaboral> TurnoLaboral { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
