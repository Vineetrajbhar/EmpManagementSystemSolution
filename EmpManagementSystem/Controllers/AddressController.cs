using EmpManagement.Business.Dtos.AddressDto;
using EmpManagement.Business.Repository.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmpManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddress _address;
        public AddressController(IAddress address)
        {
            _address = address;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAddress(int id, UpdateAddressdto dto)
        {
            var result = await _address.UpdateAddres(id, dto);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddAddress(int EmployeeId, AddAddressdto addAddressdto)
        {
            var result = await _address.AddAddressdto(EmployeeId, addAddressdto);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAddress(int AddressID, int EmployeeID)
        {
            var result = await _address.DeleteAddress(AddressID, EmployeeID);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}