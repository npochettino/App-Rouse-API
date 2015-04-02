using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaAppRouss.Clases;
using FluentNHibernate.Mapping;

namespace BibliotecaAppRouss.Mapeos
{
    class AdministradorMap : ClassMap<Administrador>
    {
        public AdministradorMap()
        {
            Table("Administradores");
            Id(x => x.Codigo).Column("idAdministrador").GeneratedBy.Identity();
            Map(x => x.NombreUsuario).Column("usuario");
            Map(x => x.Contraseña).Column("contraseña");
        }
    }
}
