using AutoMapper;
using EmpManagement.API.Dtos.EmployeeDto;
using EmpManagement.Business.Dtos.DepartmentDto;
using EmpManagement.Business.Repository.Interface;
using EmpManagement.Data.data;
using EmpManagement.Data.model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpManagement.Business.Repository.implementation
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly EmpConnection _connection;
        private readonly IMapper _mapper;
        public DepartmentRepo(EmpConnection connection, IMapper mapper)
        {
            _connection = connection;
            _mapper = mapper;
        }
        public async Task<departmentdto> AddData(departmentdto departmentdto)
        {
            var emp = _mapper.Map<Department>(departmentdto);
            await _connection.department.AddAsync(emp);
            await _connection.SaveChangesAsync();
            return departmentdto;
        }

        public async Task<departmentdto> Deletedata(int id)
        {
            var result = await _connection.department
                .FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
                return null;

            _connection.department.Remove(result);
            await _connection.SaveChangesAsync();

            return _mapper.Map<departmentdto>(result);
        }

        public async Task<List<departmentdto>> GetAll()
        {
            var result = await _connection.department
                .Include(x=> x.Employees)
                .ThenInclude(e=> e.Addresses)
                .ToListAsync();
            return _mapper.Map<List<departmentdto>>(result);
                
        }

        public async Task<departmentdto> GetById(int id)
        {
            var result = await _connection.department
                .Include (x=> x.Employees)
                .ThenInclude(e=> e.Addresses)
                .FirstOrDefaultAsync(x=> x.Id ==id);
            if (result == null)
            {
                return null;
            }
            return _mapper.Map<departmentdto> (result);
        }

        public async Task<departmentdto> UpdateData(int id, UpdateDepartmentdto departmentdto)
        {
           var result = await _connection.department
                .FirstOrDefaultAsync(x=> x.Id ==id);
            if (result == null)
            {
                return null;
            }
            result.DepartmentName = departmentdto.DepartmentName;
            result.Description = departmentdto.Description;
            await _connection.SaveChangesAsync();
            return _mapper.Map<departmentdto>(result);
        }
    }
}
