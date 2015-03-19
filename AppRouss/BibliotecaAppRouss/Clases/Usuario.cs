using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaAppRouss.Clases
{
    class Usuario
    {
        public virtual int Codigo { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Apellido { get; set; }
        public virtual string Dni { get; set; }
        public virtual string Telefono { get; set; }
        public virtual string Mail { get; set; }
        public virtual string Contraseña { get; set; }
    }
}
