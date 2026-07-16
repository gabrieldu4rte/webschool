using WebSchool.Application.DTOs.Course;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebSchool.Application.DTOs.SchoolClass
{
    public class SchoolClassGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CourseId { get; set; }
    }
}
