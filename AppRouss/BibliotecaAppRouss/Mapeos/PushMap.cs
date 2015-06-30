using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaAppRouss.Clases;
using FluentNHibernate.Mapping;

namespace BibliotecaAppRouss.Mapeos
{
    public class PushMap : ClassMap<Push>
    {
        public PushMap()
        {
            Table("Pushes");
            Id(x => x.Codigo).Column("idPush").GeneratedBy.Identity();
            Map(x => x.Descripcion).Column("descripcion");
            Map(x => x.FechaHoraEnvio).Column("fechaHoraEnvio");
            Map(x => x.IsAutomatica).Column("isAutomatica");
        }
    }
}
