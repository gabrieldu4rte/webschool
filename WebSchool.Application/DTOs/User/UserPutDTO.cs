using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebSchool.Application.DTOs.User
{
    public class UserPutDTO
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [MaxLength(250, ErrorMessage = "O nome deve ter no máximo 250 caracteres.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O E-mail é obrigatório.")]
        [MaxLength(250, ErrorMessage = "O E-mail deve ter no máximo 250 caracteres.")]
        [EmailAddress(ErrorMessage = "O e-mail é inválido.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "A senha é obrigatória.")]
        [MaxLength(250, ErrorMessage = "A senha deve ter no máximo 250 caracteres.")]
        [MinLength(8, ErrorMessage = "A senha deve ter no mínimo 8 caracteres.")]
        public string Password { get; set; }
    }
}
