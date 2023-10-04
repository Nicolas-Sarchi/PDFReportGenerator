using Aplicacion.Repository;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.UnitOfWork;
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ProjectDbContext context;
        private CategoriaRepository _categorias;
        private ClienteRepository _clientes;
        private DetalleFacturaRepository _detalleFacturas;
        private FacturaRepository _facturas;
        private ProductoRepository _productos;


        public UnitOfWork(ProjectDbContext _context)
        {
            context = _context;
        }

        public new ICategoria Categorias
        {
            get
            {
                if (_categorias == null)
                {
                    _categorias = new (context);
                }
                return _categorias;
            }
        }
        public new ICliente Clientes
        {
            get
            {
                if (_clientes == null)
                {
                    _clientes = new (context);
                }
                return _clientes;
            }
        }
        public IDetalleFactura DetalleFacturas
        {
            get
            {
                if (_detalleFacturas == null)
                {
                    _detalleFacturas = new (context);
                }
                return _detalleFacturas;
            }
        }
        public new IFactura Facturas
        {
            get
            {
                if (_facturas == null)
                {
                    _facturas = new (context);
                }
                return _facturas;
            }
        }
        public new IProducto Productos
        {
            get
            {
                if (_productos == null)
                {
                    _productos = new (context);
                }
                return _productos;
            }
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }