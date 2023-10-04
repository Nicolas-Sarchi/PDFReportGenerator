using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;

namespace Api.Dtos
{
    public class DetalleFacturaDto
    {
        public int Id {get;set;}
        public int IdFacturaFk {get;set;}
        public ProductoDto Producto {get;set;}
        public int Cantidad {get;set;}
        public double Precio {get;set;}
        
    }
}