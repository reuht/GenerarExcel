﻿using Microsoft.EntityFrameworkCore;
using WebApiProof.Models;

namespace WebApiProof.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 

        }

        public DbSet<User> Users { get; set; }
    }
}
