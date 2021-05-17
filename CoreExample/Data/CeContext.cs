using CoreExample.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreExample.Data
{
    public class CeContext : IdentityDbContext<User>
    {
        
        private readonly IConfiguration _config;

        public CeContext(IConfiguration config)
        {
            this._config = config;
        }
        public DbSet<Product> products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_config["ConnectionStrings:conn"]);
        }
    }
}
