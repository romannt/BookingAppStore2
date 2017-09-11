using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookingAppStore.Models
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }

    class BookDbInitializer : DropCreateDatabaseAlways<BookContext>
    {
        protected override void Seed(BookContext context)
        {
            context.Books.Add(new Book { Name = "Война и мир", Author = "Л. Толстой", Price = 220 });
            context.Books.Add(new Book { Name = "Отцы и дети", Author = "И. Тургеньев", Price = 180 });
            context.Books.Add(new Book { Name = "Чайка", Author = "А. Чехов", Price = 150 });
            base.Seed(context);
        }
    }
}