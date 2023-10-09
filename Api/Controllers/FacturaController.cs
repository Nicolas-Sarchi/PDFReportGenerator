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

 [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<FacturaDto>> GetbyId(int id)
    {
        var Factura = await _unitOfWork.Facturas.GetByIdAsync(id);
        return mapper.Map<FacturaDto>(Factura);
    }


[HttpPost]
[ProducesResponseType(StatusCodes.Status201Created)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public async Task<ActionResult<FacturaDto>> Post(FacturaPostDto factDto)
{
    var factura = this.mapper.Map<Factura>(factDto);

    _unitOfWork.Facturas.Add(factura);
    await _unitOfWork.SaveAsync();

    var detallesFactura = new List<DetalleFactura>();

    foreach (var detalleFacturaDto in factDto.DetallesFactura)
    {
        var detalleFactura = this.mapper.Map<DetalleFactura>(detalleFacturaDto);
        detalleFactura.IdFacturaFk = factura.Id;
        detallesFactura.Add(detalleFactura);
    }

    factura = await _unitOfWork.Facturas.GetByIdAsync(factura.Id);
    var facturaDto = this.mapper.Map<FacturaDto>(factura);

    PdfGenerator pdfGenerator = new ();
    var reportBytes = pdfGenerator.GenerateReport(facturaDto);

    return File(reportBytes, "application/pdf", "factura.pdf");
}


 [HttpPost("crear-pdf")]
    public IActionResult GenerateReport([FromBody] FacturaDto factura)
    {
        PdfGenerator pdfGenerator = new ();

        var reportBytes = pdfGenerator.GenerateReport(factura);

        return File(reportBytes, "application/pdf", "reporte.pdf");
    }

}