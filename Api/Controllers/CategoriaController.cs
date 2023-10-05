using Api.Dtos;
using Api.Generator;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Linq;

namespace Api.Controllers;

public class CategoriaController : BaseApiController
{
    private IUnitOfWork _unitOfWork;
    private readonly IMapper mapper;


    public CategoriaController(IUnitOfWork unitOfWork, IMapper Mapper)
    {
        _unitOfWork = unitOfWork;
        mapper = Mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<CategoriaDto>>> Get()
    {
        var Categoria = await _unitOfWork.Categorias.GetAllAsync();
        return mapper.Map<List<CategoriaDto>>(Categoria);
    }

    [HttpGet]
    public IActionResult GenerateReport([FromBody] FacturaDto categoria)
    {
        PdfGenerator pdfGenerator = new PdfGenerator();

        var reportBytes = pdfGenerator.GenerateReport(categoria);

        return File(reportBytes, "application/pdf", "reporte.pdf");
    }


}