using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using test.Model;

namespace MeterConverter.DbContexts
{
    public class MeterDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public MeterDbContext(DbContextOptions<MeterDbContext> options)
            : base(options)
        {

        }

        public Microsoft.EntityFrameworkCore.DbSet<Calculation> Calculations { get; set; }

    }
}