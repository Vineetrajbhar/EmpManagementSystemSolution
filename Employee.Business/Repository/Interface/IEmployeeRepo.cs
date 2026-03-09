using EmpManagement.API.Dtos.EmployeeDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpManagement.Business.Repository.Interface
{
    public interface IEmployeeRepo
    {
        Task <Employeedto> NewEmployee(int DepartmentId,Employeedto employeedto);
        Task<List<Employeedto>> GetAll();
        Task<Employeedto> GetById(int id);
        Task<Employeedto> UpdateEmployee(int id, Employeedto employeedto);
        Task<Employeedto> DeleteEmployee(int EmployeeId,int DepartmentId);
    }
}
