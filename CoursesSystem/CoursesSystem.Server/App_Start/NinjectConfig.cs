namespace CoursesSystem.Server
{
    using System;
    using System.Web;

    using CoursesSystem.Data;
    using CoursesSystem.Data.Repositories;
    using CoursesSystem.Server.Infrastructure;

    using Ninject;
    using Ninject.Extensions.Conventions;
    using Ninject.Web.Common;

    public static class NinjectConfig
    {
        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                ObjectFactory.Initialize(kernel);
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        private static void RegisterServices(KernelBase kernel)
        {
            kernel
                .Bind(typeof(IDbRepository<>))
                .To(typeof(DbRepository<>));

            kernel
                .Bind<ICoursesSystemDbContext>()
                .To<CoursesSystemDbContext>();

            kernel.Bind(x => x.From("CoursesSystem.Services")
                                .SelectAllClasses()
                                .BindDefaultInterface());
        }
    }
}