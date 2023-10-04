using System.Linq.Expressions;
using Dominio.Interfaces;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository
{
    public class ClienteRepository : GenericRepository<Cliente>, ICliente
    {
     private readonly ProjectDbContext _context;
        public ClienteRepository(ProjectDbContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<Cliente>> GetAllAsync()
{
 return await _context.Clientes.ToListAsync();
}  
}
}