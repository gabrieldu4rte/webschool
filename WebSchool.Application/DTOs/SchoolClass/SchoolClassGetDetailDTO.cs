using System;
using System.Collections.Generic;
using System.Text;
using WebSchool.Application.DTOs.Course;

namespace WebSchool.Application.DTOs.SchoolClass
{
    public class SchoolClassGetDetailDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CourseGetDTO Course { get; set; }
    }
}
