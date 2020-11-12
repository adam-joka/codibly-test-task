using  Domain.Emails.Model.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace  Domain.Emails.Data
{
    public class EmailsDataContext : DbContext
    {
        public EmailsDataContext(DbContextOptions<EmailsDataContext> options)
            : base(options) { }

        public DbSet<Email> Emails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Email>()
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
