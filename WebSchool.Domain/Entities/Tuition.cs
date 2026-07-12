using System;
using System.Collections.Generic;
using System.Text;

namespace WebSchool.Domain.Entities
{
    public class Tuition
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SchoolClassId { get; set; }
        public DateTime TuitionDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public bool Active { get; set; }

        public ICollection<Note> Notes { get; set; }
        public User User { get; set; }
        public SchoolClass SchoolClass { get; set; }
    }
}
