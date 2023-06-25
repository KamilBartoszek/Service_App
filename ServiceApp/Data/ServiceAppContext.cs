using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServiceApp.Models;

namespace ServiceApp.Data
{
    public class ServiceAppContext : DbContext
    {
        public ServiceAppContext (DbContextOptions<ServiceAppContext> options)
            : base(options)
        {
        }

        public DbSet<ServiceApp.Models.ServiceOrders> ServiceOrders { get; set; } = default!;
    }
}
