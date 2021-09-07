using AutoMapper;
using School.Business.ModelsDto;
using School.DAL.Entities;
using School.WebApp.Models;

namespace School.WebApp
{
    public class AutoMap : Profile
    {
        public AutoMap()
        {
            CreateMap<StudentDto, Student>()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(
                    (source, destination) => !string.IsNullOrEmpty(source.Id.ToString()) ? source.Id : destination.Id))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(
                    (source, destination) => !string.IsNullOrEmpty(source.FullName) ? source.FullName : destination.FullName))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(
                    (source, destination) => !(source.DateOfBirth == default) ? source.DateOfBirth : destination.DateOfBirth))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(
                    (source, destination) => !string.IsNullOrEmpty(source.Address) ? source.Address : destination.Address));
            CreateMap<Student, StudentDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(source => source.FullName))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(source => source.DateOfBirth))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(source => source.Address));

            CreateMap<TeacherDto, Teacher>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(
                    (source, destination) => !string.IsNullOrEmpty(source.Id.ToString()) ? source.Id : destination.Id))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(
                    (source, destination) => !string.IsNullOrEmpty(source.FullName) ? source.FullName : destination.FullName))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(
                    (source, destination) => !(source.DateOfBirth == default) ? source.DateOfBirth : destination.DateOfBirth))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(
                    (source, destination) => !string.IsNullOrEmpty(source.Address) ? source.Address : destination.Address));
            CreateMap<Teacher, TeacherDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(source => source.FullName))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(source => source.DateOfBirth))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(source => source.Address));
            CreateMap<TeacherDto, PersonViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(source => source.FullName))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(source => source.DateOfBirth))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(source => source.Address));
            CreateMap<PersonViewModel, TeacherDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(
                    (source, destination) => !string.IsNullOrEmpty(source.Id.ToString()) ? source.Id : destination.Id))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(
                    (source, destination) => !string.IsNullOrEmpty(source.FullName) ? source.FullName : destination.FullName))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(
                    (source, destination) => !(source.DateOfBirth == default) ? source.DateOfBirth : destination.DateOfBirth))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(
                    (source, destination) => !string.IsNullOrEmpty(source.Address) ? source.Address : destination.Address));

            CreateMap<CourseDto, Course>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(
                    (source, destination) => !string.IsNullOrEmpty(source.Id.ToString()) ? source.Id : destination.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(
                    (source, destination) => !string.IsNullOrEmpty(source.Title) ? source.Title : destination.Title))
                .ForMember(dest => dest.IsActivated, opt => opt.MapFrom(
                    (source, destination) => (source.IsActivated != default) ? source.IsActivated : destination.IsActivated));
            CreateMap<Course, CourseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(source => source.Title))
                .ForMember(dest => dest.IsActivated, opt => opt.MapFrom(source => source.IsActivated))
                .ForMember(dest => dest.Teacher, opt => opt.MapFrom(source => source.Teacher));
            CreateMap<CourseDto, CourseViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(source => source.Title))
                .ForMember(dest => dest.IsActivated, opt => opt.MapFrom(source => source.IsActivated))
                .ForMember(dest => dest.TeachersId, opt => opt.MapFrom(
                    (source, destination) => (source.Teacher != null) ? source.Teacher.Id.ToString() : null))
                .ForMember(dest => dest.TeachersFullName, opt => opt.MapFrom(
                    (source, destination) => (source.Teacher != null) ? source.Teacher.FullName : null));
            CreateMap<CourseViewModel, CourseDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(
                    (source, destination) => source.Id.HasValue ? source.Id : null))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(source => source.Title));
        }
    }
}
