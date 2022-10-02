using Autofac;
using TeacherApp.Web.Models;

namespace TeacherApp.Web
{
    public class WebModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CreateTeacherModel>().AsSelf();
            builder.RegisterType<TeacherListModel>().AsSelf();
            builder.RegisterType<TeacherEditModel>().AsSelf();
            base.Load(builder);
        }

    }
}
