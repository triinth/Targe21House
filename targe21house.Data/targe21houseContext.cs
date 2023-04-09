using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using targe21house.Core.Domain;

namespace targe21house.Data
{
    public class targe21houseContext : DbContext
    {
        public targe21houseContext(DbContextOptions<targe21houseContext> options)
        : base(options) { }

        public DbSet<House> Houses { get; set; }


    }
}
