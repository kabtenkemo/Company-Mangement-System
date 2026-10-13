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
    public class employeeprojectsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public employeeprojectsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateEmployeeProject([FromBody] CreateEmployeeProjectDto createEmployeeProjectDto)
        {
            var employeeProject = _mapper.Map<EmployeeProject>(createEmployeeProjectDto);
            await _unitOfWork.EmployeeProjects.AddAsync(employeeProject);
            await _unitOfWork.save();
            return Created();
        }

        [HttpGet("by-employee/{employeeId}")]
        public async Task<ActionResult<IEnumerable<EmployeeProject>>> GetEmployeeProjectsByEmployeeId(int employeeId)
        {
            var employeeProjects = await _unitOfWork.EmployeeProjects.GetEmployeeProjectsByEmployeeIdAsync(employeeId);
            var employeeProjectDtos = _mapper.Map<IEnumerable<EmployeeProjectDto>>(employeeProjects);
            return Ok(employeeProjectDtos);
        }


    }
}
