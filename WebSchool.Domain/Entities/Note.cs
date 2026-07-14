using System;
using System.Collections.Generic;
using System.Text;

namespace WebSchool.Domain.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public int TuitionId { get; set; }
        public int NoteValue { get; set; }
        public bool Aproved { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime NoteDate { get; set; }

        public Tuition Tuition { get; set; }
        
    }
}
