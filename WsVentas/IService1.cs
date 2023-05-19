using CapaEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WsVentas
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
        BodyStyle = WebMessageBodyStyle.Wrapped,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "PostPersonas")]
        string AgregarPersona(int CedulaPersona, string Direccion, int Telefono, DateTime FechaNacimiento, string Genero, string Nombre, string PrimerApellido, string SegundoApellido, string CorreoElectronico);


        [OperationContract]
        [WebInvoke(Method = "GET",
        BodyStyle = WebMessageBodyStyle.Wrapped,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "¨GetPersonas")]
        List<EPersona> MostrarPersonas();


        [OperationContract]
        [WebInvoke(Method = "GET",
        BodyStyle = WebMessageBodyStyle.Wrapped,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "GetUsuarioFiltrado")]
        List<EPersona> ListaUsuarios();


        [OperationContract]
        [WebInvoke(Method = "POST",
        BodyStyle = WebMessageBodyStyle.Wrapped,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "PostEncabezado")]
        string AgregarEncabezado(string IdSupermercado, string MetodoPago, float TipoCambio, DateTime FechaOrden, int? CedulaPersona);


        [OperationContract]
        [WebInvoke(Method = "GET",
        BodyStyle = WebMessageBodyStyle.Wrapped,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "GetUsuarioFiltrado")]
        List<EEncabezadoOrdenVenta> MostrarEncabezado(int cedula);
    }


}
