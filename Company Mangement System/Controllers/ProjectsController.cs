using AutoMapper;
using Company_Mangement_System.Dtos;
using Company_Mangement_System.Models;
using Company_Mangement_System.Repo.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company_Mangement_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProjectsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {
            var projects = await _unitOfWork.Projects.GetAllAsync();
            var projectDtos = _mapper.Map<IEnumerable<ProjectDto>>(projects);
            return Ok(projectDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            var project = await _unitOfWork.Projects.GetByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            var projectDto = _mapper.Map<ProjectDto>(project);
            return Ok(projectDto);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> CreateProject([FromBody] CreateProjectDto dto)
        {
            var project = _mapper.Map<Project>(dto);
            await _unitOfWork.Projects.AddAsync(project);
            await _unitOfWork.save();
            return Created();
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateProject(int id, [FromBody] UpdateProjectDto dto)
        {
            var project = await _unitOfWork.Projects.GetByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            _mapper.Map(dto, project);
            await _unitOfWork.save();
            return NoContent();
        }

    }
}
