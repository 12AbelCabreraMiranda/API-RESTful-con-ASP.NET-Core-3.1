using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static ApiPelilculas.Models.Pelicula;

namespace ApiPelilculas.Models.Dtos
{
    public class PeliculaCreateDto
    {        
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        public string RutaImagen { get; set; }
        public IFormFile Foto { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Duracion { get; set; }
        public TipoClasificacion Clasificacion { get; set; }

        /*Relación de Modelos*/
        public int categoriaId { get; set; }
    }
}
