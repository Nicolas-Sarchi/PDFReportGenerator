using Dominio.Entities;
using Microsoft.AspNetCore.Mvc;
namespace Dominio.Interfaces;

public interface IProducto : IGenericRepository<Producto>
{
     Task<ActionResult<IEnumerable<Producto>>> GetProductosPorCategoria(int categoriaId);
}

