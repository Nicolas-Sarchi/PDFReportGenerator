namespace Dominio.Interfaces
{
    public class IUnitOfWork
    {
       public ICategoria Categorias {get;set;}
        public ICliente Clientes {get;set;}
       public IFactura Facturas {get;set;}
       public IDetalleFactura DetallesFactura {get;set;}
       public IProducto Productos {get;set;}
    }
}