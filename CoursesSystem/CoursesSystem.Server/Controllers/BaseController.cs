namespace CoursesSystem.Server.Controllers
{
    using System.Web.Http;

    using CoursesSystem.Data.Repositories;

    public abstract class BaseController : ApiController
    {
        protected ICoursesSystemData data;

        public BaseController(ICoursesSystemData data)
        {
            this.data = data;
        }
    }
}