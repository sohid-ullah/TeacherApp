
using AutoMapper;
using TeacherApp.Business.BusinessObjects;
using TeacherEO = TeacherApp.Business.Entities.Teacher;
using TeacherApp.Business.UnitOfWorks;

namespace TeacherApp.Business.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IAppUnitOfWork _applicationUnitOfWork;
        private readonly IMapper _mapper;

        public TeacherService(IAppUnitOfWork applicationUnitOfWork,
            IMapper mapper)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
            _mapper = mapper;
        }
        public TeacherService()
        {

        }

        public bool DeleteTeacher(int teacherId)
        {
            var count = _applicationUnitOfWork.Teachers.GetCount(x => x.Id == teacherId);
            if (count == 0)
                throw new DataNotFoundException();

            _applicationUnitOfWork.Teachers.Remove(teacherId);
            _applicationUnitOfWork.Save();
            return true;
        }

        public bool EditTeacher(Teacher teacher)
        {
            var teacherEO = _applicationUnitOfWork.Teachers.GetById(teacher.Id);
            _mapper.Map(teacher, teacherEO);
            _applicationUnitOfWork.Save();
            return true;
        }

        public Teacher GetTeacher(int teacherId)
        {
            var teacherEO = _applicationUnitOfWork.Teachers.GetById(teacherId);
            var teacher = _mapper.Map<Teacher>(teacherEO);
            return teacher;
        }

        public (int total, int totalDisplay, IList<Teacher> records) GetTeachers(int pageIndex, int pageSize, string searchText, string orderBy)
        {
            var result = _applicationUnitOfWork.Teachers.
                GetDynamic(x => x.Name.Contains(searchText), orderBy, string.Empty, pageIndex,
                pageSize);
            IList<Teacher> teachers = new List<Teacher>();

            foreach (var item in result.data)
            {
                var courseCategory = _mapper.Map<Teacher>(item);
                teachers.Add(courseCategory);
            }
            return (result.total, result.totalDisplay, teachers);
        }

        public bool SaveTeacher(Teacher teacher)
        {
            var teacherEO = _mapper.Map<TeacherEO>(teacher);
            _applicationUnitOfWork.Teachers.Add(teacherEO);
            _applicationUnitOfWork.Save();
            return true;
        }
    }
}
