using WebSchool.Application.DTOs.SchoolClass;
using WebSchool.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Text;
using WebSchool.Domain.Entities;

namespace WebSchool.Application.DTOs.Tuition
{
    public class TuitionGetDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SchoolClassId { get; set; }
        public DateTime TuitionDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public bool Active { get; set; }
    }
}
