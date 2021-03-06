﻿using System;
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


              .Database(MsSqlConfiguration.MsSql2008.ConnectionString("data source=localhost\\sqlexpress;initial catalog=AppRouss;integrated security=True"))
              //.Database(MsSqlConfiguration.MsSql2008.ConnectionString("data source=localhost;initial catalog=AppRouss;user=sa;password=ana"))
              //.Database(MsSqlConfiguration.MsSql2008.ConnectionString("data source=localhost;initial catalog=w1402088_AppRouss;user=w1402088_approuss;password=Algoritmos2015"))
              //--BASE PRUEBA--/*/.Database(MsSqlConfiguration.MsSql2008.ConnectionString("data source=localhost;initial catalog=w1402088_AppRoussTest;user=w1402088_approuss;password=Algoritmos2015"))
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
