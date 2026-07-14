using System;
using System.Collections.Generic;
using System.Text;
using WebSchool.Domain.Entities;

namespace WebSchool.Application.DTOs.Course
{
    public class CourseGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
