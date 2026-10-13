using AutoMapper;
using Company_Mangement_System.Dtos;
using Company_Mangement_System.Models;

namespace Company_Mangement_System.Mapping
{
    public class DepartmentProfile:Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department,CreateDepartmentDto>().ReverseMap();
           CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Department, UpdateDepartmentDto>().ReverseMap();
        }
    }
}
