using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntities
{
    public class EEncabezadoOrdenVenta
    {
        public int IdOrdenVenta { get; set; }
        public string IdSupermercado { get; set; }
        public string MetodoPago { get; set; }
        public float TipoCambio { get; set; }
        public DateTime FechaOrden { get; set; }
        public int? CedulaPersona { get; set; }
    }
}
