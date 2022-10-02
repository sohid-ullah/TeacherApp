using Autofac;
using TeacherApp.Business.DbContexts;
using TeacherApp.Business.Repositories;
using TeacherApp.Business.Services;
using TeacherApp.Business.UnitOfWorks;

namespace TeacherApp.Business
{
    public class BusinessModule : Module
    {
        private readonly string _connectionString;
        private readonly string _assemblyName;
        public BusinessModule(string connectionString, string assemblyName)
        {
            _connectionString = connectionString;
            _assemblyName = assemblyName;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AppDbContext>().AsSelf().
                WithParameter("connectionString", _connectionString).
                WithParameter("assemblyName", _assemblyName).
                InstancePerLifetimeScope();

            builder.RegisterType<AppDbContext>().As<IAppDbContext>()
         .WithParameter("connectionString", _connectionString)
         .WithParameter("assemblyName", _assemblyName)
         .InstancePerLifetimeScope();

            builder.RegisterType<TeacherRepository>().As<ITeacherRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AppUnitOfWork>().As<IAppUnitOfWork>()
                .InstancePerLifetimeScope(); 

            builder.RegisterType<TeacherService>().As<ITeacherService>()
                .InstancePerLifetimeScope(); 
            base.Load(builder);
        }

    }
}
