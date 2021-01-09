﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPelilculas.Models.Dtos
{
    public class UsuarioAuthDto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="El Usuario es obligatorio")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "El Usuario es obligatorio")]
        [StringLength(10,MinimumLength =4,ErrorMessage ="La contraseña debe estar entre 4 y 10 caracteres")]
        public string Password { get; set; }
    }
}
