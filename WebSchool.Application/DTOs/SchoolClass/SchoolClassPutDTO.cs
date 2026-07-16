using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebSchool.Application.DTOs.SchoolClass
{
    public class SchoolClassPutDTO
    {
        [Required(ErrorMessage = "O identificador da turma é obrigatório.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O nome deve ter no máximo 50 caracteres.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        [MaxLength(150, ErrorMessage = "A descrição deve ter no máximo 150 caracteres.")]
        public string Description { get; set; }
        public int CourseId { get; set; }
    }
}
