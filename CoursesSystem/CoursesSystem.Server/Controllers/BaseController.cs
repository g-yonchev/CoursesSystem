using CoursesSystem.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CoursesSystem.Server.Controllers
{
    public abstract class BaseController : ApiController
    {
        protected ICoursesSystemData data;

        public BaseController(ICoursesSystemData data)
        {
            this.data = data;
        }
    }
}