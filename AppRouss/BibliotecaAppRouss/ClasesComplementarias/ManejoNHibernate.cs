using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace BibliotecaAppRouss.ClasesComplementarias
{
    class ManejoNHibernate
    {
        private static ISessionFactory CrearSesion()
        {
            ISessionFactory _sessionFactory = Fluently.Configure()

              //.Database(MsSqlConfiguration.MsSql2008.ConnectionString("data source=localhost\\sqlexpress;initial catalog=HistorialMedico;integrated security=True"))
              .Database(MsSqlConfiguration.MsSql2008.ConnectionString("data source=localhost;initial catalog=AppRouss;user=sa;password=ana"))
              .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ModuloPrueba>())
              .BuildSessionFactory();
            return _sessionFactory;
        }

        internal static ISession IniciarSesion()
        {
            return CrearSesion().OpenSession();
        }
    }
}
