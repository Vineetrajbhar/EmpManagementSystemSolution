using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpManagement.API.Dtos.EmployeeDto;
using EmpManagement.Data.model;
using EmpManagement.Business.Dtos.DepartmentDto;
using EmpManagement.Business.Dtos.AddressDto;

namespace EmpManagement.Business.Automapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        {
            CreateMap<Employeedto,Employee>().ReverseMap();
            CreateMap<departmentdto, Department>().ReverseMap();
            CreateMap<Addressdto, Address>().ReverseMap();
            CreateMap<AddAddressdto,Address>().ReverseMap();
        }
    }
}
