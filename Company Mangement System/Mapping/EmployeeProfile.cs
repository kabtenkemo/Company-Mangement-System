using AutoMapper;
using Company_Mangement_System.Dtos;
using Company_Mangement_System.Models;

namespace Company_Mangement_System.Mapping
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, CreateEmployeeDto>().ReverseMap();
        }
    }
}
