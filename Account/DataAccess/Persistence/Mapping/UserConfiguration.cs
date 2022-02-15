using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Persistence.Mapping
{
    public class UserConfiguration
    {
        public static void Configure(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasKey(x => new { x.Id } );

            builder.Entity<User>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<User>()
                .Property(u => u.BirthDay)
                .IsRequired();

            builder.Entity<User>()
                .Property(u => u.CreatedDate)
                .IsRequired();

            builder.Entity<User>()
                .Property(u => u.FirstName)
                .IsRequired();

            builder.Entity<User>()
                .Property(u => u.LastName)
                .IsRequired();

            builder.Entity<User>()
                .Property(u => u.GenderId)
                .IsRequired();
        }
    }
}
