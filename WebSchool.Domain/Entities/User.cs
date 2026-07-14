using System;
using System.Collections.Generic;
using System.Text;

namespace WebSchool.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Profile { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Tuition> Tuitions { get; set; }
    }
}
