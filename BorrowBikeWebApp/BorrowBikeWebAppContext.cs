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
        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                //@"Server =(localdb)\mssqllocaldb; Database = BorrowBikeDB; Trusted_Connection = True"
                @"Server =theborrowbikedb.cakssctiyx9x.us-west-2.rds.amazonaws.com,1433; Database = BorrowBikeDB; User Id=leunga18; Password=theborrowbike"
                );


            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<BorrowBikeWebApp.Models.User> User { get; set; }
    }
}
