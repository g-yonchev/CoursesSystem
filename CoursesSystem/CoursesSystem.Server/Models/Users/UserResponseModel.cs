using CoursesSystem.Data.Models;
using CoursesSystem.Server.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace CoursesSystem.Server.Models.Users
{
    public class UserResponseModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public IEnumerable<string> Courses { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration
                .CreateMap<User, UserResponseModel>()
                .ForMember(x => x.Name, opts => opts.MapFrom(x => x.FirstName + " " + x.LastName))
                .ForMember(x => x.Courses, opts => opts.MapFrom(x => x.CoursePeriods.Select(c => c.Course.Name)));
        }
    }
}