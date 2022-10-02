using TeacherApp.Business.BusinessObjects;

namespace TeacherApp.Business.Services
{
    public interface ITeacherService
    {
        (int total, int totalDisplay, IList<Teacher> records)
         GetTeachers(int pageIndex, int pageSize, string searchText, string orderBy);
        Teacher GetTeacher(int teacherId);
        bool EditTeacher(Teacher teacher);
        bool SaveTeacher(Teacher teacher);
        bool DeleteTeacher(int teacherId);
    }
}
