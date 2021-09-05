using School.DAL.Entities;
using School.DAL.Reposirories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<Student> StudentRepository { get; }
        IRepository<Teacher> TeacherRepository { get; }
        IRepository<Course> CourseRepository { get; }

        public Task SaveChanges();
    }
}
