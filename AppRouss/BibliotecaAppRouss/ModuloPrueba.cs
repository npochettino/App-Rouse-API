﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaAppRouss.Controladores;

namespace BibliotecaAppRouss
{
    class ModuloPrueba
    {
        public static void Main()
        {
            DataTable tabla = ControladorGeneral.RecuperarTodosAdministradores();
        }
    }
}
