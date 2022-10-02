using Microsoft.EntityFrameworkCore;

namespace TeacherApp.Data
{
    public abstract class UnitOfWork : IUnitOfWork
    {
        protected readonly DbContext _dbContext;
        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual void Dispose()
        {
            _dbContext.Dispose();
        }
        public virtual void Save()
        {
            try
            {
                var x = _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                var y = ex.Message;
            }
        }
    }
}
