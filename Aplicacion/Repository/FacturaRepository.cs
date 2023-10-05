using System.Linq.Expressions;
using Dominio.Interfaces;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository
{
    public class FacturaRepository : GenericRepository<Factura>, IFactura
    {
        private readonly ProjectDbContext _context;
        public FacturaRepository(ProjectDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Factura>> GetAllAsync()
        {
            return await _context.Facturas 
                .Include(p => p.DetallesFactura)
                .ThenInclude(p => p.Producto)
                .Include(p => p.Cliente)
                .ToListAsync();
        }
    }
}