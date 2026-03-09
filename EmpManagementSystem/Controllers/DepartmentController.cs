using EmpManagement.Business.Dtos.DepartmentDto;
using EmpManagement.Business.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EmpManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepo _repo;
        public DepartmentController(IDepartmentRepo repo)
        {
            _repo = repo;
        }
        [HttpPost]
        public async Task<IActionResult> AddDepartment(departmentdto departmentdto)
        {
            var result = await _repo.AddData(departmentdto);
            return Ok(result);
        } 
        [HttpGet]
        public async Task<IActionResult> GetData()
        {
            var result = await _repo.GetAll();
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteData(int Id)
        {
            var result = await _repo.Deletedata(Id);
            return Ok(result);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetDataById(int id)
        {
            var result = await _repo.GetById(id);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Updatedata(int id, UpdateDepartmentdto update)
        {
            var result = await _repo.UpdateData(id, update);
            return Ok(result);
        }
    } 
}
