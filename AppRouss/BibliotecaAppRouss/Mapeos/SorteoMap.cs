using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaAppRouss.Clases;
using FluentNHibernate.Mapping;

namespace BibliotecaAppRouss.Mapeos
{
    class SorteoMap : ClassMap<Sorteo>
    {
        public SorteoMap()
        {
            Table("Sorteos");
            Id(x => x.Codigo).Column("idSorteo").GeneratedBy.Identity();
            Map(x => x.CantidadPremiosPorUsuario).Column("cantidadPremiosPorUsuario");
            Map(x => x.CantidadTirosPorUsuario).Column("cantidadTirosPorUsuario");
            Map(x => x.Descripcion).Column("descripcion");
            Map(x => x.FechaDesde).Column("fechaDesde");
            Map(x => x.FechaHasta).Column("fechaHasta");
            Map(x => x.CantidadPremiosTotales).Column("cantidadPremiosTotales");

            HasMany<Participante>(x => x.Participantes).Table("Participantes").KeyColumn("idSorteo").Not.KeyNullable().Cascade.AllDeleteOrphan();
        }
    }
}
