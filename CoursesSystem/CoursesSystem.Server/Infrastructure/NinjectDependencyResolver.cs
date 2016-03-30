namespace CoursesSystem.Server.Infrastructure
{
    using System.Web.Http.Dependencies;

    using Ninject;

    public class NinjectDependencyResolver : NinjectDependencyScope, IDependencyResolver
    {
        public IKernel kernel;

        public NinjectDependencyResolver(IKernel kernel) : base(kernel)
        {
            this.kernel = kernel;
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectDependencyScope(this.kernel.BeginBlock());
        }
    }
}