using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaAppRouss.Clases
{
    class Participante
    {
        public virtual int Codigo { get; set; }
        public virtual DateTime FechaParticipacion { get; set; }
        public virtual bool isGanador { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Sorteo Sorteo { get; set; }
        public virtual Premio Premio { get; set; }
    }
}
