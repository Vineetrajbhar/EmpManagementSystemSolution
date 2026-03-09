using EmpManagement.API.Dtos.EmployeeDto;
using EmpManagement.Business.Repository.implementation;
using EmpManagement.Business.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmpManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo _repo;
        public EmployeeController(IEmployeeRepo repo)
        {
           _repo = repo; 
        }
        [HttpPost]
        public async Task <IActionResult> AddData(int DepartmentId, Employeedto employeedto)
        {
            var result = await _repo.NewEmployee(DepartmentId,employeedto);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> Getdata()
         {
            var emp = await _repo.GetAll();
            return Ok(emp);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> Get(int id)
        {
            var emp = await _repo.GetById(id);
            return Ok(emp);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateData(int id, Employeedto employeedto)
        {
            var emp = await _repo.UpdateEmployee(id, employeedto);
            return Ok(emp);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(int empId, int deptId)
        {
            var result = await _repo.DeleteEmployee(empId, deptId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
