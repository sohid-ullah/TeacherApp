using AutoMapper;
using TeacherApp.Business.BusinessObjects;
using TeacherApp.Web.Models;

namespace TeacherApp.Web
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<Teacher, CreateTeacherModel>().ReverseMap();
            CreateMap<Teacher, TeacherEditModel>().ReverseMap();
        }
    }
}
