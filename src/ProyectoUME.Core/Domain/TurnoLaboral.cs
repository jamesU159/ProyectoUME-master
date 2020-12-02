using System;
using System.Collections.Generic;

namespace ProyectoUME.Core.Domain
{
    public partial class TurnoLaboral
    {
        public int IdConsulta { get; set; }
        public TimeSpan HoraIngreso { get; set; }
        public TimeSpan HoraSalida { get; set; }
        public int JornadaIdJornada { get; set; }

        public virtual Jornada JornadaIdJornadaNavigation { get; set; }
    }
}
