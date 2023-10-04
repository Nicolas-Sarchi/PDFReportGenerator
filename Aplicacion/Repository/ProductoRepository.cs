using System.Linq.Expressions;
using Dominio.Interfaces;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository
{
    public class ProductoRepository : GenericRepository<Producto>, IProducto
    {
     private readonly ProjectDbContext _context;
        public ProductoRepository(ProjectDbContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<Producto>> GetAllAsync()
{
 return await _context.Productos.ToListAsync();
}  
}
}