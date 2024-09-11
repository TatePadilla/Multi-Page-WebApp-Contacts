using Microsoft.EntityFrameworkCore;
using Multi_Page_WebApp_Contacts.Models;

namespace Multi_Page_WebApp_Contacts.Models
{
    // The DbContext class contains the DbSet method that allows model classes to map with DB's.
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options) : base(options)
        { }
        public DbSet<Contact> Contacts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Setting intial seed data (NOT REQUIRED).
            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    ContactId = 1,
                    Name = "Tate Padilla",
                    PhoneNumber = "1234567890",
                    Address = "Tate's House",
                    Note = "Don't visit."
                },
                new Contact
                {
                    ContactId = 2,
                    Name = "Katy Perry",
                    PhoneNumber = "0987654321",
                    Address = "123, Main St. LA, 50222",
                    Note = "California Girls are undeniable."
                }
            );
        }
    }
}
