using Api.Dtos;
using AutoMapper;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
}