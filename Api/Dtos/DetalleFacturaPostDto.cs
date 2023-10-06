using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dtos
{
    public class DetalleFacturaPostDto
    {
           public int Id {get;set;}
        public int IdFacturaFk {get;set;}
        public int IdProductoFk {get;set;}
        public int Cantidad {get;set;}
        public double Precio {get;set;}
    }
}