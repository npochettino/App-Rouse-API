using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using BibliotecaAppRouss.Controladores;
using Newtonsoft.Json;

namespace AppRouss
{
    /// <summary>
    /// Descripción breve de ServicioWeb
    /// </summary>
    [WebService(Namespace = "http://sempait.com.ar/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class ServicioWeb : System.Web.Services.WebService
    {
        [WebMethod]
        public string LoginUsuario(string mail, string contraseña)
        {
            try
            {
                DataTable tablaUsuario = new DataTable();
                tablaUsuario = ControladorGeneral.RecuperarLogueoUsuario(mail, contraseña);
                return JsonConvert.SerializeObject(tablaUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public string RecuperarSorteoYPremio(int codigoUsuario)
        {
            try
            {
                DataTable tablaSorteoYPremio = ControladorGeneral.RecuperarSorteoActual();
                tablaSorteoYPremio.Columns.Add("codigoPremio");

                if (tablaSorteoYPremio.Rows.Count > 0)
                {
                    int codigoSorteo = Convert.ToInt32(tablaSorteoYPremio.Rows[0]["codigoSorteo"]);
                    int cantidadPremiosTotales = Convert.ToInt32(tablaSorteoYPremio.Rows[0]["cantidadPremiosTotales"]);
                    int cantidadTirosPorUsuario = Convert.ToInt32(tablaSorteoYPremio.Rows[0]["cantidadTirosPorUsuario"]);
                    int cantidadPremiosPorUsuario = Convert.ToInt32(tablaSorteoYPremio.Rows[0]["cantidadPremiosPorUsuario"]);

                    DataTable tablaParticipantes = ControladorGeneral.RecuperarParticipantesPorSorteo(codigoSorteo);
                    int cantidadDePremiosPorSorteo = (from r in tablaParticipantes.AsEnumerable() where Convert.ToInt32(r["codigoPremio"]) != 4 select r).Count();
                    if (cantidadPremiosTotales > cantidadDePremiosPorSorteo)
                    {
                        int cantidadTirosReales = (from r in tablaParticipantes.AsEnumerable() where Convert.ToInt32(r["codigoUsuario"]) == codigoUsuario select r).Count();
                        int cantidadPremiosReales = (from r in tablaParticipantes.AsEnumerable() where Convert.ToInt32(r["codigoUsuario"]) == codigoUsuario && Convert.ToInt32(r["codigoPremio"]) != 4 select r).Count();


                        if (cantidadTirosPorUsuario > cantidadTirosReales)
                        {
                            if (cantidadPremiosPorUsuario > cantidadPremiosReales)
                            {
                                int codigoPremio = ControladorGeneral.RecuperarPremio();
                                tablaSorteoYPremio.Rows[0]["codigoPremio"] = codigoPremio;
                            }
                            else
                            {
                                tablaSorteoYPremio.Rows[0]["codigoPremio"] = 7; //ya acumulo mas de los premios permitidos
                            }
                        }
                        else
                        {
                            tablaSorteoYPremio.Rows[0]["codigoPremio"] = 8; //ya realizo mas de los tiros permitidos
                        }
                    }
                    else
                    {
                        tablaSorteoYPremio.Rows[0]["codigoPremio"] = 9; //ya se entregaron todos los premios
                    }
                }

                return JsonConvert.SerializeObject(tablaSorteoYPremio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public string InsertarParticipante(int codigoUsuario, int codigoSorteo, int codigoPremio)
        {
            try
            {
                ControladorGeneral.InsertarParticipante(codigoUsuario, codigoSorteo, codigoPremio);
                return "ok";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
