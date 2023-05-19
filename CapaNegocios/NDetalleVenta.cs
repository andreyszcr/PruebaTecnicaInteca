using CapaDatos;
using CapaEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class NDetalleVenta
    {
        #region Variables
        SqlConnection sqlcon;
        BDConexion cn = new BDConexion();
        EDetalleOrdenVenta e = new EDetalleOrdenVenta();
        string resp = "";
        #endregion
        //******************************************************
        #region InsertarPersonas
        public string InsertarDetalleVenta(int IdOrdenVenta,int IdProducto, string NombreProducto, int Unidad, float PrecioUnitario, float Impuesto, float PrecioImpuestoPorUnidad,int Cantidad, float PrecioTotalImpuestos)
        {
            //validacion de datos 
            try
            {
                using (sqlcon = new SqlConnection(cn.CadenaConexion))
                {
                    sqlcon.Open();
                    SqlCommand cmdDetalleVenta = new SqlCommand("InsertEncabezadoOrdenVenta", sqlcon);
                    cmdDetalleVenta.CommandType = CommandType.StoredProcedure;
                    cmdDetalleVenta.Parameters.AddWithValue("@IdOrdenVenta", IdOrdenVenta);
                    cmdDetalleVenta.Parameters.AddWithValue("@IdProducto", IdProducto);
                    cmdDetalleVenta.Parameters.AddWithValue("@NombreProducto", NombreProducto);
                    cmdDetalleVenta.Parameters.AddWithValue("@Unidad", Unidad);
                    cmdDetalleVenta.Parameters.AddWithValue("@PrecioUnitario", PrecioUnitario);
                    cmdDetalleVenta.Parameters.AddWithValue("@Impuesto", Impuesto);
                    cmdDetalleVenta.Parameters.AddWithValue("@PrecioImpuestoPorUnidad", PrecioImpuestoPorUnidad);
                    cmdDetalleVenta.Parameters.AddWithValue("@Cantidad", Cantidad);
                    cmdDetalleVenta.Parameters.AddWithValue("@PrecioTotalImpuestos", PrecioTotalImpuestos);
                    int count = cmdDetalleVenta.ExecuteNonQuery();
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
        public List<EDetalleOrdenVenta> MostrarDetalleVenta()
        {
            List<EDetalleOrdenVenta> lstbal = new List<EDetalleOrdenVenta>();
            try
            {
                using (sqlcon = new SqlConnection(cn.CadenaConexion))
                {
                    sqlcon.Open();
                    SqlCommand cmd = new SqlCommand("MostrarVenta", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@CedulaPersona", Cedula);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        EDetalleOrdenVenta e = new EDetalleOrdenVenta
                        {
                            IdLinea = int.Parse(dr["ID Linea"].ToString()),
                            IdProducto = int.Parse(dr["Codigo Producto"].ToString()),
                            NombreProducto = dr["Producto"].ToString(),
                            Unidad = int.Parse(dr["Unidades"].ToString()),
                            PrecioImpuestoPorUnidad = int.Parse(dr["Precio Unitario"].ToString())
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
