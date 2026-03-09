using EmpManagement.Business.Dtos.AddressDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpManagement.Business.Repository.Interface
{
    public interface IAddress
    {
        Task<Addressdto> AddAddressdto(int EmployeeID,AddAddressdto addAddressdto);
        Task<Addressdto> UpdateAddres(int id, UpdateAddressdto updateAddressdto);
        Task<Addressdto> DeleteAddress(int AddressID,int EmployeeID);
    }
}
