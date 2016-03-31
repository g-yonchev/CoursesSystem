using CoursesSystem.Data.Models;
using CoursesSystem.Server.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace CoursesSystem.Server.Models.Courses
{
    public class CourseResponseModel : IMapFrom<CoursePeriod>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration
                .CreateMap<CoursePeriod, CourseResponseModel>()
                .ForMember(x => x.Code, opts => opts.MapFrom(x => x.Course.Code))
                .ForMember(x => x.Name, opts => opts.MapFrom(x => x.Course.Name));
        }
    }
}