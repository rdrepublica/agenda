using System;
using Contacts.Models;
using Microsoft.EntityFrameworkCore;

namespace Contacts
{
    public class ContactDatabaseContext:DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<LocalEvent> LocalEvents { get; set; }

        public ContactDatabaseContext(DbContextOptions options):base(options)
        {
        }
    }
}
