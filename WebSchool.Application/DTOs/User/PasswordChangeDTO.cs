using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebSchool.Application.DTOs.User
{
    public class PasswordChangeDTO
    {
        [Required(ErrorMessage = "A senha atual é obrigatória.")]
        [MaxLength(250, ErrorMessage = "A senha deve ter no máximo 250 caracteres.")]
        public string ActualPassword { get; set; }
        [Required(ErrorMessage = "A nova senha é obrigatória.")]
        [MaxLength(250, ErrorMessage = "A nova senha deve ter no máximo 250 caracteres.")]
        [MinLength(8, ErrorMessage = "A nova senha deve ter no mínimo 8 caracteres.")]
        public string NewPassword { get; set; }
    }
}
