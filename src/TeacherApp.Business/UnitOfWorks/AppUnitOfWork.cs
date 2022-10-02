using Microsoft.EntityFrameworkCore;
using TeacherApp.Business.DbContexts;
using TeacherApp.Business.Repositories;
using TeacherApp.Data;

namespace TeacherApp.Business.UnitOfWorks
{
    public class AppUnitOfWork : UnitOfWork, IAppUnitOfWork
    {
        public ITeacherRepository Teachers { get; private set; }

        public AppUnitOfWork(IAppDbContext dbContext,
            ITeacherRepository teachers) : base((DbContext)dbContext)
        {
            Teachers = teachers;
        }
    }
}
