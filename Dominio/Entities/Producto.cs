namespace Dominio.Entities;

public class Producto : BaseEntity
{
    public int IdCategoriaFk { get; set; }
    public Categoria Categoria { get; set; }
    public string Nombre { get; set; }
    public double Precio { get; set; }
    public int Stock { get; set; }
    public ICollection<DetalleFactura> DetallesFactura {get;set;}

}
