﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PracticeShop.Models
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Image> UserIcons { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}