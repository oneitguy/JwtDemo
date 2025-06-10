﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Data;
namespace Data
{
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<City> Cities { get; set; }
}
}