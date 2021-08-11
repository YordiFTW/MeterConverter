using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using test.Model;

namespace test.DbContexts
{
    public class MeterDbContext : DbContext
    {
        public MeterDbContext(DbContextOptions<MeterDbContext> options)
            : base(options)
        {

        }

        public DbSet<Calculation> Calculations { get; set; }

    }
}