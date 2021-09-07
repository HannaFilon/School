using Microsoft.EntityFrameworkCore;
using School.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.DAL.Reposirories
{
    public sealed class CourseRepository: Repository<Course>, ICourseRepository
    {
        public CourseRepository(SchoolContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<Course>> GetAll()
        {
            var objList = await _dbSet.AsNoTracking().OrderBy(c => c.Title).ToListAsync();

            return objList;
        }
    }
}
