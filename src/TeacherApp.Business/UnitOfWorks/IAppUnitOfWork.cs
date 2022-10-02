using TeacherApp.Business.Repositories;
using TeacherApp.Data;

namespace TeacherApp.Business.UnitOfWorks
{
    public interface IAppUnitOfWork: IUnitOfWork
    {
        ITeacherRepository Teachers { get; }
    }
}
