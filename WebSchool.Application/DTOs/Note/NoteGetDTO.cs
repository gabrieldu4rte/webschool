using System;
using System.Collections.Generic;
using System.Text;

namespace WebSchool.Application.DTOs.Note
{
    public class NoteGetDTO
    {
        public int Id { get; set; }
        public int TuitionId { get; set; }
        public int NoteValue { get; set; }
        public bool Aproved { get; set; }
        public DateTime NoteDate { get; set; }

    }
}
