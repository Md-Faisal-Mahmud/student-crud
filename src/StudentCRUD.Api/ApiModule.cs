using Autofac;
using StudentCRUD.Api.RequestHandlers.StudentHandler;

namespace StudentCRUD.Api
{
    public class ApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StudentCreateRequestHandler>().AsSelf();

            base.Load(builder);
        }
    }
}
