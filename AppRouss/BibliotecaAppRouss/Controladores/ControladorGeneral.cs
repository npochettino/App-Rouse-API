using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaAppRouss.Catalogos;
using BibliotecaAppRouss.Clases;
using BibliotecaAppRouss.ClasesComplementarias;
using NHibernate;

namespace BibliotecaAppRouss.Controladores
{
    public class ControladorGeneral
    {
        #region Administrador

        public static void InsertarActualizarAdministrador(int codigoAdministrador, string nombreUsuario, string contraseña)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                Administrador adm;

                if (codigoAdministrador == 0)
                {
                    adm = new Administrador();
                }
                else
                {
                    adm = CatalogoAdministrador.RecuperarPorCodigo(codigoAdministrador, nhSesion);
                }

                adm.Contraseña = contraseña;
                adm.NombreUsuario = nombreUsuario;

                CatalogoAdministrador.InsertarActualizar(adm, nhSesion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable RecuperarLogueoAdministrador(string nombreUsuario, string contraseña)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                DataTable tablaAdm = new DataTable();
                tablaAdm.Columns.Add("codigoAdm");
                tablaAdm.Columns.Add("nombreUsuario");
                tablaAdm.Columns.Add("contraseña");

                Administrador adm = CatalogoAdministrador.RecuperarPorUsuarioYContraseña(nombreUsuario, contraseña, nhSesion);
                tablaAdm.Rows.Add(new object[] { adm.Codigo, adm.NombreUsuario, adm.Contraseña });

                return tablaAdm;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable RecuperarTodosAdministradores()
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                DataTable tablaAdministradores = new DataTable();
                tablaAdministradores.Columns.Add("idAdministrador");
                tablaAdministradores.Columns.Add("usuario");
                tablaAdministradores.Columns.Add("contraseña");

                List<Administrador> listaAdministradores = CatalogoAdministrador.RecuperarTodos(nhSesion);

                (from s in listaAdministradores select s).Aggregate(tablaAdministradores, (dt, r) => { dt.Rows.Add(r.Codigo, r.NombreUsuario, r.Contraseña); return dt; });
                return tablaAdministradores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Usuario

        public static void InsertarActualizarUsuario(int codigoUsuario, string nombre, string apellido, string dni, string mail, string contraseña, string telefono)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                Usuario usuario;

                if (codigoUsuario == 0)
                {
                    usuario = new Usuario();
                }
                else
                {
                    usuario = CatalogoUsuario.RecuperarPorCodigo(codigoUsuario, nhSesion);
                }

                usuario.Nombre = nombre;
                usuario.Apellido = apellido;
                usuario.Dni = dni;
                usuario.Mail = mail;
                usuario.Contraseña = contraseña;
                usuario.Telefono = telefono;

                CatalogoUsuario.InsertarActualizar(usuario, nhSesion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable RecuperarLogueoUsuario(string mail, string contraseña)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                DataTable tablaUsuario = new DataTable();
                tablaUsuario.Columns.Add("codigoUsuario");
                tablaUsuario.Columns.Add("nombre");
                tablaUsuario.Columns.Add("apellido");
                tablaUsuario.Columns.Add("dni");
                tablaUsuario.Columns.Add("telefono");
                tablaUsuario.Columns.Add("mail");
                tablaUsuario.Columns.Add("contraseña");

                Usuario usuario = CatalogoUsuario.RecuperarPorMailYContraseña(mail, contraseña, nhSesion);
                tablaUsuario.Rows.Add(new object[] { usuario.Codigo, usuario.Nombre, usuario.Apellido, usuario.Dni, usuario.Telefono, usuario.Mail, usuario.Contraseña });

                return tablaUsuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Sorteo

        public static void InsertarActualizarSorteo(int codigoSorteo, DateTime fechaDesde, DateTime fechaHasta, string descripcion, int cantidadTirosPorUsuario, int cantidadPremiosPorUsuario)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                Sorteo sorteo;

                if (codigoSorteo == 0)
                {
                    sorteo = new Sorteo();
                }
                else
                {
                    sorteo = CatalogoSorteo.RecuperarPorCodigo(codigoSorteo, nhSesion);
                }

                sorteo.CantidadPremiosPorUsuario = cantidadPremiosPorUsuario;
                sorteo.CantidadTirosPorUsuario = cantidadTirosPorUsuario;
                sorteo.Descripcion = descripcion;
                sorteo.FechaDesde = fechaDesde;
                sorteo.FechaHasta = fechaHasta;

                CatalogoSorteo.InsertarActualizar(sorteo, nhSesion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable RecuperarTodosSorteos()
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                DataTable tablaSorteos = new DataTable();
                tablaSorteos.Columns.Add("codigoSorteo");
                tablaSorteos.Columns.Add("fechaDesde");
                tablaSorteos.Columns.Add("fechaHasta");
                tablaSorteos.Columns.Add("descripcion");
                tablaSorteos.Columns.Add("cantidadTirosPorUsuario");
                tablaSorteos.Columns.Add("cantidadPremiosPorUsuario");

                List<Sorteo> listaSorteos = CatalogoSorteo.RecuperarTodos(nhSesion);

                (from s in listaSorteos select s).Aggregate(tablaSorteos, (dt, r) => { dt.Rows.Add(r.Codigo, r.FechaDesde, r.FechaHasta, r.Descripcion, r.CantidadTirosPorUsuario, r.CantidadPremiosPorUsuario); return dt; });
                return tablaSorteos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Premio

        public static void InsertarActualizarPremio(int codigoPremio, string descripcion, int probabilidad)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                Premio premio;

                if (codigoPremio == 0)
                {
                    premio = new Premio();
                }
                else
                {
                    premio = CatalogoPremio.RecuperarPorCodigo(codigoPremio, nhSesion);
                }

                premio.Descripcion = descripcion;
                premio.Probabilidad = probabilidad;

                CatalogoPremio.InsertarActualizar(premio, nhSesion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable RecuperarTodosPremios()
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                DataTable tablaPremios = new DataTable();
                tablaPremios.Columns.Add("codigoPremio");
                tablaPremios.Columns.Add("descripcion");
                tablaPremios.Columns.Add("probabilidad");

                List<Premio> listaPremios = CatalogoPremio.RecuperarTodos(nhSesion);

                (from s in listaPremios select s).Aggregate(tablaPremios, (dt, r) => { dt.Rows.Add(r.Codigo, r.Descripcion, r.Probabilidad); return dt; });
                return tablaPremios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Participante

        public static DataTable RecuperarParticipantesPorSorteo(int codigoSorteo)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                DataTable tablaParticipantes = new DataTable();
                tablaParticipantes.Columns.Add("codigoParticipante");
                tablaParticipantes.Columns.Add("fechaParticipacion");
                tablaParticipantes.Columns.Add("isGanador");
                tablaParticipantes.Columns.Add("codigoUsuario");
                tablaParticipantes.Columns.Add("mailUsuario");
                tablaParticipantes.Columns.Add("codigoPremio");
                tablaParticipantes.Columns.Add("descripcionPremio");

                List<Participante> listaParticipantes = CatalogoParticipante.RecuperarPorSorteo(codigoSorteo, nhSesion);

                (from p in listaParticipantes select p).Aggregate(tablaParticipantes, (dt, r) => { dt.Rows.Add(r.Codigo, r.FechaParticipacion, r.isGanador, r.Usuario.Codigo, r.Usuario.Mail, r.Premio != null ? r.Premio.Codigo : 0, r.Premio != null ? r.Premio.Descripcion : string.Empty); return dt; });

                return tablaParticipantes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
