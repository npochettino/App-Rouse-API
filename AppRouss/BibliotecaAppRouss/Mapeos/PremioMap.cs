using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaAppRouss.Clases;
using FluentNHibernate.Mapping;

namespace BibliotecaAppRouss.Mapeos
{
    class PremioMap : ClassMap<Premio>
    {
        public PremioMap()
        {
            Table("Premios");
            Id(x => x.Codigo).Column("idPremio").GeneratedBy.Identity();
            Map(x => x.Descripcion).Column("descripcion");
            Map(x => x.Probabilidad).Column("probabilidad");
        }
    }
}
