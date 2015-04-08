using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaAppRouss.Clases
{
    public class Sorteo
    {
        public virtual int Codigo { get; set; }
        public virtual DateTime FechaDesde { get; set; }
        public virtual DateTime FechaHasta { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual int CantidadTirosPorUsuario { get; set; }
        public virtual int CantidadPremiosPorUsuario { get; set; }
        public virtual int CantidadPremiosTotales { get; set; }
    }
}
