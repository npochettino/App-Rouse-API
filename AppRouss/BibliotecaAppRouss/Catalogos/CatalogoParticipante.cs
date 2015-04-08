using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaAppRouss.Clases;
using NHibernate;

namespace BibliotecaAppRouss.Catalogos
{
    class CatalogoParticipante : CatalogoGenerico<Participante>
    {
        public static List<Participante> RecuperarPorSorteo(int codigoSorteo, ISession nhSesion)
        {
            try
            {
                List<Participante> listaParticipantes = RecuperarLista(x => x.Sorteo.Codigo == codigoSorteo, nhSesion);
                return listaParticipantes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Participante> RecuperarPorUsuarioYSorteo(int codigoUsuario, int codigoSorteo, ISession nhSesion)
        {
            try
            {
                List<Participante> listaParticipantes = RecuperarLista(x => x.Sorteo.Codigo == codigoSorteo && x.Usuario.Codigo == codigoUsuario, nhSesion);
                return listaParticipantes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
