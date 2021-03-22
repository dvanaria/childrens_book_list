// This is an interface definition to present a contract
// for accessing the repository layer.
// This interface can be implemented in different ways (a SQL Server
// implementation for example)

using System.Collections.Generic;
using ChildrensBookList.Models;

namespace ChildrensBookList.Data {

    public interface IChildrensBookListRepo {

        // provided method signatures for consumer
        // these are the operations available in this interface

        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
        void CreateBook(Book b);
        void UpdateBook(Book b);
        void DeleteBook(Book b);
        
        bool SaveChanges();
    }
}