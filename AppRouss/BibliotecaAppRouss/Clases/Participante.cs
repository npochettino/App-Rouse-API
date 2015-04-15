using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaAppRouss.Catalogos;
using NHibernate;

namespace BibliotecaAppRouss.Clases
{
    public class Participante
    {
        public virtual int Codigo { get; set; }
        public virtual DateTime FechaParticipacion { get; set; }

        public virtual Usuario Usuario { get; set; }
        public virtual Premio Premio { get; set; }

        public virtual Sorteo RecuperarSorteo(ISession nhSesion)
        {
            Sorteo sorteo = CatalogoSorteo.RecuperarPorParticipante(Codigo, nhSesion);
            return sorteo;
        }
    }
}
