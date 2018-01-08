using AutoMapper;
using MvcTreeView.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcTreeView.Models
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<MappingProfile>();
                // ignore all unmapped properties globally
                // x.ForAllMaps((map, exp) => exp.ForAllOtherMembers(opt => opt.Ignore()));
            });

            Mapper.Configuration.AssertConfigurationIsValid();
        }
    }
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmpHierarchy, Employee>()
               .ForMember(vm => vm.Id, map => map.MapFrom(m => m.ID))
               .ForMember(vm => vm.Name, map => map.MapFrom(m => m.Name))
               .ForMember(vm => vm.ManagerId, map => map.MapFrom(m => m.ManagerId))
               .DisableCtorValidation();
        }
    }
}