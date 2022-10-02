using AutoMapper;
using TeacherApp.Business.BusinessObjects;
using EO = TeacherApp.Business.Entities;

namespace TeacherApp.Web
{
    public class BusinessProfile : Profile
    {
        public BusinessProfile()
        {
            CreateMap<Teacher, EO.Teacher>().ReverseMap();
        }
    }
}
