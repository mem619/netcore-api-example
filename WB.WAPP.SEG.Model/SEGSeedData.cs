using Microsoft.EntityFrameworkCore;
using WB.WAPP.SEG.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace WB.WAPP.SEG.Model
{
    public static class SEGSeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parameter>().HasData(
                new Parameter
                {
                    Id = 1,
                    Name = "APP_NAME",
                    Value = "SEG Application",
                    Description = "Valor de ejemplo.",
                    Status = true,
                    CreatedDate = DateTime.Now,
                    UserCreated = "SYSTEM"
                }
            );
        }
    }
}
