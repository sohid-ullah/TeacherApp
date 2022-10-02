using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.Cors.Infrastructure;
using TeacherApp.Business.BusinessObjects;
using TeacherApp.Business.Services;

namespace TeacherApp.Web.Models
{
    public class TeacherEditModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Tel { get; set; }

        private ITeacherService _teacherService;
        private IMapper _mapper;

        public TeacherEditModel()
        {

        }
        public TeacherEditModel(ITeacherService teacherService, 
            IMapper mapper)
        {
            _teacherService = teacherService;
            _mapper = mapper;
        }
        public void LoadData(int id)
        {
            var data = _teacherService.GetTeacher(id);
            _mapper.Map(data, this);
        }
        public void EditCourse()
        {
            var teacher = _mapper.Map<Teacher>(this);
            _teacherService.EditTeacher(teacher);
        }

        public void Resolve(ILifetimeScope scope)
        {
            _teacherService = scope.Resolve<ITeacherService>();
            _mapper = scope.Resolve<IMapper>();
        }
    }
}
