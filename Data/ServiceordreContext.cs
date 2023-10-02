using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Serviceordre.Models;

namespace Serviceordre.Data
{
    public class ServiceordreContext : DbContext
    {
        public ServiceordreContext (DbContextOptions<ServiceordreContext> options)
            : base(options)
        {
        }

        public DbSet<Serviceordre.Models.ServiceOrder> ServiceOrder { get; set; } = default!;
    }
}
