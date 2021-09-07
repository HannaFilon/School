using School.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.DAL.Reposirories
{
    public interface ICourseRepository: IRepository<Course>
    {
        public new Task<IEnumerable<Course>> GetAll();
    }
}
