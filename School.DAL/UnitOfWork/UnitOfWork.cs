using School.DAL.Entities;
using School.DAL.Reposirories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SchoolContext _context;

        public IRepository<Student> StudentRepository { get; }
        public IRepository<Teacher> TeacherRepository { get; }
        public IRepository<Course> CourseRepository { get; }

        public UnitOfWork(SchoolContext context,
            IRepository<Student> studentRepository,
            IRepository<Teacher> teacherRepository,
            IRepository<Course> courseRepository)
        {
            _context = context;
            StudentRepository = studentRepository;
            TeacherRepository = teacherRepository;
            CourseRepository = courseRepository;
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
