using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntities
{
    public class EDetalleOrdenVenta
    {
        public int IdLinea { get; set; }
        public int IdOrdenVenta { get; set; }
        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public int Unidad { get; set; }
        public float PrecioUnitario { get; set; }
        public float? Impuesto { get; set; }
        public float? PrecioImpuestoPorUnidad { get; set; }
        public int? Cantidad { get; set; }
        public float? PrecioTotalImpuestos { get; set; }
    }
}
