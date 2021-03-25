using ChildrensBookList.Models;
using Microsoft.EntityFrameworkCore;

namespace ChildrensBookList.Data {

    public class ChildrensBookListContext : DbContext {

        public ChildrensBookListContext(DbContextOptions<ChildrensBookListContext> opt) : base(opt) {

        }

        // This is a representation of the Book model in the database.
        // This is done with a DbSet property
        public DbSet<Book> Books { get; set; }
    }

}