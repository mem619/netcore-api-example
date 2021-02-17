using Microsoft.EntityFrameworkCore;
using WB.WAPP.SEG.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace WB.WAPP.SEG.Model
{
    public class SEGContext : DbContext
    {
        private readonly string SCHEMA = "SEG";

        public SEGContext(DbContextOptions<SEGContext> options)
            :base(options)
        { }

        public virtual DbSet<Parameter> Parameters { get; set; }
        public virtual DbSet<Sample> Samples { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
            modelBuilder.HasDefaultSchema(SCHEMA);
        }
    }
}
