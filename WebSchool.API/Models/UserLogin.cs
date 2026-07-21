using System.ComponentModel.DataAnnotations;

namespace WebSchool.API.Models
{
    public class UserLogin
    {
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
