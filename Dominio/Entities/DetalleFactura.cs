namespace Dominio.Entities;

public class DetalleFactura : BaseEntity
{
    public int IdFacturaFk {get; set;}
    public Factura Factura {get;set;}
    public int IdProductoFk {get; set;}
    public Producto Producto {get;set;}
    public int Cantidad {get; set;}
    public double Precio {get; set;}
}
