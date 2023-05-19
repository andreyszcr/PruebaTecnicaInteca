using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class BDConexion
    {
        public string CadenaConexion = @"Data Source=DESKTOP-IUEFO21\MSSQLSERVER01;Initial Catalog=Ventas;User ID=andreyszcr;Password=Andy2023sa99";
        //public SqlConnection Conexion = new SqlConnection(CadenaConexion);
        //public SqlConnection AbrirConexion()
        //{
        //    if (Conexion.State == ConnectionState.Closed)
        //        Conexion.Open();
        //    return Conexion;
        //}
        //public SqlConnection CerrarConexion()
        //{
        //    if (Conexion.State == ConnectionState.Open)
        //        Conexion.Close();
        //    return Conexion;
        //}

    }
}
