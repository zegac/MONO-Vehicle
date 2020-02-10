using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Http;

namespace Vehicle.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        #region Methods

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            // builder.RegisterType<Test>().AsSelf().InstancePerRequest();
            builder.RegisterType<Mapper>().As<IMapper>();
            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            }));
            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper())
                    .As<IMapper>()
                    .SingleInstance();

            var path = AppDomain.CurrentDomain.BaseDirectory;
            //var path = @"C:\Users\Student\Desktop\New folder (2)\vehicle\Vehicle.WebApi";
            var assemblies = Directory.GetFiles(path, "Vehicle.*.dll", SearchOption.AllDirectories).Select(Assembly.LoadFrom).ToArray();
            builder.RegisterAssemblyModules(assemblies);

            //var container = builder.Build();
            //var resolver = new AutofacWebApiDependencyResolver(container);
            //GlobalConfiguration.Configuration.DependencyResolver = resolver;
            //GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);
            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }

        #endregion Methods
    }
}