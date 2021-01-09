using ApiPelilculas.Models;
using ApiPelilculas.Models.Dtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPelilculas.PeliculasMapper
{
    public class PeliculasMappers : Profile
    {
        //Asociar modelos con Dtos
        public PeliculasMappers()
        {
            CreateMap<Categoria, CategoriaDto>().ReverseMap();
            CreateMap<Pelicula, PeliculaDto>().ReverseMap();
            CreateMap<Pelicula, PeliculaCreateDto>().ReverseMap();
            CreateMap<Pelicula, PeliculaUpdateDto>().ReverseMap();
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
        }
    }
}
