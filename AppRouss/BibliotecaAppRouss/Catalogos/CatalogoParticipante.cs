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
        public static List<Participante> RecuperarGanadoresPorUsuario(int codigoUsuario, ISession nhSesion)
        {
            try
            {
                List<Participante> listaParticipantes = RecuperarLista(x => x.Usuario.Codigo == codigoUsuario && x.Premio.Codigo != 4, nhSesion);
                return listaParticipantes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
