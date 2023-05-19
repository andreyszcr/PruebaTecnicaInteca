using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using CapaEntities;
using CapaNegocios;

namespace WsVentas
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        #region Personas
        NPersonas p = new NPersonas();
        public string AgregarPersona(int CedulaPersona, string Direccion, int Telefono, DateTime FechaNacimiento, string Genero, string Nombre, string PrimerApellido, string SegundoApellido, string CorreoElectronico)
        {
            string Status = p.InsertarPersonas(CedulaPersona, Direccion, Telefono, FechaNacimiento, Genero, Nombre, PrimerApellido, SegundoApellido, CorreoElectronico);

            if (Status == "")
            {
                return "Usuario Agregado exitosamente";
            }
            else
            {
                return "Error al agregar el usuario";
            }
        }

        public List<EPersona> MostrarPersonas()
        {
            
            List<EPersona> lstbal = p.MostrarPersonas();

            if (lstbal != null)
                return lstbal;
            else
                return lstbal;
        }

        public List<EPersona> ListaUsuarios()
        {
            
            List<EPersona> lstbal = p.ListadoPersonas();

            if (lstbal != null)
                return lstbal;
            else
                return lstbal;
        }
        #endregion
        //*********************************************************
        #region Encabezado
        NEncabezado e=new NEncabezado();
        public string AgregarEncabezado(string IdSupermercado, string MetodoPago, float TipoCambio, DateTime FechaOrden, int? CedulaPersona)
        {
            
            string Status = e.InsertarEncabezado(IdSupermercado,MetodoPago,TipoCambio,FechaOrden,CedulaPersona);
            if (Status == "")
            {
                return "Encabezado Agregado exitosamente";
            }
            else
            {
                return "Error al agregar el Encabezado";
            }
        }

        public List<EEncabezadoOrdenVenta> MostrarEncabezado(int cedula)
        {
            List<EEncabezadoOrdenVenta> lstbal = e.MostrarOrdenVenta(cedula);

            if (lstbal != null)
                return lstbal;
            else
                return lstbal;
        }
        #endregion
        //**********************************************************
        #region DetalleVenta
        NDetalleVenta d = new NDetalleVenta();

        public string AgregarDetalle(int IdOrdenVenta, int IdProducto, string NombreProducto, int Unidad, float PrecioUnitario, float Impuesto, float PrecioImpuestoPorUnidad, int Cantidad, float PrecioTotalImpuestos)
        {

            string Status = d.InsertarDetalleVenta(IdOrdenVenta,IdProducto,NombreProducto,Unidad,PrecioUnitario,Impuesto,PrecioImpuestoPorUnidad,Cantidad,PrecioTotalImpuestos);
            if (Status == "")
            {
                return "Detalle Agregado exitosamente";
            }
            else
            {
                return "Error al agregar el Detalle de la venta";
            }
        }

        public List<EDetalleOrdenVenta> MostrarEncabezado()
        {
            List<EDetalleOrdenVenta> lstbal = d.MostrarDetalleVenta();

            if (lstbal != null)
                return lstbal;
            else
                return lstbal;
        }

        #endregion
    }
}
