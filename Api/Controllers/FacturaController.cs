using Api.Dtos;
using Api.Generator;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;

namespace Api.Controllers;

public class FacturaController : BaseApiController
{
    private IUnitOfWork _unitOfWork;
    private readonly IMapper mapper;


    public FacturaController(IUnitOfWork UnitOfWork, IMapper Mapper)
    {
        _unitOfWork = UnitOfWork;
        mapper = Mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<FacturaDto>>> Get()
    {
        var Factura = await _unitOfWork.Facturas.GetAllAsync();
        return mapper.Map<List<FacturaDto>>(Factura);
    }



   [HttpPost]
[ProducesResponseType(StatusCodes.Status201Created)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<FacturaDto>> Post(FacturaPostDto factDto)
{
    var factura = this.mapper.Map<Factura>(factDto);
    _unitOfWork.Facturas.Add(factura);
    await _unitOfWork.SaveAsync();

    foreach (var detalleFacturaDto in factDto.DetallesFactura)
    {
        var detalleFactura = this.mapper.Map<DetalleFactura>(detalleFacturaDto);
        detalleFactura.IdFacturaFk = factura.Id;
        _unitOfWork.DetallesFactura.Add(detalleFactura);

    }
    var facturaDto = this.mapper.Map<FacturaDto>(factura);
    
    return CreatedAtAction(nameof(Post), new { id = facturaDto.Id }, facturaDto);
}

   [HttpGet("crear-reporte")]
public IActionResult GenerateReport()
{
    PdfGenerator pdfGenerator = new();

    var ultimaFactura = _unitOfWork.Facturas.ObtenerUltimaFactura();
    var ultimaFacturaDto = mapper.Map<FacturaDto>(ultimaFactura);
    var reportBytes = pdfGenerator.GenerateReport(ultimaFacturaDto);

    return File(reportBytes, "application/pdf", "reporte.pdf");
}

}