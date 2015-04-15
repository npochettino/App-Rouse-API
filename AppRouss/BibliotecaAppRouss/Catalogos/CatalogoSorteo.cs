using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaAppRouss.Clases;
using NHibernate;

namespace BibliotecaAppRouss.Catalogos
{
    class CatalogoSorteo : CatalogoGenerico<Sorteo>
    {
        public static Sorteo RecuperarPorParticipante(int codigoParticipante, ISession nhSesion)
        {
            try
            {
                Sorteo sorteo = nhSesion.QueryOver<Sorteo>().Where(x => x.Participantes.Any(p => p.Codigo == codigoParticipante)).SingleOrDefault();
                return sorteo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
