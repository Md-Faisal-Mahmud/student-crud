using Autofac;
using StudentCRUD.Application.Features.StudentManagement.Services;

namespace StudentCRUD.Application
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StudentManagementService>().As<IStudentManagementService>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
