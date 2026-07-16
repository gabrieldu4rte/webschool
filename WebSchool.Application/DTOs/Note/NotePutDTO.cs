using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebSchool.Application.DTOs.Note
{
    public class NotePutDTO
    {
        [Required(ErrorMessage = "O identificador da nota é obrigatório.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "A matrícula é obrigatória.")]
        public int TuitionId { get; set; }
        [Required(ErrorMessage = "O valor da nota é obrigatório.")]
        [Range(0, 100, ErrorMessage = "O valor da nota deve estar entre 0 e 100.")]
        public int NoteValue { get; set; }
    }
}
