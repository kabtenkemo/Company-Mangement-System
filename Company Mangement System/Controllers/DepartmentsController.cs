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
    public class DepartmentsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DepartmentsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> CreateDepartment([FromBody] CreateDepartmentDto dto)
        {
            var department = _mapper.Map<Department>(dto);
            await _unitOfWork.Departments.AddAsync(department);
            await _unitOfWork.save();
            return Created();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            var departments = await _unitOfWork.Departments.GetAllAsync();
            var departmentDtos = _mapper.Map<IEnumerable<DepartmentDto>>(departments);
            return Ok(departmentDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            var department = await _unitOfWork.Departments.GetByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            var departmentDto = _mapper.Map<DepartmentDto>(department);
            return Ok(departmentDto);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateDepartment(int id, [FromBody] UpdateDepartmentDto dto)
        {
            var department = await _unitOfWork.Departments.GetByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            _mapper.Map(dto, department);
            await _unitOfWork.Departments.UpdateAsync(department);
            await _unitOfWork.save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteDepartment(int id)
        {
            var department = await _unitOfWork.Departments.GetByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            await _unitOfWork.Departments.DeleteAsync(id);
            await _unitOfWork.save();

            return NoContent();
        }


    }
}
