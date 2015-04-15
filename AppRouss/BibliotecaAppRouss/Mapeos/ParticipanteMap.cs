using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaAppRouss.Clases;
using FluentNHibernate.Mapping;

namespace BibliotecaAppRouss.Mapeos
{
    class ParticipanteMap : ClassMap<Participante>
    {
        public ParticipanteMap()
        {
            Table("Participantes");
            Id(x => x.Codigo).Column("idParticipante").GeneratedBy.Identity();
            Map(x => x.FechaParticipacion).Column("fechaParticipacion");
            
            References(x => x.Premio).Column("idPremio").Cascade.None().LazyLoad(Laziness.Proxy);
            References(x => x.Usuario).Column("idUsuario").Cascade.None().LazyLoad(Laziness.Proxy);
        }
    }
}
