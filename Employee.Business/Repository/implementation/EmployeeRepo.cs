using EmpManagement.API.Dtos.EmployeeDto;
using EmpManagement.Business.Automapper;
using EmpManagement.Business.Repository.Interface;
using EmpManagement.Data.data;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmpManagement.Data.model;
using Microsoft.EntityFrameworkCore;

namespace EmpManagement.Business.Repository.implementation
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly EmpConnection _context;
        private readonly IMapper _mapper;
        public EmployeeRepo(EmpConnection context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Employeedto> DeleteEmployee(int EmployeeId, int DepartmentId)
        {
            var emp = await _context.employees
                .FirstOrDefaultAsync(x=> x.Id == EmployeeId && x.DepartmentId == DepartmentId);
            if (emp == null)
            {
                return null;
            }
            _context.employees.Remove(emp);
            await _context.SaveChangesAsync();
            return _mapper.Map<Employeedto>(emp);
        }
        

        public async Task<List<Employeedto>> GetAll()
        {
            var result = await _context.employees
                .Include(x=> x.Addresses)
                .ToListAsync();

            return _mapper.Map<List<Employeedto>>(result);
        }

        public async Task<Employeedto> GetById(int id)
        {
            var employee = await _context.employees
                .Include(e => e.Addresses)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (employee == null)
                return null;

            return _mapper.Map<Employeedto>(employee);
        }

        public async Task <Employeedto> NewEmployee(int DepartmentId, Employeedto employeedto)
        {
            var result = _context.department
               .FirstOrDefault(x => x.Id == DepartmentId);
            if (result == null)
            {
                return null;
            }
            var emp = _mapper.Map<Employee>(employeedto);
            emp.DepartmentId = DepartmentId;   //Isse employee us department ke andar save hoga.
            await _context.employees.AddAsync(emp);
            await _context.SaveChangesAsync();
            return _mapper.Map<Employeedto>(emp);
        }

        public async Task<Employeedto> UpdateEmployee(int id, Employeedto employeedto)
        {
            var result = await _context.employees
                .FirstOrDefaultAsync (e => e.Id == id);
            result.Name = employeedto.Name;
            result.Salary = employeedto.Salary;
            result.JoinDate = employeedto.JoinDate;
            result.Email = employeedto.Email;
            await _context.SaveChangesAsync();
            return _mapper.Map<Employeedto>(result);
        }
    }
}
