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

     [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CategoriaDto>> Get(int id)
    {
        var Pais = await _unitOfWork.Categorias.GetByIdAsync(id);
        return mapper.Map<CategoriaDto>(Pais);
    }


}