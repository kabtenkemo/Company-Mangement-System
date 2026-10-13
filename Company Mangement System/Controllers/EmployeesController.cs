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
    public class EmployeesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public EmployeesController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> CreateEmployee([FromBody] CreateEmployeeDto employee)
        {
            var entity =  _mapper.Map<Employee>(employee);
            await _unitOfWork.Employees.AddAsync(entity);
            await _unitOfWork.save();
            return Created();
        }
        [HttpGet]

        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            var employees = await _unitOfWork.Employees.GetAllAsync();
            var employeeDtos = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return Ok(employeeDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _unitOfWork.Employees.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return Ok(employeeDto);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> UpdateEmployee(int id, [FromBody] UpdateEmployeeDto employee)
        {
            var entity = await _unitOfWork.Employees.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            _mapper.Map(employee, entity);
            await _unitOfWork.Employees.UpdateAsync(entity);
            await _unitOfWork.save();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var entity = await _unitOfWork.Employees.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            await _unitOfWork.Employees.DeleteAsync(id);
            await _unitOfWork.save();
            return NoContent();
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Employee>>> SearchEmployees([FromQuery] string name)
        {
            var employees = await _unitOfWork.Employees.SearchAsync(name);
            var employeeDtos = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return Ok(employeeDtos);
        }

        [HttpGet("by-department/{departmentId}")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeesByDepartmentId(int departmentId)
        {
            var employees = await _unitOfWork.Employees.GetEmployeesByDepartmentIdAsync(departmentId);
            var employeeDtos = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return Ok(employeeDtos);
        }




    }
}
