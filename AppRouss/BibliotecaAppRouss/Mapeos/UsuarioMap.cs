using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaAppRouss.Clases;
using FluentNHibernate.Mapping;

namespace BibliotecaAppRouss.Mapeos
{
    class UsuarioMap : ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Table("Usuarios");
            Id(x => x.Codigo).Column("idUsuario").GeneratedBy.Identity();
            Map(x => x.Apellido).Column("apellido");
            Map(x => x.Contraseña).Column("contraseña");
            Map(x => x.Dni).Column("dni");
            Map(x => x.Mail).Column("mail");
            Map(x => x.Nombre).Column("nombre");
            Map(x => x.Telefono).Column("telefono");
        }
    }
}
