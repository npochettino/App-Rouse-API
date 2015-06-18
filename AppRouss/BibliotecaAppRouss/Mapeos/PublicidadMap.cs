using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaAppRouss.Clases;
using FluentNHibernate.Mapping;

namespace BibliotecaAppRouss.Mapeos
{
    public class PublicidadMap : ClassMap<Publicidad>
    {
        public PublicidadMap()
        {
            Table("Publicidades");
            Id(x => x.Codigo).Column("idPublicidad").GeneratedBy.Identity();
            Map(x => x.Descripcion).Column("descripcion");
            Map(x => x.RutaImagen).Column("rutaImagen");
            Map(x => x.FechaHoraInicio).Column("fechaHoraInicio");
            Map(x => x.FechaHoraFin).Column("fechaHoraFin");
        }
    }
}
