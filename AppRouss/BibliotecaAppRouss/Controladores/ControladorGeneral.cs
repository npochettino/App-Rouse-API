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
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
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
                if (adm == null)
                    tablaAdm = null;
                else
                    tablaAdm.Rows.Add(new object[] { adm.Codigo, adm.NombreUsuario, adm.Contraseña });

                return tablaAdm;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
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
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static void EliminarAdministrador(int codigoAdministrador)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                Administrador adm = CatalogoAdministrador.RecuperarPorCodigo(codigoAdministrador, nhSesion);
                CatalogoAdministrador.Eliminar(adm, nhSesion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        #endregion

        #region Usuario

        public static DataTable RecuperarTodosUsuarios()
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                DataTable tablaUsuarios = new DataTable();
                tablaUsuarios.Columns.Add("idUsuario");
                tablaUsuarios.Columns.Add("nombre");
                tablaUsuarios.Columns.Add("apellido");
                tablaUsuarios.Columns.Add("dni");
                tablaUsuarios.Columns.Add("mail");
                tablaUsuarios.Columns.Add("contraseña");
                tablaUsuarios.Columns.Add("telefono");

                List<Usuario> listaUsuarios = CatalogoUsuario.RecuperarTodos(nhSesion);

                (from s in listaUsuarios.OrderBy(x => x.Apellido).ThenBy(x => x.Nombre) select s).Aggregate(tablaUsuarios, (dt, r) => { dt.Rows.Add(r.Codigo, r.Nombre, r.Apellido, r.Dni, r.Mail, r.Contraseña, r.Telefono); return dt; });
                return tablaUsuarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static int InsertarActualizarUsuario(int codigoUsuario, string nombre, string apellido, string dni, string mail, string contraseña, string telefono)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                Usuario usuarioDni = CatalogoUsuario.RecuperarPor(x => x.Dni == dni && x.Codigo != codigoUsuario, nhSesion);

                if (usuarioDni != null)
                {
                    return 2;
                }

                Usuario usuarioMail = CatalogoUsuario.RecuperarPor(x => x.Mail == mail && x.Codigo != codigoUsuario, nhSesion);

                if (usuarioMail != null)
                {
                    return 3;
                }

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

                return 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static void EliminarUsuario(int codigoUsuario)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();
            ITransaction transaccion = nhSesion.BeginTransaction();

            try
            {
                List<Participante> listaParticipantes = CatalogoParticipante.RecuperarLista(x => x.Usuario.Codigo == codigoUsuario, nhSesion);
                CatalogoParticipante.EliminarLista(listaParticipantes, nhSesion);

                Usuario usuario = CatalogoUsuario.RecuperarPorCodigo(codigoUsuario, nhSesion);
                CatalogoUsuario.Eliminar(usuario, nhSesion);

                transaccion.Commit();
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
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

                if (usuario != null)
                {
                    tablaUsuario.Rows.Add(new object[] { usuario.Codigo, usuario.Nombre, usuario.Apellido, usuario.Dni, usuario.Telefono, usuario.Mail, usuario.Contraseña });
                }

                return tablaUsuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static DataTable RecuperarContraseña(string mail)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                DataTable tablaUsuarios = new DataTable();
                tablaUsuarios.Columns.Add("idUsuario");
                tablaUsuarios.Columns.Add("nombre");
                tablaUsuarios.Columns.Add("apellido");
                tablaUsuarios.Columns.Add("dni");
                tablaUsuarios.Columns.Add("mail");
                tablaUsuarios.Columns.Add("contraseña");
                tablaUsuarios.Columns.Add("telefono");

                Usuario usuario = CatalogoUsuario.RecuperarPor(x => x.Mail == mail, nhSesion);

                if (usuario != null)
                {
                    Random rnd = new Random();
                    int nuevaContraseña = rnd.Next(111111, 999999);
                    usuario.Contraseña = nuevaContraseña.ToString();
                    CatalogoUsuario.InsertarActualizar(usuario, nhSesion);

                    tablaUsuarios.Rows.Add(new object[] { usuario.Codigo, usuario.Nombre, usuario.Apellido, usuario.Dni, usuario.Mail, usuario.Contraseña, usuario.Telefono });
                }

                return tablaUsuarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        #endregion

        #region Sorteo

        public static string InsertarActualizarSorteo(int codigoSorteo, DateTime fechaDesde, DateTime fechaHasta, string descripcion, int cantidadTirosPorUsuario, int cantidadPremiosPorUsuario, int cantidadTotalPremios, bool enviarPush)
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
                sorteo.CantidadPremiosTotales = cantidadTotalPremios;
                sorteo.Descripcion = descripcion;
                sorteo.FechaDesde = fechaDesde;
                sorteo.FechaHasta = fechaHasta;

                CatalogoSorteo.InsertarActualizar(sorteo, nhSesion);

                if (codigoSorteo == 0 && enviarPush)
                {
                    Push pushAutomatica = CatalogoPush.RecuperarPor(x => x.IsAutomatica == true, nhSesion);

                    if (pushAutomatica == null)
                    {
                        return "PushAutomaticaInexistente";
                    }
                    else
                    {
                        PushNotification.Enviar(pushAutomatica.Descripcion);
                    }
                }

                return "ok";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
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
                tablaSorteos.Columns.Add("cantidadPremiosTotales");
                tablaSorteos.Columns.Add("cantidadParticipantes");
                tablaSorteos.Columns.Add("cantidadGanadores");

                List<Sorteo> listaSorteos = CatalogoSorteo.RecuperarTodos(nhSesion);

                (from s in listaSorteos.OrderBy(x => x.FechaDesde) select s).Aggregate(tablaSorteos, (dt, r) => { dt.Rows.Add(r.Codigo, r.FechaDesde.ToString("dd/MM/yyyy HH:mm:ss"), r.FechaHasta.ToString("dd/MM/yyyy HH:mm:ss"), r.Descripcion, r.CantidadTirosPorUsuario, r.CantidadPremiosPorUsuario, r.CantidadPremiosTotales, r.Participantes.Count, (from p in r.Participantes where p.Premio.Codigo != 4 select p).Count()); return dt; });
                return tablaSorteos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static void EliminarSorteo(int codigoSorteo)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                Sorteo sorteo = CatalogoSorteo.RecuperarPorCodigo(codigoSorteo, nhSesion);
                CatalogoSorteo.Eliminar(sorteo, nhSesion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static DataTable RecuperarSorteoActual()
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                DataTable tablaSorteo = new DataTable();
                tablaSorteo.Columns.Add("codigoSorteo");
                tablaSorteo.Columns.Add("fechaDesde");
                tablaSorteo.Columns.Add("fechaHasta");
                tablaSorteo.Columns.Add("descripcion");
                tablaSorteo.Columns.Add("cantidadTirosPorUsuario");
                tablaSorteo.Columns.Add("cantidadPremiosPorUsuario");
                tablaSorteo.Columns.Add("cantidadPremiosTotales");

                Sorteo sorteo = CatalogoSorteo.RecuperarPor(x => x.FechaDesde <= DateTime.Now && x.FechaHasta >= DateTime.Now, nhSesion);

                if (sorteo != null)
                {
                    tablaSorteo.Rows.Add(new object[] { sorteo.Codigo, sorteo.FechaDesde.ToString("dd/MM/yyyy HH:mm:ss"), sorteo.FechaHasta.ToString("dd/MM/yyyy HH:mm:ss"), sorteo.Descripcion, sorteo.CantidadTirosPorUsuario, sorteo.CantidadPremiosPorUsuario, sorteo.CantidadPremiosTotales });
                }
                else
                {
                    tablaSorteo.Rows.Add(new object[] { 0, DateTime.MinValue, DateTime.MinValue, string.Empty, 0, 0, 0 });
                }

                return tablaSorteo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
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
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
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
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static int RecuperarCodigoPremio()
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                Random rnd = new Random();
                int sorteo = rnd.Next(1, 100);
                int codigoPremio = 0;
                int probabilidadAnterior = 0;
                int probabilidadPosterior = 0;
                List<Premio> listaPremios = CatalogoPremio.RecuperarTodos(nhSesion);

                foreach (Premio premio in listaPremios)
                {
                    probabilidadPosterior = probabilidadPosterior + premio.Probabilidad;

                    if (sorteo > probabilidadAnterior && sorteo <= probabilidadPosterior)
                    {
                        codigoPremio = premio.Codigo;
                        break;
                    }

                    probabilidadAnterior = probabilidadAnterior + premio.Probabilidad;

                }

                return codigoPremio;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static DataTable RecuperarPremiosPorUsuario(int codigoUsuario)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                DataTable tablaPremios = new DataTable();
                tablaPremios.Columns.Add("codigoPremio");
                tablaPremios.Columns.Add("descripcionPremio");
                tablaPremios.Columns.Add("codigoSorteo");
                tablaPremios.Columns.Add("descripcionSorteo");
                tablaPremios.Columns.Add("fechaHoraDesde");

                List<Participante> listaParticipantes = CatalogoParticipante.RecuperarGanadoresPorUsuario(codigoUsuario, nhSesion);

                (from s in listaParticipantes select s).OrderBy(x => x.RecuperarSorteo(nhSesion).FechaDesde).Aggregate(tablaPremios, (dt, r) =>
                {
                    dt.Rows.Add(r.Premio.Codigo, r.Premio.Descripcion,
                        r.RecuperarSorteo(nhSesion).Codigo, r.RecuperarSorteo(nhSesion).Descripcion, r.RecuperarSorteo(nhSesion).FechaDesde); return dt;
                });
                return tablaPremios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        #endregion

        #region Participante

        public static DataTable RecuperarTodosParticipantes()
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                DataTable tablaParticipantes = new DataTable();
                tablaParticipantes.Columns.Add("codigoParticipante");
                tablaParticipantes.Columns.Add("fechaParticipacion");
                tablaParticipantes.Columns.Add("codigoUsuario");
                tablaParticipantes.Columns.Add("dniUsuario");
                tablaParticipantes.Columns.Add("apellidoUsuario");
                tablaParticipantes.Columns.Add("nombreUsuario");
                tablaParticipantes.Columns.Add("telefonoUsuario");
                tablaParticipantes.Columns.Add("mailUsuario");
                tablaParticipantes.Columns.Add("codigoPremio");
                tablaParticipantes.Columns.Add("descripcionPremio");

                List<Participante> listaParticipantes = CatalogoParticipante.RecuperarTodos(nhSesion);

                (from p in listaParticipantes select p).Aggregate(tablaParticipantes, (dt, r) =>
                {
                    dt.Rows.Add(r.Codigo, r.FechaParticipacion.ToString("dd/MM/yyyy HH:mm:ss"),
                        r.Usuario.Codigo, r.Usuario.Dni, r.Usuario.Apellido, r.Usuario.Nombre, r.Usuario.Telefono, r.Usuario.Mail, r.Premio != null ? r.Premio.Codigo : 0,
                        r.Premio != null ? r.Premio.Descripcion : string.Empty); return dt;
                });

                return tablaParticipantes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static DataTable RecuperarParticipantesPorSorteo(int codigoSorteo)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                DataTable tablaParticipantes = new DataTable();
                tablaParticipantes.Columns.Add("codigoParticipante");
                tablaParticipantes.Columns.Add("fechaParticipacion");
                tablaParticipantes.Columns.Add("codigoUsuario");
                tablaParticipantes.Columns.Add("dniUsuario");
                tablaParticipantes.Columns.Add("apellidoUsuario");
                tablaParticipantes.Columns.Add("nombreUsuario");
                tablaParticipantes.Columns.Add("telefonoUsuario");
                tablaParticipantes.Columns.Add("mailUsuario");
                tablaParticipantes.Columns.Add("codigoPremio");
                tablaParticipantes.Columns.Add("descripcionPremio");

                Sorteo sorteo = CatalogoSorteo.RecuperarPorCodigo(codigoSorteo, nhSesion);

                (from p in sorteo.Participantes.OrderBy(x => x.Usuario.Apellido).ThenBy(x => x.Usuario.Nombre) select p).Aggregate(tablaParticipantes, (dt, r) =>
                {
                    dt.Rows.Add(r.Codigo, r.FechaParticipacion.ToString("dd/MM/yyyy HH:mm:ss"), r.Usuario.Codigo, r.Usuario.Dni, r.Usuario.Apellido, r.Usuario.Nombre, r.Usuario.Telefono,
                    r.Usuario.Mail, r.Premio != null ? r.Premio.Codigo : 0, r.Premio != null ? r.Premio.Descripcion : string.Empty); return dt;
                });

                return tablaParticipantes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static DataTable RecuperarParticipantesPorSorteoGanadorONo(int codigoSorteo, bool isGanador)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                DataTable tablaParticipantes = new DataTable();
                tablaParticipantes.Columns.Add("codigoParticipante");
                tablaParticipantes.Columns.Add("fechaParticipacion");
                tablaParticipantes.Columns.Add("codigoUsuario");
                tablaParticipantes.Columns.Add("dniUsuario");
                tablaParticipantes.Columns.Add("apellidoUsuario");
                tablaParticipantes.Columns.Add("nombreUsuario");
                tablaParticipantes.Columns.Add("telefonoUsuario");
                tablaParticipantes.Columns.Add("mailUsuario");
                tablaParticipantes.Columns.Add("codigoPremio");
                tablaParticipantes.Columns.Add("descripcionPremio");

                Sorteo sorteo = CatalogoSorteo.RecuperarPorCodigo(codigoSorteo, nhSesion);
                List<Participante> listaParticipantes = new List<Participante>();

                if (isGanador)
                {
                    listaParticipantes = (from p in sorteo.Participantes where p.Premio.Codigo != 4 select p).ToList();
                }
                else
                {
                    listaParticipantes = (from p in sorteo.Participantes where p.Premio.Codigo == 4 select p).ToList();
                }

                (from p in listaParticipantes.OrderBy(x => x.Usuario.Apellido).ThenBy(x => x.Usuario.Nombre) select p).Aggregate(tablaParticipantes, (dt, r) =>
                {
                    dt.Rows.Add(r.Codigo, r.FechaParticipacion.ToString("dd/MM/yyyy HH:mm:ss"), r.Usuario.Codigo, r.Usuario.Dni, r.Usuario.Apellido,
                      r.Usuario.Nombre, r.Usuario.Telefono, r.Usuario.Mail, r.Premio != null ? r.Premio.Codigo : 0,
                      r.Premio != null ? r.Premio.Descripcion : string.Empty); return dt;
                });

                return tablaParticipantes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static void InsertarParticipante(int codigoUsuario, int codigoSorteo, int codigoPremio)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                Sorteo sorteo = CatalogoSorteo.RecuperarPorCodigo(codigoSorteo, nhSesion);

                Participante participante = new Participante();
                participante.FechaParticipacion = DateTime.Now;
                participante.Premio = CatalogoPremio.RecuperarPorCodigo(codigoPremio, nhSesion);
                participante.Usuario = CatalogoUsuario.RecuperarPorCodigo(codigoUsuario, nhSesion);

                sorteo.Participantes.Add(participante);

                CatalogoSorteo.InsertarActualizar(sorteo, nhSesion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static DataTable RecuperarParticipacionesDeUsuarioPorSorteo(int codigoSorteo, int codigoUsuario, bool isGanadores)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                DataTable tablaParticipantes = new DataTable();
                tablaParticipantes.Columns.Add("codigoParticipante");
                tablaParticipantes.Columns.Add("fechaParticipacion");
                tablaParticipantes.Columns.Add("codigoUsuario");
                tablaParticipantes.Columns.Add("nombre");
                tablaParticipantes.Columns.Add("apellido");
                tablaParticipantes.Columns.Add("dni");
                tablaParticipantes.Columns.Add("telefono");
                tablaParticipantes.Columns.Add("mail");
                tablaParticipantes.Columns.Add("codigoSorteo");
                tablaParticipantes.Columns.Add("codigoPremio");
                tablaParticipantes.Columns.Add("descripcionPremio");

                Sorteo sorteo = CatalogoSorteo.RecuperarPorCodigo(codigoSorteo, nhSesion);
                List<Participante> listaParticipantes = new List<Participante>();

                if (isGanadores)
                {
                    listaParticipantes = (from p in sorteo.Participantes where p.Premio.Codigo != 4 && p.Usuario.Codigo == codigoUsuario select p).ToList();
                }
                else
                {
                    listaParticipantes = (from p in sorteo.Participantes where p.Premio.Codigo == 4 && p.Usuario.Codigo == codigoUsuario select p).ToList();
                }

                (from p in listaParticipantes select p).Aggregate(tablaParticipantes, (dt, r) =>
                {
                    dt.Rows.Add(r.Codigo, r.FechaParticipacion.ToString("dd/MM/yyyy HH:mm:ss"), r.Usuario.Codigo, r.Usuario.Nombre, r.Usuario.Apellido, r.Usuario.Dni, r.Usuario.Telefono,
                        r.Usuario.Mail, sorteo.Codigo, r.Premio.Codigo, r.Premio.Descripcion); return dt;
                });

                return tablaParticipantes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        #endregion

        #region Publicidad

        public static void InsertarActualizarPublicidad(int codigoPublicidad, string rutaImagen, string descripcion, DateTime fechaHoraInicio, DateTime fechaHoraFin)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();
            try
            {
                Publicidad publicidad;

                if (codigoPublicidad == 0)
                {
                    publicidad = new Publicidad();
                }
                else
                {
                    publicidad = CatalogoPublicidad.RecuperarPorCodigo(codigoPublicidad, nhSesion);
                }

                publicidad.Descripcion = descripcion;
                publicidad.FechaHoraFin = fechaHoraFin;
                publicidad.FechaHoraInicio = fechaHoraInicio;
                publicidad.RutaImagen = rutaImagen;

                CatalogoPublicidad.InsertarActualizar(publicidad, nhSesion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void EliminarPublicidad(int codigoPublicidad)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                Publicidad publicidad = CatalogoPublicidad.RecuperarPorCodigo(codigoPublicidad, nhSesion);
                CatalogoPublicidad.Eliminar(publicidad, nhSesion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        public static DataTable RecuperarTodasPublicidades()
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                DataTable tablaPublicidades = new DataTable();
                tablaPublicidades.Columns.Add("codigoPublicidad");
                tablaPublicidades.Columns.Add("rutaImagen");
                tablaPublicidades.Columns.Add("descripcion");
                tablaPublicidades.Columns.Add("fechaHoraInicio");
                tablaPublicidades.Columns.Add("fechaHoraFin");

                List<Publicidad> listaPublicidades = CatalogoPublicidad.RecuperarTodos(nhSesion);

                (from s in listaPublicidades.OrderBy(x => x.FechaHoraInicio) select s).Aggregate(tablaPublicidades, (dt, r) => { dt.Rows.Add(r.Codigo, r.RutaImagen, r.Descripcion, r.FechaHoraInicio.ToString("dd/MM/yyyy HH:mm:ss"), r.FechaHoraFin.ToString("dd/MM/yyyy HH:mm:ss")); return dt; });
                return tablaPublicidades;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable RecuperarPublicidadActual()
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                DataTable tablaPublicidad = new DataTable();
                tablaPublicidad.Columns.Add("codigoPublicidad");
                tablaPublicidad.Columns.Add("rutaImagen");
                tablaPublicidad.Columns.Add("descripcion");
                tablaPublicidad.Columns.Add("fechaHoraInicio");
                tablaPublicidad.Columns.Add("fechaHoraFin");

                Publicidad publicidad = CatalogoPublicidad.RecuperarPor(x => x.FechaHoraInicio <= DateTime.Now && (x.FechaHoraFin >= DateTime.Now || x.FechaHoraFin == null), nhSesion);

                if (publicidad != null)
                {
                    tablaPublicidad.Rows.Add(new object[] { publicidad.Codigo, publicidad.RutaImagen, publicidad.Descripcion, publicidad.FechaHoraInicio.ToString("dd/MM/yyyy HH:mm:ss"), publicidad.FechaHoraFin.ToString("dd/MM/yyyy HH:mm:ss") });
                }

                return tablaPublicidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                nhSesion.Close();
                nhSesion.Dispose();
            }
        }

        #endregion

        #region Push

        public static void InsertarActualizarPush(int codigoPush, string descripcion, DateTime fechaHoraEnvio, bool isAutomatica)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();
            try
            {
                Push push;

                if (codigoPush == 0 && !isAutomatica)
                {
                    push = new Push();
                }
                else if(isAutomatica)
                {
                    push = CatalogoPush.RecuperarPor(x => x.IsAutomatica == true, nhSesion);
                }
                else
                {
                    push = CatalogoPush.RecuperarPorCodigo(codigoPush, nhSesion);
                }

                push.Descripcion = descripcion;
                push.FechaHoraEnvio = fechaHoraEnvio;
                push.IsAutomatica = isAutomatica;

                CatalogoPush.InsertarActualizar(push, nhSesion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable RecuperarTodasPush(bool isAutomatica)
        {
            ISession nhSesion = ManejoNHibernate.IniciarSesion();

            try
            {
                DataTable tablaPushes = new DataTable();
                tablaPushes.Columns.Add("codigoPush");
                tablaPushes.Columns.Add("descripcion");
                tablaPushes.Columns.Add("fechaHoraEnvio");

                List<Push> listaPushes = CatalogoPush.RecuperarLista(x => x.IsAutomatica == isAutomatica, nhSesion);

                (from s in listaPushes.OrderBy(x => x.FechaHoraEnvio) select s).Aggregate(tablaPushes, (dt, r) => { dt.Rows.Add(r.Codigo, r.Descripcion, r.FechaHoraEnvio.ToString("dd/MM/yyyy HH:mm:ss")); return dt; });
                return tablaPushes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
