using ApiPelilculas.Models;
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
        }
    }
}
