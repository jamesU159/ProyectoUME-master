using System;
using System.Collections.Generic;

namespace ProyectoUME.Core.Domain
{
    public partial class Documentos
    {
        public int IdTramite { get; set; }
        public string CursoAlturas { get; set; }
        public string CertificadoEps { get; set; }
        public string CertificadoArl { get; set; }
        public string CertificadoPension { get; set; }
        public string HojaVida { get; set; }

        public virtual Usuario IdTramiteNavigation { get; set; }
    }
}
