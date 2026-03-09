using EmpManagement.Business.Dtos.AddressDto;
using EmpManagement.Business.Dtos.DepartmentDto;

namespace EmpManagement.API.Dtos.EmployeeDto
{
    public class Employeedto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Salary { get; set; }
        public DateOnly JoinDate { get; set; }

        public ICollection<Addressdto> Addresses { get; set; }
    }  
}
