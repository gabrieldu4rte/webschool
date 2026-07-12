using System;
using System.Collections.Generic;
using System.Text;

namespace WebSchool.Domain.Entities
{
    public class SchoolClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CourseId { get; set; }

        public ICollection<Tuition> Tuitions { get; set; }

        public Course Course { get; set; }
    }
}
