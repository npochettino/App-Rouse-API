using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaAppRouss.Clases
{
    class Administrador
    {
        public virtual int Codigo { get; set; }
        public virtual string Usuario { get; set; }
        public virtual string Contraseña { get; set; }
    }
}
