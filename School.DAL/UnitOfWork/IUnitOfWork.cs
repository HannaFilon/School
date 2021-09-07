using School.DAL.Entities;
using School.DAL.Reposirories;
using System.Threading.Tasks;

namespace School.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<Student> StudentRepository { get; }
        IRepository<Teacher> TeacherRepository { get; }
        ICourseRepository CourseRepository { get; }

        public Task SaveChanges();
    }
}
