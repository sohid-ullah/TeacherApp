using Microsoft.EntityFrameworkCore;
using TeacherApp.Business.DbContexts;
using TeacherApp.Business.Entities;
using TeacherApp.Data;

namespace TeacherApp.Business.Repositories
{
    public class TeacherRepository : Repository<Teacher, int>, ITeacherRepository
    {
        public TeacherRepository(IAppDbContext dbContext) : base((DbContext)dbContext)
        {
        }
    }
}
