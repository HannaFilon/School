using School.DAL.Entities;
using School.DAL.Reposirories;
using System;
using System.Threading.Tasks;

namespace School.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SchoolContext _context;

        public IRepository<Student> StudentRepository { get; }
        public IRepository<Teacher> TeacherRepository { get; }
        public ICourseRepository CourseRepository { get; }

        public UnitOfWork(SchoolContext context,
            IRepository<Student> studentRepository,
            IRepository<Teacher> teacherRepository,
            ICourseRepository courseRepository)
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
