using AutoMapper;
using EmpManagement.Business.Dtos.AddressDto;
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
    public class AddressRepo : IAddress
    {
        private readonly EmpConnection _context;
        private readonly IMapper _mapper;
        public AddressRepo(EmpConnection context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Addressdto> AddAddressdto(int EmployeeID, AddAddressdto addAddressdto)
        {
            var emp = await _context.employees
        .FirstOrDefaultAsync(x => x.Id == EmployeeID);

            if (emp == null)
            {
                return null;
            }

            var ads = _mapper.Map<Address>(addAddressdto);

            ads.EmployeeId = EmployeeID;

            await _context.addresses.AddAsync(ads);
            await _context.SaveChangesAsync();

            return _mapper.Map<Addressdto>(ads);
        }
        public async Task<Addressdto> DeleteAddress(int AddressID,int EmployeeID)
        {
            var ads = await _context.addresses
                .FirstOrDefaultAsync(x=> x.Id == AddressID && x.EmployeeId == EmployeeID);
            if (ads == null)
            {
                return null;
            }
            _context.addresses.Remove(ads);
            await _context.SaveChangesAsync();
            return _mapper.Map<Addressdto>(ads);
        }

        public async Task<Addressdto> UpdateAddres(int id, UpdateAddressdto updateAddressdto)
        {
            var ads = await _context.addresses
                .FirstOrDefaultAsync(x => x.Id == id);
            if (ads == null)
            {
                return null;
            }
            ads.City = updateAddressdto.City;
            ads.State = updateAddressdto.State;
            ads.Country = updateAddressdto.Country;
            await _context.SaveChangesAsync();
            return _mapper.Map<Addressdto>(ads);
        }
    }
}
