using AutoMapper;
using Company_Mangement_System.Dtos;
using Company_Mangement_System.Models;

namespace Company_Mangement_System.Mapping
{
    public class employeeprojectProfile:Profile
    {
        public employeeprojectProfile()
        {
            CreateMap<EmployeeProject, CreateEmployeeProjectDto>().ReverseMap();
            CreateMap<EmployeeProject, EmployeeProjectDto>().ReverseMap();
            CreateMap<EmployeeProject, UpdateEmployeeProjectDto>().ReverseMap();
        }
    }
}
