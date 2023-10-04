using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class FacturaDto
    {
        public int Id {get;set;}
        public ClienteDto Cliente {get;set;}
        public DateOnly Fecha {get;set;}
        public double Total {get;set;}
        public List<DetalleFacturaDto> DetallesFactura {get;set;}
    }
}