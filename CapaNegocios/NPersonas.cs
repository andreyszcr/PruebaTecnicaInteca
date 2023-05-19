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

    public class NPersonas
    {
        //**************************************************************
        #region Variables
        SqlConnection sqlcon;
        BDConexion cn = new BDConexion();
        EPersona p = new EPersona();
        string resp = "";
        #endregion
        //**************************************************************
        #region InsertarPersonas
        public string InsertarPersonas(int CedulaPersona, string Direccion, int Telefono, DateTime FechaNacimiento, string Genero, string Nombre, string PrimerApellido, string SegundoApellido, string CorreoElectronico)
        {
            //validacion de datos 
            try
            {
                using (sqlcon= new SqlConnection(cn.CadenaConexion))
                {
                    sqlcon.Open();
                    SqlCommand cmdPersona = new SqlCommand("InsertarUsuarios", sqlcon);
                    cmdPersona.CommandType = CommandType.StoredProcedure;
                    cmdPersona.Parameters.AddWithValue("@CedulaPersona", CedulaPersona);
                    cmdPersona.Parameters.AddWithValue("@Direccion", Direccion);
                    cmdPersona.Parameters.AddWithValue("@Telefono", Telefono);
                    cmdPersona.Parameters.AddWithValue("@FechaNacimiento", FechaNacimiento);
                    cmdPersona.Parameters.AddWithValue("@Genero", Genero);
                    cmdPersona.Parameters.AddWithValue("@Nombre", Nombre);
                    cmdPersona.Parameters.AddWithValue("@PrimerApellido", PrimerApellido);
                    cmdPersona.Parameters.AddWithValue("@SegundoApellido", SegundoApellido);
                    cmdPersona.Parameters.AddWithValue("@CorreoElectronico", CorreoElectronico);
                    int count = cmdPersona.ExecuteNonQuery();
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
                resp = "Error al insertar en base de datos"+ex.Message;
                return resp;
            }
        }
        #endregion
        //**************************************************************
        #region MostrarPersonas
        public List<EPersona>MostrarPersonas()
        {
            List<EPersona> lstbal = new List<EPersona>();
            try
            {
                using (sqlcon = new SqlConnection(cn.CadenaConexion))
                {
                    sqlcon.Open();
                    SqlCommand cmd = new SqlCommand("ObtenerUsuarios", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        EPersona P = new EPersona
                        {
                            CedulaPersona = int.Parse(dr["Cedula"].ToString()),
                            Direccion = dr["Direccion"].ToString(),
                            Telefono = int.Parse(dr["Telefono"].ToString()),
                            FechaNacimiento = DateTime.Parse(dr["Fecha de Nacimiento"].ToString()),
                            Genero = dr["Genero"].ToString(),
                            Nombre = dr["Nombre"].ToString(),
                            CorreoElectronico = dr["telefono"].ToString()
                        };
                        lstbal.Add(P);
                    }
                    return lstbal;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                lstbal = null;
                return lstbal;            
            }
        }
        #endregion
        //**************************************************************
        #region ListadoPersonas
        public List<EPersona> ListadoPersonas()
        {
            List<EPersona> lstbal = new List<EPersona>();
            try
            {
                using (sqlcon = new SqlConnection(cn.CadenaConexion))
                {
                    sqlcon.Open();
                    SqlCommand cmd = new SqlCommand("ObtenerNombreUsuarios", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        EPersona P = new EPersona
                        {
                            CedulaPersona = int.Parse(dr["Cedula"].ToString()),
                            Nombre = dr["Nombre"].ToString(),
                        };
                        lstbal.Add(P);
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
        #endregion
    }
}
