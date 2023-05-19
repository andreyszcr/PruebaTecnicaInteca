export interface DetalleVenta {
  IdLinea: number;
  IdOrdenVenta: number;
  IdProducto: number;
  NombreProducto: string | null;
  Unidad: number;
  PrecioUnitario: number;
  Impuesto: number | null;
  PrecioImpuestoPorUnidad: number | null;
  Cantidad: number | null;
  PrecioTotalImpuestos: number | null;
}
