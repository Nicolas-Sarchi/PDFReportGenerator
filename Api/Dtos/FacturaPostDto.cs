using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class FacturaPostDto
    {
        public int Id {get;set;}
        public int IdClienteFk {get;set;}
        public DateOnly Fecha {get;set;}
        public double Total { get; set; }
        public List<DetalleFacturaPostDto> DetallesFactura {get;set;}

    }
}