using Contacts.Server.Entities;
using System.Data.Entity;

namespace Contacts.Server.Config
{
    public class ContactsContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
    }
}