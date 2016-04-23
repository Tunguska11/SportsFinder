using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using SportsFinder.Models;
using System;
using System.ComponentModel.DataAnnotations;


namespace SportsFinder.Data
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions options)
        : base(options)
        {
        }

        public DbSet<Sport> Sport { get; set; }
        public DbSet<SportEvent> SportEvent { get; set; }
    }
}
