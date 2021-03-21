using ChildrensBookList.Models;
using Microsoft.EntityFrameworkCore;

namespace ChildrensBookList.Data {

    public class ChildrensBookListContext : DbContext {

        public ChildrensBookListContext(DbContextOptions<ChildrensBookListContext> opt) : base(opt) {

        }

        public DbSet<Book> Books { get; set; }
    }

}