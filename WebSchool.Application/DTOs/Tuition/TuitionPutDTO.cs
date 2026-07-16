using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebSchool.Application.DTOs.Tuition
{
    public class TuitionPutDTO
    {
        [Required(ErrorMessage = "A matrícula é obrigatória.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "A turma é obrigatória.")]
        public int SchoolClassId { get; set; }
        [Required(ErrorMessage = "A data de expiração é obrigatória.")]
        public DateTime ExpireDate { get; set; }
    }
}
