using BorrowBikeWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BorrowBikeWebApp
{
    public class BorrowBikeWebAppContext : DbContext
    {
        public DbSet<Bike> Bikes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server =(localdb)\mssqllocaldb; Database = BorrowBikeDB; Trusted_Connection = True"
                );
            base.OnConfiguring(optionsBuilder);
        }
    }
}
