using System;

namespace School.Business.ModelsDto
{
    public abstract class PersonDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
    }
}
