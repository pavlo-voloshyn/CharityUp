﻿using DataAccess.Persistence.Mapping;
using DataAccess.Persistence.Seeding;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Persistence
{
    public class AccountDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public DbSet<Gender> Genders { get; set; }

        public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            GenderConfiguration.Configure(builder);
            UserConfiguration.Configure(builder);

            AccountDbSeeding.Seed(builder);
        }
    }
}
