using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TubeStore.Domain.Models;

namespace TubeStore.DB
{
    public class TubeStoreDbContext : IdentityDbContext
    {
        public TubeStoreDbContext(DbContextOptions<TubeStoreDbContext> options)
            : base(options) { }

        public DbSet<Tube> Tubes { get; set; }
    }
}
