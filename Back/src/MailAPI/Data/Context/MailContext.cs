using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;

namespace MailAPI.Data.Context
{
    public class MailContext : DbContext
    {
        public MailContext(DbContextOptions<MailContext> options) : base(options)
        {
        }

        public DbSet<Email> Email { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Email>().HasKey(x => x.Id);
        }
    }
}