using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPelilculas.Models;
using ApiPelilculas.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPelilculas.Controllers
{
    [Route("api/Categorias")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaRepository _ctRepo;
        private readonly IMapper _mapper;

        public CategoriasController(ICategoriaRepository ctRepo, IMapper mapper)
        {
            _ctRepo = ctRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCategorias()
        {
            var listaCategorias = _ctRepo.GetCategorias();

            var listaCategoriasDto = new List<CategoriaDto>();

            foreach (var lista in listaCategorias)
            {
                //Instanciando Mapper
                listaCategoriasDto.Add(_mapper.Map<CategoriaDto>(lista));
            }
            return Ok(listaCategoriasDto);
        }

        [HttpGet("{categoriaId:int}", Name = "GetCategoria")]
        public IActionResult GetCategoria(int categoriaId)
        {
            var itemCategoria = _ctRepo.GetCategoria(categoriaId);

            if (itemCategoria == null)
            {
                return NotFound();
            }
            //Mapeando Categoría
            var itemCategoriaDto = _mapper.Map<CategoriaDto>(itemCategoria);
            return Ok(itemCategoriaDto);
        }
        
        [HttpPost]
        public IActionResult CrearCategoria([FromBody] CategoriaDto categoriaDto)//FromBody: quiere decir que está vinculado lo que enviemos(nombre) en el request  alos datos CategoriaDto
        {
            if (categoriaDto == null)
            {
                return BadRequest(ModelState);
            }

            if (_ctRepo.ExisteCategoria(categoriaDto.Nombre))
            {
                ModelState.AddModelError("", "La categoria ya existe");
                return StatusCode(404, ModelState);
            }

            var categoria = _mapper.Map<Categoria>(categoriaDto);
            if (!_ctRepo.CrearCategoria(categoria))
            {
                ModelState.AddModelError("", $"Algo salió mal guardando el registro{categoria.Nombre}");
                return StatusCode(500, ModelState);
            }
            //Obtiene el último registro agregado
            return CreatedAtRoute("GetCategoria", new { categoriaId = categoria.Id}, categoria);
        }

        [HttpPatch("{categoriaId:int}", Name = "ActualizarCategoria")]
        public IActionResult ActualizarCategoria(int categoriaId, [FromBody]CategoriaDto categoriaDto)
        {
            if(categoriaDto==null || categoriaId != categoriaDto.Id)
            {
                return BadRequest(ModelState);
            }

            var categoria = _mapper.Map<Categoria>(categoriaDto);

            if (!_ctRepo.ActualizarCategoria(categoria))
            {
                ModelState.AddModelError("", $"Algo salio mal actualizando el registro{categoria.Nombre}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("{categoriaId:int}", Name = "BorrarCategoria")]
        public IActionResult BorrarCategoria(int categoriaId)
        {                        

            if (!_ctRepo.ExisteCategoria(categoriaId))
            {
                return NotFound();
            }

            var categoria = _ctRepo.GetCategoria(categoriaId);
            if (!_ctRepo.BorrarCategoria(categoria))
            {
                ModelState.AddModelError("", $"Algo salio mal borrando el registro{categoria.Nombre}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
