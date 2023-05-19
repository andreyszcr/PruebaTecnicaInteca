using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntities;
using CapaDatos;
using System.Data.SqlClient;
using System.Data;
namespace CapaNegocios
{
    public class NEncabezado
    {
        #region Variables
        SqlConnection sqlcon;
        BDConexion cn = new BDConexion();
        EEncabezadoOrdenVenta e = new EEncabezadoOrdenVenta();
        string resp = "";
        #endregion
        //******************************************************
        #region InsertarPersonas
        public string InsertarEncabezado(string IdSupermercado, string MetodoPago, float TipoCambio, DateTime FechaOrden, int? CedulaPersona)
        {
            //validacion de datos 
            try
            {
                using (sqlcon = new SqlConnection(cn.CadenaConexion))
                {
                    sqlcon.Open();
                    SqlCommand cmdEncabezado = new SqlCommand("InsertEncabezadoOrdenVenta", sqlcon);
                    cmdEncabezado.CommandType = CommandType.StoredProcedure;
                    cmdEncabezado.Parameters.AddWithValue("@IdSupermercado", IdSupermercado);
                    cmdEncabezado.Parameters.AddWithValue("@MetodoPago", MetodoPago);
                    if (MetodoPago == "Dolares")
                        e.TipoCambio = 445;
                    else 
                    {
                        e.TipoCambio = 1;
                    }
                    cmdEncabezado.Parameters.AddWithValue("@TipoCambio", TipoCambio);
                    cmdEncabezado.Parameters.AddWithValue("@FechaOrden", FechaOrden);
                    cmdEncabezado.Parameters.AddWithValue("@CedulaPersona", CedulaPersona);
                    int count = cmdEncabezado.ExecuteNonQuery();
                    if (count > 0)
                    {
                        resp = "";
                        return resp;
                    }
                    else
                    {
                        resp = "Error";
                        return resp;
                    }
                }
            }
            catch (Exception ex)
            {
                sqlcon.Close();
                resp = "Error al insertar en base de datos" + ex.Message;
                return resp;
            }
        }
        #endregion
        //*************************************************************************
        public List<EEncabezadoOrdenVenta> MostrarOrdenVenta(int Cedula)
        {
            List<EEncabezadoOrdenVenta> lstbal = new List<EEncabezadoOrdenVenta>();
            try
            {
                using (sqlcon = new SqlConnection(cn.CadenaConexion))
                {
                    sqlcon.Open();
                    SqlCommand cmd = new SqlCommand("OrdenVentaXPersona", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CedulaPersona", Cedula);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        EEncabezadoOrdenVenta e = new EEncabezadoOrdenVenta
                        {
                            IdOrdenVenta = int.Parse(dr["Id Orden Venta"].ToString()),
                            FechaOrden = DateTime.Parse(dr["Fecha de Orden"].ToString()),
                            IdSupermercado = dr["Lugar"].ToString()
                        };
                        lstbal.Add(e);
                    }
                    return lstbal;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                lstbal = null;
                return lstbal;
            }
        }
    }
}

