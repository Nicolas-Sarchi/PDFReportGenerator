using Api.Dtos;
using Api.Generator;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult GenerateReport([FromBody] CategoriaDto categoria)
    {
        PdfGenerator pdfGenerator = new PdfGenerator();
        byte[] pdfBytes = pdfGenerator.GenerateReport(categoria);

        FileContentResult fileContentResult = new FileContentResult(pdfBytes, "application/pdf")
        {
            FileDownloadName = "reporte.pdf"
        };

        return fileContentResult;
    }
}