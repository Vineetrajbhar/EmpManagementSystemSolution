using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpManagement.Data.model
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Salary { get; set; }
        public DateOnly JoinDate { get; set; }

        public ICollection<Address> Addresses { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
