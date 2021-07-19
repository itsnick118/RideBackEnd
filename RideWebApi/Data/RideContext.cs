using Microsoft.EntityFrameworkCore;
using RideWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RideWebApi.Data
{
    public class RideContext : DbContext
    { 
            public RideContext(DbContextOptions options) : base(options)
            {

            }
            public DbSet<Appuser> Appusers { get; set; }
        
    }
}
