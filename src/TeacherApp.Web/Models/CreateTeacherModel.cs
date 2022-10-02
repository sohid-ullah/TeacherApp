using Autofac;
using AutoMapper;
using System.ComponentModel.DataAnnotations;
using TeacherApp.Business.BusinessObjects;
using TeacherApp.Business.Services;

namespace TeacherApp.Web.Models
{
    public class CreateTeacherModel
    {
        private ITeacherService _teacherService;
        private IMapper _mapper;

        [MaxLength(150)]
        public string Name { get; set; }
        [MaxLength(150)]
        public string Address { get; set; }
        [MaxLength(25)]
        public string Tel { get; set; }

        public CreateTeacherModel(ITeacherService teacherService,
            IMapper mapper)
        {
            _teacherService = teacherService;
            _mapper = mapper;
        }
        public CreateTeacherModel()
        {

        }
        public void Resolve(ILifetimeScope scope)
        {
            _teacherService = scope.Resolve<ITeacherService>();
            _mapper = scope.Resolve<IMapper>();
        }
        public void CreateTeacher()
        {
            var teacher = _mapper.Map<Teacher>(this);
            _teacherService.SaveTeacher(teacher);
        }
    }
}
