using AutoMapper;
using Company_Mangement_System.Dtos;
using Company_Mangement_System.Models;

namespace Company_Mangement_System.Mapping
{
    public class ProjectProfile:Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, CreateProjectDto>().ReverseMap();
            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<Project, UpdateProjectDto>().ReverseMap();
        }
    }
}
