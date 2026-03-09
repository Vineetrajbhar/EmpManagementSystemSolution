using EmpManagement.API.Dtos.EmployeeDto;
using EmpManagement.Business.Dtos.DepartmentDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpManagement.Business.Repository.Interface
{
    public interface IDepartmentRepo
    {
        Task<departmentdto> AddData(departmentdto departmentdto);
        Task<List<departmentdto>> GetAll();
        Task<departmentdto> GetById(int id);
        Task<departmentdto> Deletedata(int id);
        Task<departmentdto> UpdateData(int id,UpdateDepartmentdto departmentdto);
    }
}
