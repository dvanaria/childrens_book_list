using System;
using System.Collections.Generic;
using System.Linq;
using ChildrensBookList.Models;

namespace ChildrensBookList.Data {

    public class SqlChildrensBookListRepo : IChildrensBookListRepo
    {
        private readonly ChildrensBookListContext _context;

        // make use of the DB Context class to return our books from the database
        // get the database Context from the constructor's dependency injection
        public SqlChildrensBookListRepo(ChildrensBookListContext context)
        {
            _context = context;
        }

        public void CreateBook(Book b)
        {
            if(b == null){

                throw new ArgumentNullException(nameof(b));
            }

            _context.Books.Add(b);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            // use the Linq command 'FirstOrderDefault'
            // and then use a lambda expression to specify to 
            // get something that == to id
            return _context.Books.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            // This method must be called to save all changes made
            // to the database
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateBook(Book b)
        {
            // Nothing needed here because this will be implemented by the DB Context
        }

        public void DeleteBook(Book b)
        {
            if(b == null) {
                throw new ArgumentNullException();  
            }

            _context.Books.Remove(b);
        }
            
            
    }
}