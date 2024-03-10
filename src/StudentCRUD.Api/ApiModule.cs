using Autofac;
using StudentCRUD.Api.RequestHandlers.StudentHandler;

namespace StudentCRUD.Api
{
    public class ApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StudentCreateRequestHandler>().AsSelf();
            builder.RegisterType<StudentListRequestHandler>().AsSelf();

            base.Load(builder);
        }
    }
}
