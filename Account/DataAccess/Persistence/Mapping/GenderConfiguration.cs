using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Persistence.Mapping
{
    public class GenderConfiguration
    {
        public static void Configure(ModelBuilder builder)
        {
            builder.Entity<Gender>()
                .HasKey(x => x.Id);

            builder.Entity<Gender>()
                .Property(g => g.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<Gender>()
                .Property(g => g.Name)
                .IsRequired();
        }
    }
}
