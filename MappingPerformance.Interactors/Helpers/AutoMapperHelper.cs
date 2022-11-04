using AutoMapper;
using MappingPerformance.Entities;
using MappingPerformance.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MappingPerformance.Interactors.Helpers
{
    public class AutoMapperHelper : Profile
    {
        public AutoMapperHelper()
        {
            CreateMap<Employee, EmployeeInformation>().ReverseMap();
        }
    }
}
