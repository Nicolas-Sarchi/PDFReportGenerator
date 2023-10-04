namespace Dominio.Interfaces;

public interface IUnitOfWork
{
    ICategoria Categorias {get;}
    ICliente Clientes {get;}
    IFactura Facturas {get;}
    IDetalleFactura DetallesFactura {get;}
    IProducto Productos {get;}
    Task<int> SaveAsync();
}
