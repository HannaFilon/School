using AutoMapper;
using School.DAL.Entities;

namespace School.Business
{
    public class AutoMap : Profile
    {
        public AutoMap()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Teacher, TeacherDto>();
        }
    }
}