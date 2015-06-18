using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaAppRouss.Clases
{
    public class Push
    {
        public virtual int Codigo { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual DateTime FechaHoraEnvio { get; set; }
    }
}
