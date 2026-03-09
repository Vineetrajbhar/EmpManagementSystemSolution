using EmpManagement.Data.model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpManagement.Data.data
{
    public class EmpConnection:DbContext
    {
        public EmpConnection(DbContextOptions<EmpConnection> options): base(options) { }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Address> addresses { get; set; }
        public DbSet<Department> department { get; set; }
    }
}
