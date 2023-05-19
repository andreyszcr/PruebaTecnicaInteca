export interface Encabezado {
  IdOrdenVenta: number;
  IdSupermercado: string;
  MetodoPago: string;
  TipoCambio: number;
  FechaOrden: Date;
  CedulaPersona: number | null;
}
