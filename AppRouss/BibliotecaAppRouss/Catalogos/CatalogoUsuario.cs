﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaAppRouss.Clases;
using NHibernate;

namespace BibliotecaAppRouss.Catalogos
{
    class CatalogoUsuario : CatalogoGenerico<Usuario>
    {
        public static Usuario RecuperarPorMailYContraseña(string mail, string contraseña, ISession nhSesion)
        {
            try
            {
                Usuario usuario = RecuperarPor(x => x.Contraseña == contraseña && x.Mail == mail, nhSesion);
                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}