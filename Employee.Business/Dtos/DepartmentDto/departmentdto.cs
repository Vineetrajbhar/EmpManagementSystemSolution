using EmpManagement.API.Dtos.EmployeeDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpManagement.Business.Dtos.DepartmentDto
{
    public class departmentdto
    {
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string Description { get; set; }
        public ICollection<Employeedto> Employees { get; set; }
    }
}
