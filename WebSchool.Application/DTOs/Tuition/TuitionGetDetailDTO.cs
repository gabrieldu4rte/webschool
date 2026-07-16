using System;
using System.Collections.Generic;
using System.Text;
using WebSchool.Application.DTOs.SchoolClass;
using WebSchool.Application.DTOs.User;

namespace WebSchool.Application.DTOs.Tuition
{
    public class TuitionGetDetailDTO
    {
        public int Id { get; set; }
        public UserGetDTO User { get; set; }
        public SchoolClassGetDTO SchoolClass { get; set; }
        public DateTime TuitionDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public bool Active { get; set; }
    }
}
