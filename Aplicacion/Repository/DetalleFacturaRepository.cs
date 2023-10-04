using System.Linq.Expressions;
using Dominio.Interfaces;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository
{
    public class DetalleFacturaRepository : GenericRepository<DetalleFactura>, IDetalleFactura
    {
        private readonly ProjectDbContext _context;
        public DetalleFacturaRepository(ProjectDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<DetalleFactura>> GetAllAsync()
        {
            return await _context.DetalleFacturas 
                .Include(p => p.Producto)
                .ToListAsync();
        }
    }
}