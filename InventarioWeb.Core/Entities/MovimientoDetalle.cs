namespace InventarioWeb.Core.Entities
{
    public class MovimientoDetalle: BaseEntity
    {
        public int MovimientoId { get; set; }
        public Movimiento? Movimiento { get; set; }

        public int ProductoId { get; set; }
        public Producto? Producto { get; set; }

        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        public decimal Subtotal => Cantidad * PrecioUnitario;
    }
}