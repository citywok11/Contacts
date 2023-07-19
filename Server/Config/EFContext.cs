using Contacts.Server.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Server.Config
{
    public partial class ContactsDbContext : DbContext
    {
        public ContactsDbContext()
        {
        }

        public ContactsDbContext(DbContextOptions<ContactsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.FirstName).IsRequired();
                entity.Property(e => e.LastName).IsRequired();

            });

            OnModelCreatingPartial(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
